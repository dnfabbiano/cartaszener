using System.Collections;
using UnityEngine;

public class Presentacion : MonoBehaviour
{
    public IEnumerator PasarAMenu;

    public CanvasGroup canvas;

    bool fadeIn = false;

    bool fadeOut = false;

    void Start()
    {
        GameControlTiempo.gameControl.CanvasEndGameNivel2.enabled = false;

        PasarAMenu = Pasar_a_Menu();
        
        StartCoroutine(PasarAMenu); 
    }

    // Start is called before the first frame update
    void Update()
    {
        GameControlTiempo.gameControl.EfectoFade(canvas, fadeIn, fadeOut);
    }

    public IEnumerator Pasar_a_Menu()
    {
        yield return new WaitForSeconds(2.0f);

        fadeIn = true;

        fadeOut = false;

        yield return new WaitForSeconds(2.0f);

        MenuPrincipal.shared.activarFadeIn = false;

        MenuPrincipal.shared.activarFadeOut = true;

        GameManager.shared.CambioDeEstado(canvas_menu.menuPrincipal);
    }
}
