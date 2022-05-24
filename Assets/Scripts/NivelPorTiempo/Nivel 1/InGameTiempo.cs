using System.Collections;
using UnityEngine;

public class InGameTiempo : MonoBehaviour
{
    public static InGameTiempo shared;

    public IEnumerator PantallaNivel2;

    public CanvasGroup canvas;

    public bool fadeIn = false;
    public bool fadeOut = false;

    void Awake()
    {
        shared = this;    
    }

    // Update is called once per frame
    void Update()
    {
        GameControlTiempo.gameControl.EfectoFade(canvas, fadeIn, fadeOut);

        //GameControlTiempo.gameControl.BajarySubirVolumen(volumenbajar, volumensubir, GameManager.shared.music);

        if (MenuPrincipal.shared.vBajo == true)
        {
            GameManager.shared.music.volume += Time.deltaTime;
        }

        if (MenuPrincipal.shared.vAlto == true)
        {
            GameManager.shared.music.volume -= Time.deltaTime;
        }
    }

    public IEnumerator Pantalla_Nivel2(float timer)
    {
        MenuPrincipal.shared.vAlto = true;

        MenuPrincipal.shared.vBajo = false;

        yield return new WaitForSeconds(timer);

        GameManager.shared.music.Stop();

        Eleccion_Cartas.shared.ReiniciarTodo();

        fadeOut = true;

        fadeIn = false;

        Timer_2.timer.startTimer();
    }
}
