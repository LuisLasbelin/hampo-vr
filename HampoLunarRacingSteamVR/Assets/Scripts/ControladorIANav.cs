using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorIANav : MonoBehaviour
{
    private CocheBase cocheBase;
    private NavMeshAgent agente;
    private ControladorCarrera controladorCarrera;

    // Start is called before the first frame update
    void Start()
    {
        cocheBase = GetComponent<CocheBase>();
        controladorCarrera = FindObjectOfType<ControladorCarrera>();
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controladorCarrera.CarreraEmpezada)
        {
            agente.SetDestination(controladorCarrera.Checkpoints[cocheBase.CheckpointActual].transform.position);
        }
    }
}