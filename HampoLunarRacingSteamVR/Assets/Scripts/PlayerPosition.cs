using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{

    GameObject player;

    public Transform playerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        // Lo hace hijo y lo coloca en su centro
        player.transform.SetParent(playerSpawn);
        player.transform.position = playerSpawn.position;
    }
}
