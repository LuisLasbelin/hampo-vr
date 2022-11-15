using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    private float stringTime;
    public float totalTime;
    public Text text;

    private float minutes;
    private float seconds;

    // Start is called before the first frame update
    private void Start()
    {
        stringTime = totalTime;
    }
    private void Update()
    {
        totalTime -= Time.deltaTime;
        minutes = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);
      //  text.text = minutes.ToString() + ":" + seconds.ToString();

        if (totalTime < 0)
        {
            //text.text = "00";
        }
    }
}
