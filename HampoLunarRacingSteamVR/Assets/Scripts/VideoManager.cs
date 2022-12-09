using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public string menuScene = "MenuInicio";

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Seleccionar"))
        {
            SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
        }
    }
}
