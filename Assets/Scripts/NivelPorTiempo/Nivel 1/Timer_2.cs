using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer_2 : MonoBehaviour
{
    public static Timer_2 timer;

    public IEnumerator relojito;

    //Musica de tiempo acabandose
    public AudioSource sonidoReloj;

    [SerializeField]
    private int minutes;

    [SerializeField]
    private int seconds;

    [SerializeField]
    private int segundosOcultar;

    private int m;
    private int s, so;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private GameControlTiempo gameControl;

    [SerializeField]
    private Eleccion_Cartas elecCartas;

    void Awake()
    {
        timer = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GetComponent<GameControlTiempo>();
    }

    public void startTimer()
    {
        s = seconds;
        m = minutes;
        writeTimer(m, s);
        Invoke("updateTimer", 1f);
        relojito = Reloj(1f);
        StartCoroutine(relojito);
    }

    public void startTimerCambioCartas()
    {
        so = segundosOcultar;
        Invoke("timerHideCars", 1f);
    }

    public void stopTimer()
    {
        CancelInvoke();
        StopCoroutine(relojito);
    }

    public void timerHideCars()
    {
        so--;
        if(so < 0)
        {
            Eleccion_Cartas.shared.CambiarCartayOcultarCartas();
            Eleccion_Cartas.shared.Mezclar();
            CancelInvoke("timerHideCars");
            return;
        }

        Invoke("timerHideCars", 1f);
    }

    private void updateTimer()
    {
        s--;
        if (s < 0)
        {
            if (m == 0)
            {
                gameControl.EndGame();
                EndGameTiempo.shared.Invoke("FinDeJuego", 0.1f);
                return;
            }
            else
            {   //Si el jugador llegara a los 5 aciertos antes de que termine el reloj en minutos
                if (elecCartas.aciertos == 5 && m < 3)
                {
                    elecCartas.textEstadoMision.color = Color.green;
                    elecCartas.textEstadoMision.text = "Estado del objetivo: completado";
                    PlayerPrefs.SetInt("minutos", m);
                    PlayerPrefs.SetInt("segundos", s);
                    gameControl.EndGame();
                    EndGameTiempo.shared.MostrarResultados();
                    return;
                }
                else
                {
                    m--;
                    s = 59;
                }
            }
        }
        else
        {   //Si el jugador llegara a los 5 aciertos despues de pasado 1 min
            if (elecCartas.aciertos == 5 && s < 59)
            {
                elecCartas.textEstadoMision.color = Color.green;
                elecCartas.textEstadoMision.text = "Estado del objetivo: completado";
                PlayerPrefs.SetInt("minutos", m);
                PlayerPrefs.SetInt("segundos", s);
                gameControl.EndGame();
                EndGameTiempo.shared.MostrarResultados();
                return;
            }
        }

        writeTimer(m, s);
        Invoke("updateTimer", 1f);
    }

    private void writeTimer(int m, int s)
    {
        if (s < 10)
        {
            timerText.color = Color.green;
            timerText.text = "TIEMPO: " + m.ToString() + ":0" + s.ToString();
        }
        else
        {
            timerText.color = Color.green;
            timerText.text = "TIEMPO: " + m.ToString() + ":" + s.ToString();
        }

        //Ya en los ultimos 15 segundos se cambiará el color del reloj a rojo avisando que se termina el tiempo
        if (s < 15 && m == 0)
        {
            timerText.color = Color.red;
            timerText.text = "TIEMPO: " + m.ToString() + ":" + s.ToString();
            if (s < 10 && m == 0)
            {
                timerText.text = "TIEMPO: " + m.ToString() + ":0" + s.ToString();
            }
        }
    }

    public IEnumerator Reloj(float tiempo)
    {
        while(GameControlTiempo.gameControl.CanvasInGameNivel2 != false)
        {
            sonidoReloj.Play();

            yield return new WaitForSeconds(tiempo);

            sonidoReloj.Stop();
        }
    }
}
