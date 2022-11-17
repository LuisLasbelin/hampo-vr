using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si la colision es de un coche
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Lap");
            // Envia a GameControl la nueva vuelta
            if (other.gameObject.GetComponentInParent<Seguir_camino>()!=null)
            {
                //Debug.Log("Lap22");
                other.gameObject.GetComponentInParent<Seguir_camino>().NewLap();
            }
        }
    }
}
