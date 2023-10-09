using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    Button mainMenuButton, quitButton;

    [SerializeField]
    TextMeshProUGUI scoreText, coinsText, timeText;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(OnMainMenuPressed);
        quitButton.onClick.AddListener(OnQuitPressed);

        DisplayScore();
        DisplayCoins();
        DisplayTime();
    }

    public void OnMainMenuPressed()
    {
        LevelLoader.Instance.LoadLevel(0);
    }

    public void OnQuitPressed()
    {
        LevelLoader.Instance.QuitGame();
    }

    void DisplayScore()
    {
        scoreText.text = "Score - " + GameManager.Instance.Score;
    }

    void DisplayCoins()
    {
        coinsText.text = "Coins - " + GameManager.Instance.Coins;
    }

    void DisplayTime()
    {
        float timePlayed = GameManager.Instance.TimePlayed;
        int minutes = (int)(timePlayed / 60);
        int seconds = (int)(timePlayed % 60);

        timeText.text = "Time - " + minutes + " : " + seconds;
    }
}
