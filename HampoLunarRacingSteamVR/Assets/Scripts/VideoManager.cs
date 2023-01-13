using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class VideoManager : MonoBehaviour
{
    public string menuScene = "MenuInicio";
    public SteamVR_Action_Boolean exitAction;


    // Update is called once per frame
    void Update()
    {
        if(exitAction.state)
        {
            SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
        }
    }
}
