using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;

public class Controlador_coches : MonoBehaviour
{
    [SerializeField] private GameObject[] coches;
    private int coche_seleccionado;


    [SerializeField] private Image placeholder_imagen_coche; 
    [SerializeField] private Sprite[] Imagenes_coches;

    private Controlador_escena_selector escenaSelector;
    
    public bool Seleccionada;

    private void Start()
    {
        escenaSelector = FindObjectOfType<Controlador_escena_selector>();
        escenaSelector.cuando_inicia_carrera += cargar_coche;
    }

    public void seleccionar_coche(int i)
    {
        Seleccionada = true;
        coche_seleccionado = i;
        placeholder_imagen_coche.sprite = Imagenes_coches[coche_seleccionado];
    }

    public void cargar_coche()
    {
        coches[coche_seleccionado].SetActive(true);
    }
}
