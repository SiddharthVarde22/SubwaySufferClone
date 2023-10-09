using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    public int Score { get; private set; }
    public int Coins { get; private set; }
    public float TimePlayed { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void OnGameOver(int score, int coins, float timePlayed)
    {
        this.Score = score;
        this.Coins = coins;
        this.TimePlayed = timePlayed;

        LevelLoader.Instance.LoadNextLevel();
    }
}
