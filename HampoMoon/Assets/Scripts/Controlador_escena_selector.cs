using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador_escena_selector : MonoBehaviour
{
    [SerializeField] private Button boton_iniciar_carrera;
    [SerializeField] private Controlador_coches _controladorCoches;
    [SerializeField] private Controlador_pistas _controladorPistas;
    [SerializeField] private Controlador_interfaz _controladorInterfaz;
    // Start is called before the first frame update
    void Start()
    {
        boton_iniciar_carrera.onClick.AddListener(iniciar_carrera);

        // Countdown start
        GameControl.instance.UpdateGameState(GameState.Countdown);
    }
    
    void Update()
    {
        if (_controladorCoches && _controladorInterfaz)
        {
            boton_iniciar_carrera.GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void iniciar_carrera()
    {
        _controladorCoches.cargar_coche();
        _controladorInterfaz.iniciar_carrera();
        _controladorPistas.cargar_pista();
    }
}
