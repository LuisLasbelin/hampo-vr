using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;
using Vuforia;
using Image = UnityEngine.UI.Image;

public class Seguir_camino : MonoBehaviour
{
    public PathCreator pathCreator;

    private float velocidad;
    private float velocidad_maxima;
    public float velocidad_maxima_base;
    public float velocidad_nitro;
    private float aceleracion;
    public float aceleracion_nitro;
    public float aceleracion_base;

    private float estabilidad;
    public float estabilidad_maxima;
    public float derape;

    public Animator rueda_derecha;
    public Animator rueda_iquierda;

    public Image imagen;

    public float distancia_recorrida;

    private bool estable;
    public GameObject boton_estabilidad;

    public bool ia;
    
    public bool acelerando;
    public bool derrapando;
    public bool buen_derrape;


    // Start is called before the first frame update
    void Start()
    {
        velocidad_maxima = velocidad_maxima_base;
        aceleracion = aceleracion_base;
        //Make the Unity Action also call your second function
    }

    // Update is called once per frame
    void Update()
    {
        distancia_recorrida += velocidad * Time.deltaTime;
        Quaternion posicion_anterior = transform.rotation;
        transform.position = pathCreator.path.GetPointAtDistance(-distancia_recorrida);
        transform.rotation = pathCreator.path.GetRotationAtDistance(-distancia_recorrida);

        float rotacion_relativa = transform.rotation.y - posicion_anterior.y;
        float rotacion_alterada = Mathf.Abs(rotacion_relativa * 40);

        if (!derrapando)
        {
            if (derape > 0)
            {
                velocidad_maxima = velocidad_nitro;
                aceleracion = aceleracion_nitro;
                derape -= Time.deltaTime / 2;
                if (derape - Time.deltaTime / 2 < 0)
                {
                    velocidad_maxima = velocidad_maxima_base;
                    aceleracion = aceleracion_base;
                }
            }
        }

        if (rotacion_alterada > 1 && rotacion_alterada < 20)
        {
            if (rotacion_relativa > 0)
            {
                rueda_derecha.SetTrigger("Derecha");
                rueda_iquierda.SetTrigger("Derecha");
            }
            else
            {
                rueda_derecha.SetTrigger("Izquierda");
                rueda_iquierda.SetTrigger("Izquierda");
            }

            if (derrapando)
            {
                StartCoroutine(tipo_derrape(true));
                derape += rotacion_alterada * 0.2f;
            }
            else
            {
                if (estabilidad - rotacion_alterada < 0)
                {
                    estable = false;
                    boton_estabilidad.SetActive(true);
                    estabilidad = 0;
                }
                else
                {
                    estabilidad -= rotacion_alterada;
                }
            }
        }
        else
        {
            if (estabilidad + 1 * Time.deltaTime > estabilidad_maxima)
            {
                estable = true;
                boton_estabilidad.SetActive(false);
            }
            else
            {
                estabilidad += estabilidad_maxima * Time.deltaTime;
            }

            if (derrapando)
            {
                StartCoroutine(tipo_derrape(false));
            }

            rueda_derecha.SetTrigger("Recto");
            rueda_iquierda.SetTrigger("Recto");
        }


        if (acelerando && estable)
        {
            if (!derrapando)
            {
                if (velocidad + aceleracion * Time.deltaTime <= velocidad_maxima)
                {
                    velocidad += aceleracion * Time.deltaTime;
                }
                else
                {
                    velocidad = velocidad_maxima;
                }
            }
            else
            {
                if (buen_derrape)
                {
                    if (velocidad - aceleracion * 0.2f * Time.deltaTime >= 0)
                    {
                        velocidad -= aceleracion * 0.2f * Time.deltaTime;
                    }
                    else
                    {
                        velocidad = 0;
                    }
                }
                else
                {
                    if (velocidad - aceleracion * 4f * Time.deltaTime >= 0)
                    {
                        velocidad -= aceleracion * 4f * Time.deltaTime;
                    }
                    else
                    {
                        velocidad = 0;
                    }
                }
            }
        }
        else
        {
            if (velocidad - aceleracion * 3 * Time.deltaTime >= 0)
            {
                velocidad -= aceleracion * 3 * Time.deltaTime;
            }
            else
            {
                velocidad = 0;
            }
        }

        if (!ia)
        {
            imagen.fillAmount = estabilidad / estabilidad_maxima;
            imagen.color = new Color(1 - estabilidad / estabilidad_maxima, estabilidad / estabilidad_maxima, 0);
        }

    }

    public void Toggle_acelerar(bool acc)
    {
        if (GameControl.instance.gameState==GameState.Race)
        {
            acelerando = acc;
        }
        
    }

    public void Toggle_derrapar(bool acc)
    {
        derrapando = acc;
    }

    public void recuperar_estabilidad()
    {
        if (!estable)
        {
            estabilidad += 5;
        }
    }

    private bool waiteador_derrape = true;

    IEnumerator tipo_derrape(bool tipo)
    {
        if (waiteador_derrape)
        {
            buen_derrape = tipo;
            waiteador_derrape = false;
            yield return new WaitForSeconds(0.2f);

            waiteador_derrape = true;
        }
    }
}