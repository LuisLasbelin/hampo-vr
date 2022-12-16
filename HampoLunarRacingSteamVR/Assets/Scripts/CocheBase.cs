using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CocheBase : MonoBehaviour
{
    public Coche coche;

    public Transform[] ruedasGiro;

    // Start is called before the first frame update
    void Start()
    {

    }

    virtual public void acelerar(Rigidbody rb, Vector3 v)
    {
        rb.AddForce(v * coche.factorAceleracion * Time.deltaTime);
        Debug.Log("acelerar");

    }

    virtual public void frenar(Rigidbody rb, Vector3 v)
    {
        Debug.Log("frenar");
        rb.AddForce(v * -coche.factorFreno * Time.deltaTime);

    }

    virtual public void derrapar(Rigidbody rb, Vector3 v)
    {
        Debug.Log("derrapar");
    }

    virtual public void girar(float angle)
    {
        foreach (var rueda in ruedasGiro)
        {
            rueda.rotation = Quaternion.Euler(rueda.rotation.x, angle, rueda.rotation.z);
        }
    }
}