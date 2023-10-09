using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField]
    int pointsToGetWhenCollected = 1;

    public void OnCollected(PlayerMovements refrenceToPlayer)
    {
        refrenceToPlayer.OnCoinCollected(pointsToGetWhenCollected);
        Destroy(gameObject);
    }
}
