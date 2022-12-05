using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VueltaMenu : MonoBehaviour
{
    [SerializeField] private string escenaACargar;

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
        SceneManager.LoadScene(escenaACargar);
    }

    public void OnPointerButton2()
    {
    }

    public void OnPointerHold()
    {
    }
}
