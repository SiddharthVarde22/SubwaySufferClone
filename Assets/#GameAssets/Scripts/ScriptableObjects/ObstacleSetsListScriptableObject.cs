using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleSetsList", menuName = "ScriptableObjects/ObstacleSetsList")]
public class ObstacleSetsListScriptableObject : ScriptableObject
{
    public Transform[] obstacleSetsList;
}
