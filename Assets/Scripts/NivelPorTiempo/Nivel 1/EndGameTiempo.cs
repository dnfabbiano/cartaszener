using UnityEngine;
using UnityEngine.UI;

public class EndGameTiempo : MonoBehaviour
{
    public static EndGameTiempo shared;

    public CanvasGroup canvas;

    public Image marcoAciertosYFallos;
    public Image marcoTiempo;
    public Image marcoFindeJuego;

    public Text textAciertos;
    public Text textFallos;
    public Text textTiempo;
    public Text textTuTiempoFue;
    public Text textFindeJuego;

    public bool fadeIn = false;
    public bool fadeOut = false;

    void Awake()
    {
        shared = this;
    }
    // Update is called once per frame
    void Update()
    {
        GameControlTiempo.gameControl.EfectoFade(canvas, fadeIn, fadeOut);
    }

    public void MostrarResultados()
    {
        textAciertos.text = "Aciertos: " + PlayerPrefs.GetInt("aciertos").ToString();
        textFallos.text = "Fallos: " + PlayerPrefs.GetInt("fallos").ToString();

        marcoFindeJuego.gameObject.SetActive(false);

        marcoAciertosYFallos.gameObject.SetActive(true);

        marcoTiempo.gameObject.SetActive(true);

        if (PlayerPrefs.GetInt("segundos") < 10)
        {
            textTiempo.text = "0" + PlayerPrefs.GetInt("minutos").ToString() + ":0" + PlayerPrefs.GetInt("segundos").ToString();
        }
        else
        {
            textTiempo.text = "0" + PlayerPrefs.GetInt("minutos").ToString() + ":" + PlayerPrefs.GetInt("segundos").ToString();
        }
    }

    public void CapturarResultados(int acierto, int fallo)
    {
        PlayerPrefs.SetInt("aciertos", acierto);
        PlayerPrefs.SetInt("fallos", fallo);
    }

    public void FinDeJuego()
    {
        textFindeJuego.gameObject.SetActive(true);

        marcoFindeJuego.gameObject.SetActive(true);

        marcoAciertosYFallos.gameObject.SetActive(false);

        marcoTiempo.gameObject.SetActive(false);

        textAciertos.gameObject.SetActive(false);

        textFallos.gameObject.SetActive(false);

        textTiempo.gameObject.SetActive(false);

        textTuTiempoFue.gameObject.SetActive(false);
    }
}
