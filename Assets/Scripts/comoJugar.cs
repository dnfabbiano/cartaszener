using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class comoJugar : MonoBehaviour
{
    public static comoJugar shared;

    [SerializeField]
    private GameManager gameManager;

    public Text texto1, texto2;
    public Button button1, button2;

    public IEnumerator cambiarAComo;

    public CanvasGroup canvas;

    public bool activarFadeIn = false;
    public bool activarFadeOut = false;

    void Awake()
    {
        shared = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager.canvasComoJugar.enabled == true)
        {
            gameManager.ingameCanvas.enabled = false;
            gameManager.canvasMenuPrincipal.enabled = false;
            gameManager.endGameCanvas.enabled = false;
        }
    }

    void Update()
    {
        if(activarFadeOut == true)
        {
            canvas.alpha += Time.deltaTime;
        }

        if(activarFadeIn == true)
        {
            canvas.alpha -= Time.deltaTime;
        }
    }

    public void botonSiguiente()
    {
        texto1.gameObject.SetActive(false);
        texto2.gameObject.SetActive(true);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);
    }

    public void botonAnterior()
    {
        texto1.gameObject.SetActive(true);
        texto2.gameObject.SetActive(false);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);
    }

    public IEnumerator CambiarAJugar(float tiempo)
    {
        MenuPrincipal.shared.activarFadeIn = true;

        MenuPrincipal.shared.activarFadeOut = false;

        yield return new WaitForSeconds(tiempo);

        activarFadeOut = true;

        activarFadeIn = false;

        gameManager.CambioDeEstado(canvas_menu.comoJugar);
    }
}
