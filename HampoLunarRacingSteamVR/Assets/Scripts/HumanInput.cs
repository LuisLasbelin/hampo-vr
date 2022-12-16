using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HumanInput : MonoBehaviour
{
    Rigidbody rb;
    CocheBase coche;
    public CircularDrive circularDrive;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        coche = gameObject.GetComponent<CocheBase>();
    }

    // Update is called once per frame
    void Update()
    {
        float h, v;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 vector = new Vector3(h, 0.5f, v);

        //frenar
        if (Input.GetKey(KeyCode.DownArrow))
        {
            coche.frenar(rb, vector);
        }
        //acelerar
        if (Input.GetKey(KeyCode.UpArrow))
        {
            coche.acelerar(rb, vector);
        }
        //derrapar
        if (Input.GetKey(KeyCode.Space))
        {
            coche.derrapar(rb, vector);
        }

        coche.girar(circularDrive.outAngle);
    }
}