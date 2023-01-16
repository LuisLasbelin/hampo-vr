using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSemaforo : MonoBehaviour
{
    private ControladorCarrera controladorCarrera;

    [SerializeField] private List<GameObject> luces;

    [SerializeField] private Material materialRojo;

    [SerializeField] private Material materialVerde;

    // Start is called before the first frame update
    void Start()
    {
        controladorCarrera = FindObjectOfType<ControladorCarrera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controladorCarrera.timer > 0)
        {
            luces[3 - controladorCarrera.timer].GetComponent<Renderer>().material = materialRojo;
        }
        else
        {
            foreach (GameObject luce in luces)
            {
                luce.GetComponent<Renderer>().material = materialVerde;
            }
            Destroy(this);
        }
    }
}