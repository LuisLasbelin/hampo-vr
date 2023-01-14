using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCarrera : MonoBehaviour
{
    [SerializeField] private List<Checkpoint> Checkpoints;

    public int CheckpointActual = 0;
    public int VueltaActual = 0;
    [SerializeField] int VueltasTotales = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Checkpoint checkpoint in Checkpoints)
        {
            checkpoint.CheckponitPasado += ActualizarCheckpoint;
        }
        Debug.Log(Checkpoints.Count);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ActualizarCheckpoint(int check)
    {
        if (check != (CheckpointActual + 1)) return;
        CheckpointActual = check;
        
        if (CheckpointActual < Checkpoints.Count) return;
        ActualizarVuelta();
        CheckpointActual = 0;
    }

    public void ActualizarVuelta()
    {
        VueltaActual++;
        if (VueltaActual == VueltasTotales)
        {
            Debug.Log("Se fini");
        }
    }
}