using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using UnityEngine.SceneManagement;

public class InterfaceControls : MonoBehaviour
{

    private VideoPlayer videoPlayer;


    public GameObject menuContainer;
    public GameObject selector_pista;
    public GameObject videoUiContainer;
    public GameObject mainUiContainer;
    public GameObject instructionsUiContainer;
    public Button introButton;
    public Button videoButton;
    public Sprite[] playStopImages;
    public Button exitVideoButton;
    public Button exitInstructionsButton;
    public Button gameButton;
    public Button instructionsButton;
    public string gameSceneReal;
    public string gameSceneGTI;
    public string gameSceneArco;

    // Start is called before the first frame update
    void Start()
    {
        // Valores por defecto de los contenedores de menus
        menuContainer.SetActive(true);
        videoUiContainer.SetActive(false);
        instructionsUiContainer.SetActive(false);
        mainUiContainer.SetActive(true);
        // Video
        videoPlayer = GameObject.FindObjectOfType<VideoPlayer>();
        videoButton.image.sprite = playStopImages[0];
        // Inactivo por defecto
        videoPlayer.gameObject.SetActive(false);

        // botones
        videoButton.onClick.AddListener(PlayVideo);
        exitVideoButton.onClick.AddListener(ReturnToMenu);
        exitInstructionsButton.onClick.AddListener(ReturnToMenu);
        introButton.onClick.AddListener(OpenVideoMenu);
        gameButton.onClick.AddListener(OpenGame);
        instructionsButton.onClick.AddListener(OpenInstrucMenu);
    }

    void OpenGame()
    {
        mainUiContainer.SetActive(false);
        selector_pista.SetActive(true);
    }
    
    public void seleccionar_gti()
    {
        SceneManager.LoadScene(gameSceneGTI, LoadSceneMode.Single);
    }
    
    public void seleccionar_real()
    {
        SceneManager.LoadScene(gameSceneReal, LoadSceneMode.Single);
    }
    
    public void seleccionar_arco()
    {
        SceneManager.LoadScene(gameSceneArco, LoadSceneMode.Single);
    }

    void PlayVideo()
    {
        videoPlayer.gameObject.SetActive(true);
        if (videoPlayer) videoPlayer.Play();
        videoButton.image.sprite = playStopImages[1];
        videoButton.image.color = Color.red;
        videoButton.onClick.AddListener(StopVideo);
    }

    void StopVideo()
    {
        if (videoPlayer) videoPlayer.Pause();

        videoButton.image.sprite = playStopImages[0];

        videoButton.image.color = Color.green;
        videoButton.onClick.AddListener(PlayVideo);
    }
    void ReturnToMenu()
    {
        videoUiContainer.SetActive(false);
        videoPlayer.Stop();
        videoPlayer.gameObject.SetActive(false);
        instructionsUiContainer.SetActive(false);
        mainUiContainer.SetActive(true);
    }

    void OpenVideoMenu()
    {
        videoUiContainer.SetActive(true);
        mainUiContainer.SetActive(false);
    }

    void OpenInstrucMenu()
    {
        instructionsUiContainer.SetActive(true);
        mainUiContainer.SetActive(false);
    }
}
