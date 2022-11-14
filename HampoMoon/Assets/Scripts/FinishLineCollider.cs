using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si la colision es de un coche
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Lap");
            // Envia a GameControl la nueva vuelta
            GameControl.instance.NewLap();
        }
    }
}
