using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vb_anim : MonoBehaviour
{
    public GameObject myVbBtnObj;
    UnityEngine.Video.VideoPlayer v;

    // Start is called before the first frame update
    void Start()
    {
        myVbBtnObj = GameObject.Find("MyButton");
        myVbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnMyButtonPressed);
        myVbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnMyButtonReleased);

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("BTN Presionado");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("BTN Soltado");
    }

    public void OnMyButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("MYBTN Presionado");
    }

    public void OnMyButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("MYBTN Soltado");

    }
    // Update is called once per frame
    void Update()
    {

    }
}
