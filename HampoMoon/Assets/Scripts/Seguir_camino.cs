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

    public float velocidad;
    public float velocidad_maxima;
    public float aceleracion;

    public float estabilidad;
    public float estabilidad_maxima;

    public Animator rueda_derecha;
    public Animator rueda_iquierda;

    public Image imagen;

    private float distancia_recorrida;

    private bool estable;
    public GameObject boton_estabilidad;
    public bool acelerando;


    // Start is called before the first frame update
    void Start()
    {
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
        float rotacion_alterada = Mathf.Abs(rotacion_relativa * 80);

        if (rotacion_alterada > 1 && rotacion_alterada < 50)
        {
            Debug.Log(rotacion_alterada);
            rueda_derecha.SetTrigger("Derecha");
            rueda_iquierda.SetTrigger("Derecha");
            if (estabilidad - rotacion_alterada < 0)
            {
                estable = false;
                boton_estabilidad.SetActive(true);
                estabilidad = 0;
            }else
            {
                estabilidad -= rotacion_alterada;
            }
            
        }
        else
        {
            if (estabilidad + 1 * Time.deltaTime > 100)
            {
                estable = true;
                boton_estabilidad.SetActive(false);
            }
            else
            {
                estabilidad += 10 * Time.deltaTime;
            }
        }


        if (acelerando && estable)
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
            if (velocidad - aceleracion * 5 * Time.deltaTime >= 0)
            {
                velocidad -= aceleracion * 5 * Time.deltaTime;
            }
            else
            {
                velocidad = 0;
            }
        }


        imagen.fillAmount = estabilidad / 100;
        imagen.color = new Color(1 - estabilidad / 100, estabilidad / 100, 0);
    }

    public void Toggle_acelerar(bool acc)
    {
        acelerando = acc;
        Debug.Log("shit");
    }

    public void recuperar_estabilidad()
    {
        if (!estable)
        {
            estabilidad += 5;
        }
    }
}