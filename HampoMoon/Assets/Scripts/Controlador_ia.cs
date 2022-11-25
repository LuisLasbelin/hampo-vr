using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Controlador_ia : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (GameControl.instance.gameState == GameState.Race)
        {
            seguidor.acelerando = true;
        }
        else
        {
            seguidor.acelerando = false;
        }
    }

    public void asignar_path_ia()
    {
        seguidor.pathCreator = controladorPistas.pistas[controladorPistas.pista_seleccionada].GetComponentInChildren<PathCreator>();
    }
}
