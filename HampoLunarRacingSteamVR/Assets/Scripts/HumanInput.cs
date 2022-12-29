using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HumanInput : MonoBehaviour
{
    CocheBase coche;
    public CircularDrive circularDrive;
    // Start is called before the first frame update
    void Start()
    {
        coche = gameObject.GetComponent<CocheBase>();
    }

    // Update is called once per frame
    void Update()
    {
        //frenar
        if (Input.GetKey(KeyCode.DownArrow))
        {
            coche.frenar();
        }
        //acelerar
        if (Input.GetKey(KeyCode.UpArrow))
        {
            coche.acelerar();
        }
        //derrapar
        if (Input.GetKey(KeyCode.Space))
        {
            coche.derrapar();
        }

        coche.girar(circularDrive.outAngle);
    }
}