using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HumanInput : MonoBehaviour
{
    CocheBase controlCoche;
    public Coche coche;

    public SteamVR_Action_Boolean acelerado;
    private ControladorCarrera controladorCarrera;

    [SerializeField] private GameObject menuFinalCarrera;
    [SerializeField] private TextMeshProUGUI textoPose;

    // Start is called before the first frame update
    void Start()
    {
        controladorCarrera = FindObjectOfType<ControladorCarrera>();
        controlCoche = gameObject.GetComponent<CocheBase>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controladorCarrera.CarreraEmpezada)
        {
            controlCoche.Accelerate(acelerado.state, coche.factorAceleracion);
        }

        menuFinalCarrera.SetActive(controladorCarrera.CarreraFinalizada);
    }
}