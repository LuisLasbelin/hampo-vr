using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;

public class Controlador_humano : MonoBehaviour
{
    [SerializeField] private GameObject[] coches;
    
    private Seguir_camino seguidor;

    [SerializeField] private GameObject ui;
    
    private Controlador_pistas controladorPistas;
    private Controlador_coches controladorCoches;
    
    private Controlador_escena_selector escenaSelector;
    private CountdownControl countdownControl;
    private GameControl control;

    [SerializeField] private Image imagen_vueltas;
    [SerializeField] private Image imagen_max_vueltas;
    [SerializeField] private Image imagen_contador;
    
    // Start is called before the first frame update
    void Start()
    {
        escenaSelector = FindObjectOfType<Controlador_escena_selector>();
        countdownControl = FindObjectOfType<CountdownControl>();
        control = FindObjectOfType<GameControl>();
        controladorPistas = FindObjectOfType<Controlador_pistas>();
        controladorCoches = FindObjectOfType<Controlador_coches>();
        seguidor = GetComponent<Seguir_camino>();
        escenaSelector.cuando_inicia_carrera += asignar_path;
        escenaSelector.cuando_inicia_carrera += asignar_path;
        countdownControl.cuando_llegue_a_zero += quitar_cartel;
        ui.SetActive(false);
        
        
        imagen_vueltas.sprite = control.lapsNums[control.laps];

        imagen_max_vueltas.sprite = control.lapsNums[control.maxLaps];
    }

    void quitar_cartel()
    {
        StartCoroutine(quitar_cartel_start(1.5f));
    }
    
    private void Update()
    {
        imagen_contador.sprite = countdownControl.numSprites[countdownControl.currNumber];
        imagen_vueltas.sprite = control.lapsNums[control.laps];
        if (GameControl.instance.gameState == GameState.Race)
        {
            ui.SetActive(true);
        }
    }

    // Update is called once per frame
    public void asignar_path()
    {
        seguidor.pathCreator = controladorPistas.pistas[controladorPistas.pista_seleccionada].GetComponentInChildren<PathCreator>();
        coches[controladorCoches.coche_seleccionado].SetActive(true);
        ui.SetActive(true);
    }
    
    IEnumerator quitar_cartel_start(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        imagen_contador.enabled = false;
    }
}
