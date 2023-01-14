using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int NumeroCheckpoint;
    public Action<int> CheckponitPasado;
    private void OnTriggerEnter(Collider other)
    {
        CheckponitPasado?.Invoke(NumeroCheckpoint);
    }
}
