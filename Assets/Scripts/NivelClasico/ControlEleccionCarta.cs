using UnityEngine;

public class ControlEleccionCarta : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Timer timer;

    int carta;

    public void Circulo()
    {
        gameManager.cambiarCarta = Random.Range(1, 6);

        gameManager.CartaOculta.sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + gameManager.cambiarCarta);

        //Evita que se vuelva a pulsar los botones antes del cambio de carta
        for (int i = 0; i < 5; i++)
        {
            gameManager.botones[i].enabled = false;
        }

        carta = 1;

        EsCorrecta(carta);

        timer.startTimer();
    }

    public void Cruz()
    {
        gameManager.cambiarCarta = Random.Range(1, 6);

        gameManager.CartaOculta.sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + gameManager.cambiarCarta);

        //Evita que se vuelva a pulsar los botones antes del cambio de carta
        for (int i = 0; i < 5; i++)
        {
            gameManager.botones[i].enabled = false;
        }

        carta = 2;

        EsCorrecta(carta);

        timer.startTimer();
    }

    public void Olas()
    {
        gameManager.cambiarCarta = Random.Range(1, 6);

        gameManager.CartaOculta.sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + gameManager.cambiarCarta);

        //Evita que se vuelva a pulsar los botones antes del cambio de carta
        for (int i = 0; i < 5; i++)
        {
            gameManager.botones[i].enabled = false;
        }

        carta = 3;

        EsCorrecta(carta);

        timer.startTimer();
    }

    public void Cuadrado()
    {
        gameManager.cambiarCarta = Random.Range(1, 6);

        gameManager.CartaOculta.sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + gameManager.cambiarCarta);

        //Evita que se vuelva a pulsar los botones antes del cambio de carta
        for (int i = 0; i < 5; i++)
        {
            gameManager.botones[i].enabled = false;
        }

        carta = 4;

        EsCorrecta(carta);

        timer.startTimer();
    }

    public void Estrella()
    {
        gameManager.cambiarCarta = Random.Range(1, 6);

        gameManager.CartaOculta.sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + gameManager.cambiarCarta);

        //Evita que se vuelva a pulsar los botones antes del cambio de carta
        for (int i = 0; i < 5; i++)
        {
            gameManager.botones[i].enabled = false;
        }

        carta = 5;

        EsCorrecta(carta);

        timer.startTimer();
    }

    public void EsCorrecta(int n)
    {
        if(gameManager.cambiarCarta == carta)
        {
            gameManager.cantidadAciertos++;
            gameManager.AciertosText.text = "Aciertos: " + gameManager.cantidadAciertos.ToString();
            gameManager.esCorrecto.text = "Acertaste";
        }
        else
        {
            gameManager.cantidadFallos++;
            gameManager.Fallos.text = "Fallos: " + gameManager.cantidadFallos.ToString();
            gameManager.esCorrecto.text = "Fallaste";
        }
    }
    
}
