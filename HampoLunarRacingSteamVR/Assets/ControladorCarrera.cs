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

    public Dictionary<CocheBase, int> coches = new Dictionary<CocheBase, int>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (CocheBase cocheBase in FindObjectsOfType<CocheBase>())
        {
            coches.Add(cocheBase, cocheBase.CheckpointActual);
        }

        StartCoroutine(delayEmpezarCarrera());
    }

    private void Update()
    {
        string texto = "";

        Dictionary<CocheBase, int> updCoches = new Dictionary<CocheBase, int>();

        foreach (KeyValuePair<CocheBase, int> coch in coches)
        {
            updCoches.Add(coch.Key, coch.Key.CheckpointActual);
            texto += coch.Key.name + " " + coch.Value + " ,";
        }

        coches.Clear();
        coches = updCoches;
        
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