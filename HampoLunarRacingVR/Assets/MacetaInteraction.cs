using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacetaInteraction : MonoBehaviour
{
    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        Debug.Log("Mirando maceta");

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
    public void OnPointerClick()
    {
        
    }
}
