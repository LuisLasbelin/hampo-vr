using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HumanInput : MonoBehaviour
{
    CocheBase controlCoche;
    public Coche coche;

    public SteamVR_Action_Boolean acelerado;

    // Start is called before the first frame update
    void Start()
    {
        controlCoche = gameObject.GetComponent<CocheBase>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controlCoche.Accelerate(acelerado.state, coche.factorAceleracion);
    }
}