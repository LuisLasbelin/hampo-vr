using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] public int NumeroCheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CocheBase>())
        {

            other.gameObject.GetComponent<CocheBase>().cruzarCheckpoint(NumeroCheckpoint);
        }
    }
}