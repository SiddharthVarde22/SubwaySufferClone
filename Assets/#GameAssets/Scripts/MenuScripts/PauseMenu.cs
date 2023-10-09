using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Button resumeButton, quitButton;

    private void Start()
    {
        resumeButton.onClick.AddListener(OnResumePressed);
        quitButton.onClick.AddListener(OnQuitPressed);
    }

    public void OnResumePressed()
    {
        LevelManager.Instance.OnPausePressed();
    }

    public void OnQuitPressed()
    {
        LevelLoader.Instance.QuitGame();
    }
}
