using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCarrera : MonoBehaviour
{
    [SerializeField] public List<Checkpoint> Checkpoints;

    public bool CarreraEmpezada;
    public bool CarreraFinalizada;
    public int timer = 3;

    [SerializeField] public int VueltasTotales = 0;

    public List<CocheBase> coches = new List<CocheBase>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (CocheBase cocheBase in FindObjectsOfType<CocheBase>())
        {
            coches.Add(cocheBase);
        }

        for (int i = 0; i < Checkpoints.Count; i++)
        {
            Checkpoints[i].NumeroCheckpoint = i + 1;
        }

        StartCoroutine(delayEmpezarCarrera());
    }

    private void Update()
    {
        string texto = "";

        if (CarreraEmpezada)
        {
            coches[0].posicion = 1;
            for (int i = 0; i < coches.Count; i++)
            {
                for (int j = 0; j < coches.Count; j++)
                {
                    if (i != j)
                    {
                        if (coches[i].CheckpointActual > coches[j].CheckpointActual)
                        {
                            if (coches[i].posicion > coches[j].posicion)
                            {
                                (coches[j].posicion, coches[i].posicion) = (coches[i].posicion, coches[j].posicion);
                            }
                            else if (coches[i].posicion + 1 > coches[j].posicion)
                            {
                                coches[j].posicion = coches[i].posicion + 1;
                            }
                        }
                    }
                }
            }
        }


        foreach (CocheBase coch in coches)
        {
            texto += coch.name + " " + coch.posicion + " ,||";
        }


        Debug.Log(texto);
    }

    public IEnumerator delayEmpezarCarrera()
    {
        CarreraEmpezada = false;
        yield return new WaitForSeconds(0);
        Debug.Log("3");
        timer = 3;
        yield return new WaitForSeconds(1);

        Debug.Log("2");
        timer = 2;

        yield return new WaitForSeconds(1);

        Debug.Log("1");
        timer = 1;

        yield return new WaitForSeconds(1);

        Debug.Log("GO");
        timer = 0;

        CarreraEmpezada = true;
        yield return null;
    }
}