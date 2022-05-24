using UnityEngine;
using UnityEngine.UI;

public class Eleccion_Cartas : MonoBehaviour
{
    public static Eleccion_Cartas shared;

    public Button [] botones; 

    public Image cartaActual;

    //variables con random.range
    int cambiarCartaActual;
    int ocultarCarta = 0;

    //indices de las imagenes de las cartas
    int[] numeros_cartas = new int[5];

    //Textos de Aciertos y Fallos
    public Text fallos_texto, aciertos_texto;

    //Variables de fallos y aciertos

    public int fallos;

    public int aciertos;
   

    //Texto rondas
    public Text textEstadoMision;

    void Awake()
    {
        shared = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ReiniciarTodo();

        textEstadoMision.text = "Estado del objetivo: no completado";

        cambiarCartaActual = Random.Range(1, 6);

        cartaActual.sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + cambiarCartaActual);

        aciertos_texto.text = "Aciertos: " + aciertos.ToString();
        fallos_texto.text = "Fallos: " + fallos.ToString();

        for(int i = 0; i < botones.Length; i++)
        {
            botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartaMisteriosa/" + ocultarCarta);
        }

        Mezclar();
    }

    public void ReiniciarTodo()
    {
        aciertos = 0;

        aciertos_texto.text = "Aciertos: " + aciertos.ToString();

        fallos = 0;

        fallos_texto.text = "Fallos: " + fallos.ToString();

        textEstadoMision.color = Color.red;
        textEstadoMision.text = "Estado del objetivo: no completado";

        cambiarCartaActual = Random.Range(1, 6);

        cartaActual.sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + cambiarCartaActual);

        aciertos_texto.text = "Aciertos: " + aciertos.ToString();
        fallos_texto.text = "Fallos: " + fallos.ToString();

        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartaMisteriosa/" + ocultarCarta);
        }

        Mezclar();
    }

    public void CambiarCartayOcultarCartas() //Oculta las cartas para luego mezclarlas
    {
        textEstadoMision.text = "Estado del objetivo: no completado";

        cambiarCartaActual = Random.Range(1, 6);

        cartaActual.sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + cambiarCartaActual);

        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartaMisteriosa/" + ocultarCarta);
            botones[i].interactable = true;
        }
    }

    public void Mezclar() //Metodo para que generar numeros aleatorios sin repetir
    {
        for(int contador1 = 0; contador1 <= 4; contador1++)
        {
            numeros_cartas[contador1] = Random.Range(1, 6);
            int contador2 = 0;

            while(contador2 < contador1)
            {
                if(numeros_cartas[contador2] == numeros_cartas[contador1])
                {
                    numeros_cartas[contador1] = Random.Range(1, 6);
                    contador2 = 0;
                    continue;
                }

                contador2++;
            }
        }
    }

    public void BloquearCartas()
    {
        for(int i = 0; i <= 4; i++)
        {
            botones[i].interactable = false;
        }
    }

    //Campara la carta seleccionada con su nombre y si es iguala la carta actual acierta y en caso contrario se suma un fallo
    public void Car_Selection(Button btn)
    {
        switch(btn.name)
        {
            case "BtnCartaMisteriosa1":
                botones[0].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[0]);

                for (int i = 0; i <= 4; i++)
                {
                    botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

                    BloquearCartas();
                }

                if (cambiarCartaActual == numeros_cartas[0])
                {
                    aciertos++;
                    aciertos_texto.text = "Aciertos: " + aciertos.ToString();
                }
                else
                {
                    fallos++;
                    fallos_texto.text = "Fallos: " + fallos.ToString();
                }

                Timer_2.timer.startTimerCambioCartas();
                break;

            case "BtnCartaMisteriosa2":
                botones[1].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[1]);

                for (int i = 0; i <= 4; i++)
                {
                    botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

                    BloquearCartas();
                }

                if (cambiarCartaActual == numeros_cartas[1])
                {
                    aciertos++;
                    aciertos_texto.text = "Aciertos: " + aciertos.ToString();
                }
                else
                {
                    fallos++;
                    fallos_texto.text = "Fallos: " + fallos.ToString();
                }

                Timer_2.timer.startTimerCambioCartas();
                break;

            case "BtnCartaMisteriosa3":
                botones[2].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[2]);

                for (int i = 0; i <= 4; i++)
                {
                    botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

                    BloquearCartas();
                }

                if (cambiarCartaActual == numeros_cartas[2])
                {
                    aciertos++;
                    aciertos_texto.text = "Aciertos: " + aciertos.ToString();
                }
                else
                {
                    fallos++;
                    fallos_texto.text = "Fallos: " + fallos.ToString();
                }


                Timer_2.timer.startTimerCambioCartas();
                break;

            case "BtnCartaMisteriosa4":
                botones[3].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[3]);

                for (int i = 0; i <= 4; i++)
                {
                    botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

                    BloquearCartas();
                }

                //Si la carta elegida es correcta se suma un acierto, sino se le suma un fallo
                if (cambiarCartaActual == numeros_cartas[3])
                {
                    aciertos++;
                    aciertos_texto.text = "Aciertos: " + aciertos.ToString();
                }
                else
                {
                    fallos++;
                    fallos_texto.text = "Fallos: " + fallos.ToString();
                }

                Timer_2.timer.startTimerCambioCartas();
                break;

            case "BtnCartaMisteriosa5":
                botones[4].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[4]);

                for (int i = 0; i <= 4; i++)
                {
                    botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

                    BloquearCartas();
                }

                if (cambiarCartaActual == numeros_cartas[4])
                {
                    aciertos++;
                    aciertos_texto.text = "Aciertos: " + aciertos.ToString();
                }
                else
                {
                    fallos++;
                    fallos_texto.text = "Fallos: " + fallos.ToString();
                }

                Timer_2.timer.startTimerCambioCartas();
                break;
        }
    }

    //public void Carta1()
    //{
    //    botones[0].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[0]);

    //    for (int i = 0; i <= 4; i++)
    //    {
    //        botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

    //        BloquearCartas();
    //    }

    //    if(cambiarCartaActual == numeros_cartas[0])
    //    {
    //        aciertos++;
    //        aciertos_texto.text = "Aciertos: " + aciertos.ToString();
    //    }
    //    else
    //    {
    //        fallos++;
    //        fallos_texto.text = "Fallos: " + fallos.ToString();
    //    }

    //    Timer_2.timer.startTimerCambioCartas();
    //}

    //public void Carta2()
    //{
    //    botones[1].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[1]);

    //    for (int i = 0; i <= 4; i++)
    //    {
    //        botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

    //        BloquearCartas();
    //    }

    //    if (cambiarCartaActual == numeros_cartas[1])
    //    {
    //        aciertos++;
    //        aciertos_texto.text = "Aciertos: " + aciertos.ToString();
    //    }
    //    else
    //    {
    //        fallos++;
    //        fallos_texto.text = "Fallos: " + fallos.ToString();
    //    }

    //    Timer_2.timer.startTimerCambioCartas();
    //}

    //public void Carta3()
    //{
    //    botones[2].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[2]);

    //    for (int i = 0; i <= 4; i++)
    //    {
    //        botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

    //        BloquearCartas();
    //    }

    //    if (cambiarCartaActual == numeros_cartas[2])
    //    {
    //        aciertos++;
    //        aciertos_texto.text = "Aciertos: " + aciertos.ToString();
    //    }
    //    else
    //    {
    //        fallos++;
    //        fallos_texto.text = "Fallos: " + fallos.ToString();
    //    }


    //    Timer_2.timer.startTimerCambioCartas();
    //}

    //public void Carta4()
    //{
    //    //Mezcla las cartas al menos una vez y al elegir la carta muestra el resto de las que están ocultas
    //    botones[3].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[3]);

    //    for (int i = 0; i <= 4; i++)
    //    {
    //        botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

    //        BloquearCartas();
    //    }
        
    //    //Si la carta elegida es correcta se suma un acierto, sino se le suma un fallo
    //    if (cambiarCartaActual == numeros_cartas[3])
    //    {
    //        aciertos++;
    //        aciertos_texto.text = "Aciertos: " + aciertos.ToString();
    //    }
    //    else
    //    {
    //        fallos++;
    //        fallos_texto.text = "Fallos: " + fallos.ToString();
    //    }

    //    Timer_2.timer.startTimerCambioCartas();
    //}

    //public void Carta5()
    //{
    //    botones[4].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[4]);

    //    for (int i = 0; i <= 4; i++)
    //    {
    //        botones[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/CartasZener/" + numeros_cartas[i]);

    //        BloquearCartas();
    //    }

    //    if (cambiarCartaActual == numeros_cartas[4])
    //    {
    //        aciertos++;
    //        aciertos_texto.text = "Aciertos: " + aciertos.ToString();
    //    }
    //    else
    //    {
    //        fallos++;
    //        fallos_texto.text = "Fallos: " + fallos.ToString();
    //    }

    //    Timer_2.timer.startTimerCambioCartas();
    //}
}
