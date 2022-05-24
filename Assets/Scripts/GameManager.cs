using UnityEngine;
using UnityEngine.UI;

public enum canvas_menu
{
    current,
    menuPrincipal,
    comoJugar,
    inGame,
    endGame,
    inGameNivel2,
    endGameNivel2
};

public class GameManager : MonoBehaviour
{
    public static GameManager shared;

    //public Canvas menuCanvas;
    public Canvas canvasMenuPrincipal;
    public Canvas canvasComoJugar;
    public Canvas ingameCanvas;
    public Canvas endGameCanvas;

    //UI InGame
    public Image CartaOculta;
    public Text AciertosText;
    public Text esCorrecto;
    public Text Fallos;
    public Text Rondas;
    public Button[] botones;

    //Variables InGame
    public int cantidadAciertos;
    public int cantidadFallos;
    public int cantidadRondas;
    public int cambiarCarta;

    //Musica
    public AudioSource music;

    //Botones musica
    public Button musicOn, musicOff;

    private Timer timer;
    [SerializeField]
    private ControlEleccionCarta eleccionCarta;

    void Awake()
    {
        shared = this;    
    }

    void Start()
    {
        timer = GetComponent<Timer>();

        canvasMenuPrincipal.enabled = true;
    }
    public void OcultarCarta()
    {
        CartaOculta.sprite = Resources.Load<Sprite>("Sprites/CartaMisteriosa/" + 0);
        esCorrecto.text = "";

        cantidadRondas++;
        Rondas.text = "Cartas: " + cantidadRondas.ToString() + "/25";

        //Vuelve a activar los botones una vez que la carta se vuelve a ocultar
        for (int i = 0; i < 5; i++)
        {
            botones[i].enabled = true;
        }
    }

    public void startGame()
    {
        InGame.shared.pantallaJuego = InGame.shared.Pantalla_Juego(1.0f);

        StartCoroutine(InGame.shared.pantallaJuego);

        cantidadRondas = 1;

        AciertosText.text = "Aciertos: " + cantidadAciertos.ToString();
        Fallos.text = "Fallos: " + cantidadFallos.ToString();
        Rondas.text = "Cartas: " + cantidadRondas.ToString() + "/25";

        CartaOculta.sprite = Resources.Load<Sprite>("Sprites/CartaMisteriosa/" + 0);
        esCorrecto.text = "";
    }

    public void Reinicio()
    {
        CambioDeEstado(canvas_menu.inGame);

        cantidadAciertos = 0;
        cantidadFallos = 0;
        cantidadRondas = 1;
        cambiarCarta = 0;

        AciertosText.text = "Aciertos: " + cantidadAciertos.ToString();
        Fallos.text = "Fallos: " + cantidadFallos.ToString();
        Rondas.text = "Cartas: " + cantidadRondas.ToString() + "/25";
    }

    public void endGame()
    {
        PlayerPrefs.SetInt("aciertos", cantidadAciertos);
        PlayerPrefs.SetInt("fallos", cantidadFallos);

        timer.stopTimer();

        CambioDeEstado(canvas_menu.endGame);
    }

    public void CerrarJuego()
    {
        MenuPrincipal.shared.salirDelJuego = MenuPrincipal.shared.Salir_Del_Juego(1.0f);

        StartCoroutine(MenuPrincipal.shared.salirDelJuego);
    }

    public void VolverAlMenuPrincipal()
    {
        MenuPrincipal.shared.volverAlMenu = MenuPrincipal.shared.VolverAlMenu(1.0f);

        StartCoroutine(MenuPrincipal.shared.volverAlMenu);
    }

    public void VolverAlMenuPrincipalNivel2()
    {
        MenuPrincipal.shared.volverAlMenu = MenuPrincipal.shared.VolverAlMenuNivel2(1.0f);

        StartCoroutine(MenuPrincipal.shared.volverAlMenu);
    }

    public void ComoJugar()
    {
        comoJugar.shared.cambiarAComo = comoJugar.shared.CambiarAJugar(1.0f);

        StartCoroutine(comoJugar.shared.cambiarAComo);
    }

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

    public void CambioDeEstado(canvas_menu estado)
    {
        switch (estado)
        {
            case canvas_menu.menuPrincipal:

                canvasMenuPrincipal.enabled = true;
                canvasComoJugar.enabled = false;
                ingameCanvas.enabled = false;
                endGameCanvas.enabled = false;
                GameControlTiempo.gameControl.CanvasInGameNivel2.enabled = false;
                GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = false;
                break;

            case canvas_menu.comoJugar:
                canvasMenuPrincipal.enabled = false;
                canvasComoJugar.enabled = true;
                ingameCanvas.enabled = false;
                endGameCanvas.enabled = false;
                GameControlTiempo.gameControl.CanvasInGameNivel2.enabled = false;
                GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = false;
                break;

            case canvas_menu.inGame:

                canvasMenuPrincipal.enabled = false;
                canvasComoJugar.enabled = false;
                ingameCanvas.enabled = true;
                endGameCanvas.enabled = false;
                GameControlTiempo.gameControl.CanvasInGameNivel2.enabled = false;
                GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = false;
                break;

            case canvas_menu.endGame:

                canvasMenuPrincipal.enabled = false;
                canvasComoJugar.enabled = false;
                ingameCanvas.enabled = false;
                endGameCanvas.enabled = true;
                GameControlTiempo.gameControl.CanvasInGameNivel2.enabled = false;
                GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = false;
                break;

            case canvas_menu.inGameNivel2:

                canvasMenuPrincipal.enabled = false;
                canvasComoJugar.enabled = false;
                ingameCanvas.enabled = false;
                endGameCanvas.enabled = false;
                GameControlTiempo.gameControl.CanvasInGameNivel2.enabled = true;
                GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = false;
                break;

            case canvas_menu.endGameNivel2:

                canvasMenuPrincipal.enabled = false;
                canvasComoJugar.enabled = false;
                ingameCanvas.enabled = false;
                endGameCanvas.enabled = false;
                GameControlTiempo.gameControl.CanvasInGameNivel2.enabled = false;
                GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = true;
                break;
        }

        estado = canvas_menu.current;
    }
}

