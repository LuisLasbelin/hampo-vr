using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartelInteraction : MonoBehaviour
{
    [SerializeField] private Material cartelHover;
    [SerializeField] private Material cartelBase;
    
    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        Debug.Log("Mirando cartel");

        CameraPointer.instance.Pointing(true);
        GetComponent<Renderer>().material = cartelHover;
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        CameraPointer.instance.Pointing(false);
        GetComponent<Renderer>().material = cartelBase;

    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        SceneManager.LoadScene("Pruebas");
    }
}
