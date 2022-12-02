using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using TMPro;
using UnityEngine;

public class SkalextricInteraction : MonoBehaviour
{
    [SerializeField] private PathFollower coche;
    [SerializeField] private GameObject MandoJugador;
    [SerializeField] private GameObject MandoDisplay;
    [SerializeField] private TextMeshProUGUI textoDebug;

    private bool sujetandoMando = false;

    private void Update()
    {
        if (sujetandoMando)
        {
            if (Input.GetAxis("Seleccionar") > 0f)
            {
                coche.speed = Mathf.Clamp(coche.speed + coche.accel, 0, coche.maxSpeed);
            }
        }
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        CameraPointer.instance.Pointing(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        CameraPointer.instance.Pointing(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerButton()
    {
        sujetandoMando = !sujetandoMando;
        MandoDisplay.SetActive(!sujetandoMando);
        MandoJugador.SetActive(sujetandoMando);
    }
}