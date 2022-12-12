using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int aceleradorMultiplier = 0;
    public int frenarMultiplier = 0;
    public int girarMultiplier = 0;
    public int derraparMultiplier = 0;
    float x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    virtual public void acelerar(Rigidbody rb, Vector3 v)
    {
        rb.AddForce(v* aceleradorMultiplier*Time.deltaTime);
        Debug.Log("acelerar");

    }

    virtual public void frenar(Rigidbody rb,Vector3 v)
    {
        Debug.Log("frenar");
        rb.AddForce(v * -frenarMultiplier * Time.deltaTime);

    }

    virtual public void derrapar(Rigidbody rb, Vector3 v)
    {
        Debug.Log("derrapar");
    }

    virtual public void girar(Rigidbody rb, Vector3 v,string direction)
    {
        if (direction  == "LEFT")
        {
            Debug.Log("Left");

            x += Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(x, 0, 0);

        }
        else if (direction == "RIGHT")
        {
            Debug.Log("Right");

            x -= Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(x, 0, 0);
        }
        else
        {
            Debug.LogError("direccion de giro no estipulada");
        }
    }
}
