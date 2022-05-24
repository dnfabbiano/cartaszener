using UnityEngine;

public class Timer : MonoBehaviour
{
    //[SerializeField]
    //private int minutes;

    [SerializeField]
    private int seconds;

    //private int m;
    private int s;

   // [SerializeField]
   // private Text timerText;

    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private ControlEleccionCarta eleccionCarta;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void startTimer()
    {
        s = seconds;
        //writeTimer(s);
        Invoke("updateTimer", 1f);
    }

    public void stopTimer()
    {
        CancelInvoke();
    }

    private void updateTimer()
    {
        s--;
        if(s < 0)
        {
            if (gameManager.cantidadRondas == 25 && s < 0)
            {
                gameManager.CancelInvoke("OcultarCarta"); //Cancelo la invocación al metodo

                for (int i = 0; i < 5; i++)
                {
                    gameManager.botones[i].enabled = false; //Y bloqueo las cartas para que el usuario no vuelva a tocarlas
                }

                InGame.shared.pantallaFin = InGame.shared.Pantalla_Fin(1.0f);

                StartCoroutine(InGame.shared.pantallaFin);
            }
            gameManager.Invoke("OcultarCarta", 1f); //Se llama al metodo cada dos segundos para ocultar la carta y cambiarla
            stopTimer();
            return;
        }

        //writeTimer(s);
        Invoke("updateTimer", 1f);
    }

    //private void writeTimer(int s)
    //{
    //    if(s < 10)
    //    {
    //        timerText.text = "Próxima carta en: " + "0" + s.ToString(); 
    //    }
    //    else
    //    {
    //        timerText.text = "Próxima carta en: " + s.ToString();
    //    }
    //}
}
