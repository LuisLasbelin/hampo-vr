using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class InterfaceControls : MonoBehaviour
{

    private Button videoButton;
    private TextMeshProUGUI videoButtonText;
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GameObject.FindObjectOfType<VideoPlayer>();

        videoButton = GameObject.Find("VideoButton").GetComponent<Button>();
        videoButtonText = videoButton.GetComponentInChildren<TextMeshProUGUI>();
        videoButton.onClick.AddListener(PlayVideo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayVideo()
    {
        if (videoPlayer) videoPlayer.Play();
        videoButtonText.text = "Stop";
        videoButton.image.color = Color.red;
        videoButton.onClick.AddListener(StopVideo);
    }

    void StopVideo()
    {
        if (videoPlayer) videoPlayer.Stop();
        videoButtonText.text = "Play";
        videoButton.image.color = Color.green;
        videoButton.onClick.AddListener(PlayVideo);
    }
}
