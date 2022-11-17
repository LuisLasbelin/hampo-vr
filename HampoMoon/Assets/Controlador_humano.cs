using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Controlador_humano : MonoBehaviour
{
    
    private Seguir_camino seguidor;

    private Controlador_pistas controladorPistas;
    
    private Controlador_escena_selector escenaSelector;
    
    // Start is called before the first frame update
    void Start()
    {
        escenaSelector = FindObjectOfType<Controlador_escena_selector>();
        controladorPistas = FindObjectOfType<Controlador_pistas>();
        seguidor = GetComponent<Seguir_camino>();
        seguidor.ia = true;
        seguidor.acelerando = false;
        escenaSelector.cuando_inicia_carrera += asignar_path_ia;
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    public void asignar_path_ia()
    {
        seguidor.pathCreator = controladorPistas.pistas[controladorPistas.pista_seleccionada].GetComponentInChildren<PathCreator>();
    }
}
