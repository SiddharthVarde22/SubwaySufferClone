using UnityEngine;

public enum LanesToMove
{
    Left = -2,
    Center = 0,
    Right = 2,
}

public class LanePositions : GenericSingleton<LanePositions>
{
    [SerializeField]
    Vector3 leftPosition, centerPosition, rightPosition;

    public Vector3 GetLanePosition(LanesToMove lane)
    {
        switch(lane)
        {
            case LanesToMove.Left:
                return leftPosition;
            case LanesToMove.Center:
                return centerPosition;
            case LanesToMove.Right:
                return rightPosition;
            default:
                Debug.LogError("Invalid Lane");
                return Vector3.zero;
        }
    }

    public int GetRandomLane()
    {
        int random = Random.Range(-1, 2);
        random *= 2;
        return random;
    }
}