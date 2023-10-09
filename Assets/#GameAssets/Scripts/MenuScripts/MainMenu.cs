using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button playButton, quitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(OnPlayPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
    }

    public void OnPlayPressed()
    {
        LevelLoader.Instance.LoadNextLevel();
    }

    public void OnQuitPressed()
    {
        LevelLoader.Instance.QuitGame();
    }
}
