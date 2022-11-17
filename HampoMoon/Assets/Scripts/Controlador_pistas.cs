using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;

public class Controlador_pistas : MonoBehaviour
{
    public GameObject[] pistas;
    public int pista_seleccionada;

    [SerializeField] private Seguir_camino seguidor_de_caminos;

    [SerializeField] private Image placeholder_imagen_pista;
    [SerializeField] private Sprite[] Imagenes_pistas;

    public bool Seleccionada;
    
    private Controlador_escena_selector escenaSelector;
    
    
    public void seleccionar_pista(int i)
    {
        escenaSelector = FindObjectOfType<Controlador_escena_selector>();
        Seleccionada = true;
        pista_seleccionada = i;
        //seguidor_de_caminos.pathCreator = pistas[pista_seleccionada].GetComponentInChildren<PathCreator>();
        placeholder_imagen_pista.sprite = Imagenes_pistas[pista_seleccionada];
        
        escenaSelector.cuando_inicia_carrera += cargar_pista;

        
    }
    
    public void cargar_pista()
    {
        pistas[pista_seleccionada].SetActive(true);
        
    }
}
