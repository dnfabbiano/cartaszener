using System.Collections;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public static MenuPrincipal shared;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private CanvasGroup canvas;

    private void Awake()
    {
        shared = this;
    }

    private void Start()
    {
        if (gameManager.canvasMenuPrincipal.enabled)
        {
            gameManager.ingameCanvas.enabled = false;
            gameManager.canvasComoJugar.enabled = false;
            gameManager.endGameCanvas.enabled = false;
        }
    }

    // ---------- FADES ----------
    public IEnumerator Fade(CanvasGroup cg, float from, float to, float duration)
    {
        float t = 0;
        cg.alpha = from;

        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }

        cg.alpha = to;
    }

    // ---------- ÁUDIO ----------
    private IEnumerator FadeVolume(float from, float to, float duration)
    {
        float t = 0;
        var audio = GameManager.shared.music;
        audio.volume = from;

        while (t < duration)
        {
            t += Time.deltaTime;
            audio.volume = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }

        audio.volume = to;
    }

    // ---------- BOTONES ----------
    public void IniciarJuego()
    {
        StartCoroutine(IniciarJuegoRoutine());
    }

    public void IniciarJuegoNivel2()
    {
        StartCoroutine(IniciarJuegoNivel2Routine());
    }

    // ---------- RUTINAS ----------
    private IEnumerator IniciarJuegoRoutine()
    {
        // Fade out del menú
        yield return StartCoroutine(Fade(canvas, 1, 0, 1f));

        // Fade del siguiente canvas
        EndGameTiempo.shared.fadeOut = false;
        EndGameTiempo.shared.fadeIn = true;

        yield return new WaitForSeconds(1f);

        gameManager.startGame();
    }

    private IEnumerator IniciarJuegoNivel2Routine()
    {
        yield return StartCoroutine(Fade(canvas, 1, 0, 1f));

        EndGameTiempo.shared.fadeOut = false;
        EndGameTiempo.shared.fadeIn = true;

        yield return new WaitForSeconds(1f);

        GameControlTiempo.gameControl.StartGame();
    }

    public IEnumerator VolverAlMenu(float tiempo)
    {
        // Fade out del InGame
        InGame.shared.activarFadeIn = true;
        InGame.shared.activarFadeOut = false;

        comoJugar.shared.activarFadeIn = true;
        comoJugar.shared.activarFadeOut = false;

        yield return new WaitForSeconds(tiempo);

        // Música sube nuevamente
        GameManager.shared.music.Play();
        yield return StartCoroutine(FadeVolume(0, 1, 1f));

        Eleccion_Cartas.shared.ReiniciarTodo();

        // Fade del menú principal
        yield return StartCoroutine(Fade(canvas, 0, 1, 1f));

        gameManager.CambioDeEstado(canvas_menu.menuPrincipal);
    }

    public IEnumerator VolverAlMenuNivel2(float tiempo)
    {
        InGameTiempo.shared.fadeIn = true;
        InGameTiempo.shared.fadeOut = false;

        Timer_2.timer.stopTimer();

        yield return new WaitForSeconds(tiempo);

        GameManager.shared.music.Play();

        Eleccion_Cartas.shared.ReiniciarTodo();

        yield return StartCoroutine(Fade(canvas, 0, 1, 1f));

        gameManager.CambioDeEstado(canvas_menu.menuPrincipal);
    }

    public IEnumerator Salir_Del_Juego(float tiempo)
    {
        // Fade out general del menú
        yield return StartCoroutine(Fade(canvas, 1, 0, 1f));

        // Fade específico del end game
        EndGameTiempo.shared.fadeOut = false;
        EndGameTiempo.shared.fadeIn = true;

        yield return new WaitForSeconds(tiempo);

        Application.Quit();
    }
}
