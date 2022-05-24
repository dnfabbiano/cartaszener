using System.Collections;
using UnityEngine;

public class InGame : MonoBehaviour
{
    public static InGame shared;

    [SerializeField]
    private GameManager gameManager;

    public MenuPrincipal menu;

    public CanvasGroup canvasAlpha;

    public bool activarFadeOut = false;
    public bool activarFadeIn = false;

    public IEnumerator pantallaJuego;
    public IEnumerator pantallaFin;

    void Awake()
    {
        shared = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager.ingameCanvas.enabled == true)
        {
            gameManager.canvasMenuPrincipal.enabled = false;
            gameManager.canvasComoJugar.enabled = false;
            gameManager.endGameCanvas.enabled = false;
            menu.IniciarJuego();
        } 
    }

    void Update()
    {
        GameControlTiempo.gameControl.EfectoFade(canvasAlpha, activarFadeIn, activarFadeOut);

        if (MenuPrincipal.shared.vBajo == true)
        {
            GameManager.shared.music.volume += Time.deltaTime;
        }

        if (MenuPrincipal.shared.vAlto == true)
        {
            GameManager.shared.music.volume -= Time.deltaTime;
        }
    }

    public IEnumerator Pantalla_Fin(float tiempo)
    {
        activarFadeOut = false;

        activarFadeIn = true;

        yield return new WaitForSeconds(tiempo);

        EndGameControl.shared.activarFadeOut = true;

        EndGameControl.shared.activarFadeIn = false;

        gameManager.endGame();
    }

    public IEnumerator Pantalla_Juego(float tiempo)
    {
        EndGameControl.shared.activarFadeIn = true;

        EndGameControl.shared.activarFadeOut = false;

        yield return new WaitForSeconds(tiempo);

        activarFadeOut = true;

        activarFadeIn = false;

        gameManager.Reinicio();
    }
}
