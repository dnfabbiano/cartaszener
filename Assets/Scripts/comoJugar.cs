using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComoJugar : MonoBehaviour
{
    public static ComoJugar Instance { get; private set; }

    [SerializeField] private GameManager gameManager;

    [SerializeField] private Text texto1, texto2;
    [SerializeField] private Button button1, button2;

    [SerializeField] private CanvasGroup canvas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if (gameManager.canvasComoJugar.enabled)
        {
            gameManager.ingameCanvas.enabled = false;
            gameManager.canvasMenuPrincipal.enabled = false;
            gameManager.endGameCanvas.enabled = false;
        }
    }

    // ---------- UI ----------
    public void BotonSiguiente()
    {
        SetPagina(true);
    }

    public void BotonAnterior()
    {
        SetPagina(false);
    }

    private void SetPagina(bool pagina2)
    {
        texto1.gameObject.SetActive(!pagina2);
        texto2.gameObject.SetActive(pagina2);

        button1.gameObject.SetActive(!pagina2);
        button2.gameObject.SetActive(pagina2);
    }

    // ---------- Fades ----------
    public IEnumerator Fade(float from, float to, float duration)
    {
        float t = 0;
        canvas.alpha = from;

        while (t < duration)
        {
            t += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }

        canvas.alpha = to;
    }

    // ---------- Cambio a menú jugar ----------
    public IEnumerator CambiarAJugar(float tiempo)
    {
        // Fade del menú principal
        StartCoroutine(MenuPrincipal.shared.Fade(1, 0, 1f));

        yield return new WaitForSeconds(tiempo);

        // Fade de esta pantalla
        yield return StartCoroutine(Fade(0, 1, 1f));

        // Cambiar de estado
        gameManager.CambioDeEstado(canvas_menu.comoJugar);
    }
}
