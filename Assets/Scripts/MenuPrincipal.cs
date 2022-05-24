using System.Collections;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public static MenuPrincipal shared;

    [SerializeField]
    private GameManager gameManager;

    public bool activarFadeOut = false;
    public bool activarFadeIn = false;

    public CanvasGroup canvas;

    public IEnumerator volverAlMenu;
    public IEnumerator salirDelJuego;

    public bool vBajo = false;

    public bool vAlto = false;

    void Awake()
    {
        shared = this;
    }

    void Start()
    {
        if(gameManager.canvasMenuPrincipal.enabled == true)
        {
            gameManager.ingameCanvas.enabled = false;
            gameManager.canvasComoJugar.enabled = false;
            gameManager.endGameCanvas.enabled = false;
        }
    }

    void Update()
    {
        GameControlTiempo.gameControl.EfectoFade(canvas, activarFadeIn, activarFadeOut);

        if (vBajo == true)
        {
            GameManager.shared.music.volume += Time.deltaTime;
        }

        if (vAlto == true)
        {
            GameManager.shared.music.volume -= Time.deltaTime;
        }
    }

    public void IniciarJuego()
    {
        activarFadeOut = false;

        activarFadeIn = true;

        StartCoroutine("CambioPantalla", 1.0f);
    }

    public void IniciarJuegoNivel2()
    {
        activarFadeOut = false;
        activarFadeIn = true;

        StartCoroutine("CambiaPantallaNivel2", 1.0f);
    }

    public IEnumerator VolverAlMenuNivel2(float tiempo)
    {
        InGameTiempo.shared.fadeIn = true;

        InGameTiempo.shared.fadeOut = false;

        Timer_2.timer.stopTimer();

        yield return new WaitForSeconds(tiempo);

        GameManager.shared.music.Play();

        vAlto = false;

        vBajo = true;

        Eleccion_Cartas.shared.ReiniciarTodo();

        activarFadeIn = false;

        activarFadeOut = true;

        gameManager.CambioDeEstado(canvas_menu.menuPrincipal);
    }

    public IEnumerator VolverAlMenu(float tiempo)
    {
        InGame.shared.activarFadeIn = true;

        InGame.shared.activarFadeOut = false;

        vAlto = true;
        vBajo = false;

        comoJugar.shared.activarFadeIn = true;

        comoJugar.shared.activarFadeOut = false;

        yield return new WaitForSeconds(tiempo);

        GameManager.shared.music.Play();

        vAlto = false;

        vBajo = true;

        Eleccion_Cartas.shared.ReiniciarTodo();

        activarFadeIn = false;

        activarFadeOut = true;

        gameManager.CambioDeEstado(canvas_menu.menuPrincipal);
    }

    public IEnumerator Salir_Del_Juego(float tiempo)
    {
        activarFadeIn = true;

        activarFadeOut = false;

        EndGameTiempo.shared.fadeOut = false;
        EndGameTiempo.shared.fadeIn = true;

        yield return new WaitForSeconds(tiempo);

        Application.Quit();
    }

    //Para iniciar el nivel clásico
    public IEnumerator CambioPantalla(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        gameManager.startGame();
    }

    //Inicia el nivel por tiempo
    public IEnumerator CambiaPantallaNivel2(float tiempo)
    {
        EndGameTiempo.shared.fadeOut = false;
        EndGameTiempo.shared.fadeIn = true;

        yield return new WaitForSeconds(tiempo);

        GameControlTiempo.gameControl.StartGame();
    }
}
