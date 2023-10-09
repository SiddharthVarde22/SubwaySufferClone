using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ICollidable
{
    public void OnCollided(PlayerMovements playerMovements)
    {
        playerMovements.OnCollidedWithObstacle();
    }
}
