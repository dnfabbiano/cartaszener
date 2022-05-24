using System.Collections;
using UnityEngine;

public class GameControlTiempo : MonoBehaviour
{
    public static GameControlTiempo gameControl;

    public Canvas CanvasInGameNivel2;
    public Canvas CanvasEndGameNivel2;

    [SerializeField]
    private Timer_2 tiempo;

    void Awake()
    {
        gameControl = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        tiempo = GetComponent<Timer_2>();
    }

    public void StartGame()
    {
        InGameTiempo.shared.PantallaNivel2 = InGameTiempo.shared.Pantalla_Nivel2(1.0f);

        StartCoroutine(InGameTiempo.shared.PantallaNivel2);

        GameManager.shared.CambioDeEstado(canvas_menu.inGameNivel2);
    }

    public void EndGame()
    {
        StartCoroutine("Resultados", 3.0f);
    }

    //Resultados del metodo EndGame
    public IEnumerator Resultados(float t)
    {
        InGameTiempo.shared.fadeOut = false;
        InGameTiempo.shared.fadeIn = true;

        EndGameTiempo.shared.CapturarResultados(Eleccion_Cartas.shared.aciertos, Eleccion_Cartas.shared.fallos);

        tiempo.stopTimer();

        yield return new WaitForSeconds(t);

        EndGameTiempo.shared.fadeOut = true;
        EndGameTiempo.shared.fadeIn = false;

        GameManager.shared.CambioDeEstado(canvas_menu.endGameNivel2);
    }

    public void BajarySubirVolumen(float vBajo, float vAlto, AudioSource sonido)
    {
        if(sonido.isPlaying == true)
        {
            if(sonido.volume < vBajo)
            {
                sonido.volume += Time.deltaTime;
            }
            
            if(sonido.volume > vAlto)
            {
                sonido.volume -= Time.deltaTime;
            }
        }
    }

    public void EfectoFade(CanvasGroup canvas, bool fadeIn, bool fadeOut)
    {
        if(fadeOut == true)
        {
            canvas.alpha += Time.deltaTime;
        }

        if(fadeIn == true)
        {
            canvas.alpha -= Time.deltaTime;
        }
    }
}
