using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manejador_carrera : MonoBehaviour
{

    public GameObject menu;
    public GameObject interfaz;
    public GameObject chasis_fast;
    public GameObject chasis_spooky;
    public GameObject chasis_orange;
    
    public void iniciar()
    {
        menu.SetActive(false);
        interfaz.SetActive(true);
    }

    public void seleccionar_orange()
    {
        chasis_orange.SetActive(true);
        iniciar();
    }
    
    public void seleccionar_spooky()
    {
        chasis_spooky.SetActive(true);
        iniciar();
    }
    
    public void seleccionar_fast()
    {
        chasis_fast.SetActive(true);
        iniciar();
    }
}
