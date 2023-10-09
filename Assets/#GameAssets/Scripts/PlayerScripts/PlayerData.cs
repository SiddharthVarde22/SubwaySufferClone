using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText, coinsText, lifesText;

    public int DistanceTravelled { get; private set; }
    public int CollectedCoins { get; private set; }
    public int Lifes { get; private set; }
    public float TimeTaken { get; private set; }

    float startingZPosition;
    void Awake()
    {
        startingZPosition = transform.position.z;
        Lifes = 3;
        DistanceTravelled = 0;
        CollectedCoins = 0;

        UpdateScoreText(DistanceTravelled);
        UpdateLifesText(Lifes);
        UpdaCoinsText(CollectedCoins);
    }

    public void CalculateDistance()
    {
        DistanceTravelled = (int)(transform.position.z - startingZPosition);
    }

    private void Update()
    {
        TimeTaken += Time.deltaTime;
        CalculateDistance();
    }

    public void LoseLife()
    {
        Lifes--;
        if(Lifes <= 0)
        {
            //Set game over
            GameManager.Instance.OnGameOver(DistanceTravelled, CollectedCoins, TimeTaken);
            //Debug.Log(TimeTaken);
        }
    }

    public void InscreaseCollectedCoins()
    {
        CollectedCoins++;
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void UpdateLifesText(int lifes)
    {
        lifesText.text = "Lives : " + lifes.ToString();
    }

    public void UpdaCoinsText(int collectedCoins)
    {
        coinsText.text = "Coins : " + collectedCoins.ToString();
    }

    public void IncreaseTimeTaken()
    {
        TimeTaken += Time.deltaTime;
    }
}
