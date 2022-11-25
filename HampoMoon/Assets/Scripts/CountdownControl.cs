using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownControl : MonoBehaviour
{
    public float timeBetween = 0.75f;
    public int number = 3;
    public bool counting = false;
    float currTime = 0;
    public int currNumber = 0;

    public Sprite[] numSprites;
    //Image numImage;

    public Action cuando_llegue_a_zero;

    private void Start()
    {
        counting = false;
        currTime = timeBetween;
        currNumber = number;

        //numImage = GameObject.Find(numImageUiName).GetComponent<Image>();
    }

    private void Update()
    {
        if (GameControl.instance.gameState == GameState.Countdown)
        {
            counting = true;
        }

        if (counting)
        {
            if (currTime > 0) currTime -= Time.deltaTime;
            else
            {
                currTime = timeBetween;
                currNumber -= 1;
                // numImage.sprite = numSprites[currNumber];
                // Debug.Log("Count: " + currNumber);
            }
        }

        if (counting && currNumber <= 0)
        {
            GameControl.instance.UpdateGameState(GameState.Race);
            counting = false;
            
            cuando_llegue_a_zero?.Invoke();
            
        }
    }


}