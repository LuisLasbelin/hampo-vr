using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloInteraction : MonoBehaviour
{
    [SerializeField] private GameObject marcaTP;
    [SerializeField] private GameObject jogador;
    private float tiempo = 0f;

    private void Update()
    {
        tiempo += Time.deltaTime;
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
    public void OnPointerButton2(Vector3 punto)
    {
        StartCoroutine(teletrans(punto));
    }

    IEnumerator teletrans(Vector3 punto)
    {
        tiempo = 0f;
        Vector3 prevPose = jogador.transform.position;
        while (tiempo < 0.05f)
        {
            jogador.transform.position = new Vector3(punto.x, jogador.transform.position.y, punto.z);
            yield return null;
        }

        yield break;
    }

    public void OnPointerHold(Vector3 punto)
    {
        marcaTP.transform.position = punto;
    }
}