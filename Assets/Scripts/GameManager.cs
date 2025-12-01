using UnityEngine;
using UnityEngine.UI;

public enum canvas_menu
{
    menuPrincipal,
    comoJugar,
    inGame,
    endGame,
    inGameNivel2,
    endGameNivel2
}

public class GameManager : MonoBehaviour
{
    public static GameManager shared;

    // Canvases
    [Header("Canvases")]
    public Canvas canvasMenuPrincipal;
    public Canvas canvasComoJugar;
    public Canvas ingameCanvas;
    public Canvas endGameCanvas;

    // UI InGame
    [Header("UI InGame")]
    public Image CartaOculta;
    public Text AciertosText;
    public Text esCorrecto;
    public Text Fallos;
    public Text Rondas;
    public Button[] botones;

    // Variables InGame
    public int cantidadAciertos;
    public int cantidadFallos;
    public int cantidadRondas;
    public int cambiarCarta;

    // Música
    public AudioSource music;
    public Button musicOn, musicOff;

    private Timer timer;
    private Sprite cartaMisteriosa;
    private canvas_menu currentState;

    private void Awake()
    {
        shared = this;
    }

    private void Start()
    {
        timer = GetComponent<Timer>();

        // Cacheo de carta misteriosa (evita carga repetida)
        cartaMisteriosa = Resources.Load<Sprite>("Sprites/CartaMisteriosa/0");

        CambioDeEstado(canvas_menu.menuPrincipal);
    }

    // ------------------------
    //      PANTALLAS
    // ------------------------
    public void CambioDeEstado(canvas_menu estado)
    {
        currentState = estado;

        // Apago todos primero
        canvasMenuPrincipal.enabled = false;
        canvasComoJugar.enabled = false;
        ingameCanvas.enabled = false;
        endGameCanvas.enabled = false;
        GameControlTiempo.gameControl.CanvasInGameNivel2.enabled = false;
        GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = false;

        // Enciendo sólo el que corresponde
        switch (estado)
        {
            case canvas_menu.menuPrincipal:
                canvasMenuPrincipal.enabled = true;
                break;

            case canvas_menu.comoJugar:
                canvasComoJugar.enabled = true;
                break;

            case canvas_menu.inGame:
                ingameCanvas.enabled = true;
                break;

            case canvas_menu.endGame:
                endGameCanvas.enabled = true;
                break;

            case canvas_menu.inGameNivel2:
                GameControlTiempo.gameControl.CanvasInGameNivel2.enabled = true;
                break;

            case canvas_menu.endGameNivel2:
                GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = true;
                break;
        }
    }

    // ---------------------------
    //      INICIO DE JUEGO
    // ---------------------------
    public void startGame()
    {
        ResetStats();
        UpdateUI();

        CartaOculta.sprite = cartaMisteriosa;
        esCorrecto.text = "";

        StartCoroutine(InGame.shared.Pantalla_Juego(1.0f));
    }

    public void Reinicio()
    {
        ResetStats();
        UpdateUI();

        CambioDeEstado(canvas_menu.inGame);
    }

    private void ResetStats()
    {
        cantidadAciertos = 0;
        cantidadFallos = 0;
        cantidadRondas = 1;
        cambiarCarta = 0;
    }

    private void UpdateUI()
    {
        AciertosText.text = $"Aciertos: {cantidadAciertos}";
        Fallos.text = $"Fallos: {cantidadFallos}";
        Rondas.text = $"Cartas: {cantidadRondas}/25";
    }

    // ------------------------
    //       END GAME
    // ------------------------
    public void endGame()
    {
        PlayerPrefs.SetInt("aciertos", cantidadAciertos);
        PlayerPrefs.SetInt("fallos", cantidadFallos);

        timer.stopTimer();
        CambioDeEstado(canvas_menu.endGame);
    }

    // ------------------------
    //       BOTONES
    // ------------------------
    public void CerrarJuego()
    {
        StartCoroutine(MenuPrincipal.shared.Salir_Del_Juego(1.0f));
    }

    public void VolverAlMenuPrincipal()
    {
        StartCoroutine(MenuPrincipal.shared.VolverAlMenu(1.0f));
    }

    public void VolverAlMenuPrincipalNivel2()
    {
        StartCoroutine(MenuPrincipal.shared.VolverAlMenuNivel2(1.0f));
    }

    public void ComoJugar()
    {
        StartCoroutine(comoJugar.shared.CambiarAJugar(1.0f));
    }

    // ------------------------
    //       MÚSICA
    // ------------------------
    public void MusicON()
    {
        music.Play();

        musicOff.gameObject.SetActive(true);
        musicOn.gameObject.SetActive(false);
    }

    public void MusicOFF()
    {
        music.Stop();

        musicOn.gameObject.SetActive(true);
        musicOff.gameObject.SetActive(false);
    }

    // ------------------------
    //      CARTA OCULTA
    // ------------------------
    public void OcultarCarta()
    {
        CartaOculta.sprite = cartaMisteriosa;
        esCorrecto.text = "";

        cantidadRondas++;
        Rondas.text = $"Cartas: {cantidadRondas}/25";

        foreach (var b in botones)
            b.enabled = true;
    }
}


