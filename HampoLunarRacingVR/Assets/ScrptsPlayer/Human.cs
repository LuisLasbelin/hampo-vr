using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Player
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
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
            base.frenar(rb,vector);
        }
        //acelerar
        if (Input.GetKey(KeyCode.UpArrow))
        {
            base.acelerar(rb, vector);
        }
        //derrapar
        if (Input.GetKey(KeyCode.Space))
        {
            base.derrapar(rb, vector);
        }
        //girar
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            base.girar(rb, vector,"LEFT");
        }
        //girar
        if (Input.GetKey(KeyCode.RightArrow))
        {
            base.girar(rb, vector, "RIGTH");
        }
    }
}
