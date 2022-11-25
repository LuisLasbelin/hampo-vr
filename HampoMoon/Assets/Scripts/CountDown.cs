using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    private float stringTime;
    public float totalTime;
    public float offset;

    public GameObject threeImageUi;
    public GameObject twoImageUi;
    public GameObject oneImageUi;
    public GameObject startImageUi;

    private float minutes;
    private float seconds;

    // Start is called before the first frame update
    private void Start()
    {
        stringTime = totalTime;
        twoImageUi.SetActive(false);
        threeImageUi.SetActive(false);
        oneImageUi.SetActive(false);

    }
    private void Update()
    {
        totalTime += Time.deltaTime;
        minutes = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);
        
        if (totalTime > offset + 0 && totalTime < offset+1)
        {
           // Debug.Log("3");
            threeImageUi.SetActive(true);
        }
        if (totalTime > offset + 1 && totalTime < offset + 2)
        {
         //   Debug.Log("2");
            threeImageUi.SetActive(false);
            twoImageUi.SetActive(true);

        }
        if (totalTime > offset + 2 && totalTime < offset + 3)
        {
            twoImageUi.SetActive(false);
            oneImageUi.SetActive(true);
            //Debug.Log("1");

        }
        if (totalTime > offset + 3 && totalTime < offset + 5)
        {
            oneImageUi.SetActive(false);
            startImageUi.SetActive(true);
            //Debug.Log("START");
        }
        else { 
            startImageUi.SetActive(false);
        }
    }
}
