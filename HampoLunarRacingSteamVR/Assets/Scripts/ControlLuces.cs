using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLuces : MonoBehaviour
{
    [SerializeField] private Light luzD;
    [SerializeField] private Light luzI;

    public void toggleLuces()
    {
        luzD.gameObject.SetActive(!luzD.gameObject.activeSelf);
        luzI.gameObject.SetActive(!luzI.gameObject.activeSelf);
    }
}