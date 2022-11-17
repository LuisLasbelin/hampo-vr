using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controlador_interfaz : MonoBehaviour
{
    //[SerializeField] private GameObject Interfaz_carrera;
    [SerializeField] private GameObject Interfaz_seleccion;
    [SerializeField] private GameObject Interfaz_pausa;
    [SerializeField] private Button boton_iniciar_carrera;

    public string mainMenu;
    // Start is called before the first frame update

    private Controlador_escena_selector escenaSelector;

    private void Start()
    {
        
        escenaSelector = FindObjectOfType<Controlador_escena_selector>();
        Interfaz_pausa.SetActive(false);
        Interfaz_seleccion.SetActive(true);
        //Interfaz_carrera.SetActive(false);
        boton_iniciar_carrera.onClick.AddListener(escenaSelector.iniciar_carrera);
        escenaSelector.cuando_inicia_carrera += iniciar_carrera;
        escenaSelector.cuando_coche_y_pista_seleccionado += habilitar_boton_iniciar_carrera;
    }

    void habilitar_boton_iniciar_carrera()
    {
        boton_iniciar_carrera.GetComponent<Button>().interactable = true;
    }

    public void iniciar_carrera()
    {
        //Interfaz_carrera.SetActive(true);
        Interfaz_seleccion.SetActive(false);
    }


    public void PauseGame()
    {
        GameControl.instance.UpdateGameState(GameState.Paused);
        Interfaz_pausa.SetActive(true);
    }

    public void Continue()
    {
        GameControl.instance.UpdateGameState(GameState.Race);
        Interfaz_pausa.SetActive(false);
    }

    public void Return()
    {
        GameControl.instance.UpdateGameState(GameState.Selecting);
        SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
    }
}