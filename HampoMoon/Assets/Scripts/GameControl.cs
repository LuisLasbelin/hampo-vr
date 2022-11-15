using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameState gameState;
    public string gameUiScene = "GameUI";
    public string currLapName = "CurrLap";
    Image currLapImage;
    public string maxLapsName = "MaxLaps";
    Image maxLapsImage;
    public Sprite[] lapsNums;

    public int laps = 0;
    public int maxLaps = 5;

    void Awake()
    {
        // Asegura que solo hay 1
        instance = this;
        SceneManager.LoadScene(gameUiScene, LoadSceneMode.Additive);
    }

    private void Start()
    {
        currLapImage = GameObject.Find(currLapName).GetComponent<Image>();
        currLapImage.sprite = lapsNums[0];

        maxLapsImage = GameObject.Find(maxLapsName).GetComponent<Image>();
        maxLapsImage.sprite = lapsNums[maxLaps];
    }

    public void NewLap()
    {
        laps++;

        currLapImage.sprite = lapsNums[laps];

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