using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownControl : MonoBehaviour
{
    public float timeBetween = 0.75f;
    public int number = 3;
    public bool counting = false;
    float currTime = 0;
    float currNumber = 0;

    private void Start()
    {
        counting = false;
        currTime = timeBetween;
        currNumber = number;
    }

    private void Update()
    {

        if (GameControl.instance.gameState == GameState.Countdown)
        {
            counting = true;
        }

        if (counting)
        {
            if(currTime > 0) currTime -= Time.deltaTime;
            else
            {
                currTime = timeBetween;
                currNumber -= 1;
                Debug.Log("Count: " + currNumber);
            }
        }

        if (counting && currNumber <= 0)
        {
            GameControl.instance.UpdateGameState(GameState.Race);
            counting = false;
        }
    }
}
