using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameState gameState;


    public int laps = 0;
    public int maxLaps = 5;

    void Awake()
    {
        // Asegura que solo hay 1
        instance = this;
    }
    
    public void NewLap()
    {
        laps++;

        // Al llegar al maximo de vueltas se termina la carrera
        if (laps >= maxLaps) UpdateGameState(GameState.EndRace);
    }

    /**
     * Update game state
     */
    public void UpdateGameState(GameState newState)
    {
        gameState = newState;

        switch (newState)
        {
            case GameState.SelectedBoth:
                break;
            case GameState.SelectedCar:
                break;
            case GameState.SelectedCircuit:
                break;
            case GameState.Countdown:
                break;
            case GameState.Race:
                Debug.Log("Race start");
                break;
            case GameState.EndRace:
                Debug.Log("Race ended");
                break;
        }
    }

    
}

public enum GameState
{
    SelectedBoth,
    SelectedCar,
    SelectedCircuit,
    Countdown,
    Race,
    EndRace
}