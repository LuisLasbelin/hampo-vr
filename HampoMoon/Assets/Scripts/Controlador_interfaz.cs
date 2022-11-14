using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_interfaz : MonoBehaviour
{
    [SerializeField] private GameObject Interfaz_carrera;
    [SerializeField] private GameObject Interfaz_seleccion;
    // Start is called before the first frame update



    public void iniciar_carrera()
    {
        Interfaz_carrera.SetActive(true);
        Interfaz_seleccion.SetActive(false);
    }
}
