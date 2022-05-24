using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndGameControl : MonoBehaviour
{
    public static EndGameControl shared;

    public Text porcentajeAciertos;
    public Text porcentajeFallos;
    public Text mensaje;

    [SerializeField]
    private GameManager gameManager;

    public CanvasGroup canvas;

    public bool activarFadeIn = false;
    public bool activarFadeOut = false;

    void Awake()
    {
        shared = this;
    }

    void Start()
    {
        if(gameManager.endGameCanvas.enabled == true)
        {
            gameManager.canvasMenuPrincipal.enabled = false;
            gameManager.canvasComoJugar.enabled = false;
            gameManager.ingameCanvas.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        //De transparente a opaco
        if(activarFadeOut == true)
        {
            canvas.alpha += Time.deltaTime;
        }

        //De opaco a transparente
        if(activarFadeIn == true)
        {
            canvas.alpha -= Time.deltaTime;
        }

        float fallos;
        float aciertos;
        float promedioAciertos;
        float promedioFallos;
        fallos = (float)PlayerPrefs.GetInt("fallos");
        aciertos = (float)PlayerPrefs.GetInt("aciertos");

        if (aciertos < 3)
        {
            mensaje.text = "La mayoría de las personas (79%) obtendrán entre 3 y 7 respuestas correctas. " +
                "La probabilidad de adivinar 8 o más correctamente es del 10.9%.\n\n" +
                "Obtuviste " + aciertos.ToString() + " aciertos solamente, sigue practicando.";

            if(aciertos == 0)
            {
                mensaje.text = "La mayoría de las personas (79%) obtendrán entre 3 y 7 respuestas correctas. " +
                "La probabilidad de adivinar 8 o más correctamente es del 10.9%.\n\n" +
                "No acertaste a ninguna figura, no te desamines.";
            }
        }
        else if (aciertos >= 3 && aciertos <= 7)
        {
            mensaje.text = "La mayoría de las personas (79%) obtendrán entre 3 y 7 respuestas correctas. " +
                "La probabilidad de adivinar 8 o más correctamente es del 10.9%.\n\n"+
                "Obtuviste " + aciertos.ToString() + " aciertos, dentro del promedio general.";
        }
        else
        {
            if (aciertos > 7)
            {
                mensaje.text = "La mayoría de las personas (79%) obtendrán entre 3 y 7 respuestas correctas." +
                    "La probabilidad de adivinar 8 o más correctamente es del 10.9%.\n" +
                    "Bien, obtuviste " + aciertos.ToString() + " aciertos, quizas tengas habilidades psíquicas.";
            }
        }

        promedioAciertos = (aciertos * 100) / 25;
        promedioFallos = (fallos * 100) / 25;

        porcentajeAciertos.text = "Aciertos: " + promedioAciertos.ToString() + "%";
        porcentajeFallos.text = "Fallos: " + promedioFallos.ToString() + "%";
    }

    public void Btn_Reiniciar()
    {
        InGame.shared.pantallaJuego = InGame.shared.Pantalla_Juego(1.0f);
        StartCoroutine(InGame.shared.pantallaJuego);
    }

    public IEnumerator Salir(float tiempo)
    {
        activarFadeIn = true;

        activarFadeOut = false;

        yield return new WaitForSeconds(tiempo);

        Application.Quit();
    }

    public void Btn_Salir()
    {
        StartCoroutine("Salir", 1.5f);
    }
}
