using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 offsetPosition, rotation;

    Transform playerTransform;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        FollowPlayerPosition();
        SetRotaion(rotation);
    }

    private void LateUpdate()
    {
        FollowPlayerPosition();
    }

    void FollowPlayerPosition()
    {
        if(playerTransform == null)
        {
            playerTransform = LevelManager.Instance.PlayerTransform;
        }

        targetPosition.x = offsetPosition.x;
        targetPosition.y = offsetPosition.y;
        targetPosition.z = playerTransform.position.z + offsetPosition.z;

        transform.position = targetPosition;
    }

    void SetRotaion(Vector3 eulerRotation)
    {
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
