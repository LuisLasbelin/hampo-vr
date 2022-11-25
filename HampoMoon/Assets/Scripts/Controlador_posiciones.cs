using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class Controlador_posiciones : MonoBehaviour
{
    public Seguir_camino[] coches;

    // Start is called before the first frame update
    void Start()
    {
        coches = FindObjectsOfType<Seguir_camino>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < coches.Length; i++)
        {
            for (int j = 0; j < coches.Length; j++)
            {
                if (i != j)
                { if (coches[i].distancia_recorrida > coches[j].distancia_recorrida)
                    {
                        if (coches[i].pos > coches[j].pos)
                        {
                            (coches[j].pos, coches[i].pos) = (coches[i].pos, coches[j].pos);
                        }
                        else if (coches[i].pos + 1 > coches[j].pos)
                        {
                            coches[j].pos = coches[i].pos + 1;
                        }
                    }
                }
            }
        }
    }
}