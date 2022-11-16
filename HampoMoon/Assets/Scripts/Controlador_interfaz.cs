using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador_interfaz : MonoBehaviour
{
    [SerializeField] private GameObject Interfaz_carrera;
    [SerializeField] private GameObject Interfaz_seleccion;
    [SerializeField] private GameObject Interfaz_pausa;
    public string mainMenu;
    // Start is called before the first frame update


    private void Start()
    {
        Interfaz_pausa.SetActive(false);

    }

    public void iniciar_carrera()
    {
        Interfaz_carrera.SetActive(true);
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
