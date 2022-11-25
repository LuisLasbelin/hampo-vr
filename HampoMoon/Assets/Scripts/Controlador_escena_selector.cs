using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Controlador_escena_selector : MonoBehaviour
{
    
    public Action cuando_inicia_carrera;
    public Action cuando_coche_y_pista_seleccionado;

    private Controlador_pistas ControladorPistas;
    private Controlador_coches ControladorCoches;
    
    // Start is called before the first frame update

    private void Start()
    {
        ControladorPistas = FindObjectOfType<Controlador_pistas>();
        ControladorCoches = FindObjectOfType<Controlador_coches>();
    }

    void Update()
    {
        
        if (ControladorPistas.Seleccionada && ControladorCoches.Seleccionada)
        {
            cuando_coche_y_pista_seleccionado?.Invoke();
            
        }
    }

    // Update is called once per frame
    public void iniciar_carrera()
    {
        cuando_inicia_carrera?.Invoke();
        // Countdown start
        GameControl.instance.UpdateGameState(GameState.Countdown);
    }
}