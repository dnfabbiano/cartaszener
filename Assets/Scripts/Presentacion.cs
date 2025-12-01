using System.Collections;
using UnityEngine;

public class Presentacion : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;

    private void Start()
    {
        GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = false;

        StartCoroutine(PasarAMenu());
    }

    private IEnumerator PasarAMenu()
    {
        // Espera inicial antes del fade
        yield return new WaitForSeconds(2f);

        // Fade in de esta presentación (1 = opaco, 0 = transparente)
        yield return StartCoroutine(Fade(canvas, 0, 1, 1.5f));

        // Fade del menú principal (si corresponde)
        MenuPrincipal.shared.activarFadeIn = false;
        MenuPrincipal.shared.activarFadeOut = true;

        yield return new WaitForSeconds(0.5f);

        // Cambio de estado
        GameManager.shared.CambioDeEstado(canvas_menu.menuPrincipal);
    }

    private IEnumerator Fade(CanvasGroup cg, float from, float to, float duration)
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
}

