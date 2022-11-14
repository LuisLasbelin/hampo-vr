using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;

public class Controlador_pistas : MonoBehaviour
{
    [SerializeField] private GameObject[] pistas;
    private int pista_seleccionada;

    [SerializeField] private Seguir_camino seguidor_de_caminos;

    [SerializeField] private Image placeholder_imagen_pista;
    [SerializeField] private Sprite[] Imagenes_pistas;

    public bool Seleccionada;
    
    public void seleccionar_pista(int i)
    {
        Seleccionada = true;
        pista_seleccionada = i;
        seguidor_de_caminos.pathCreator = pistas[pista_seleccionada].GetComponentInChildren<PathCreator>();
        placeholder_imagen_pista.sprite = Imagenes_pistas[pista_seleccionada];
    }
    
    public void cargar_pista()
    {
        pistas[pista_seleccionada].SetActive(true);
    }
}
