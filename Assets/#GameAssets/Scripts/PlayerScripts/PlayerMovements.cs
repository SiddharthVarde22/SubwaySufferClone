using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 5;
    [SerializeField]
    float jumpForce = 5;

    Rigidbody rigidbody;
    [SerializeField]
    CapsuleCollider capsuleColliderPlayer;
    [SerializeField]
    float normalCapsuleColliderheight = 115f, slidingCapsuleColliderHeight = 50;

    [SerializeField]
    LanesToMove currentLane = LanesToMove.Center;

    Vector3 targetDirection = Vector3.zero;
    float targetX = 0;
    bool isMovingInX = false;

    [SerializeField]
    float groundHeight = -0.15f;
    bool isJumping = false;
    bool isImmune = false;
    [SerializeField]
    float immunityTime = 1;

    PlayerAnimations playerAnimations;
    PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.Instance.PlayerTransform = transform;
        rigidbody = GetComponent<Rigidbody>();
        playerAnimations = GetComponent<PlayerAnimations>();
        playerData = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        ResetDirection();
        if (isJumping)
        {
            ResetIsInAir();
        }
        playerData.UpdateScoreText(playerData.DistanceTravelled);
    }

    void MoveForward()
    {
        rigidbody.MovePosition(transform.position + 
            (movementSpeed * Time.deltaTime * (transform.forward + targetDirection)));
    }

    public void MoveLeft()
    {
        currentLane -= 2;
        if(currentLane < LanesToMove.Left)
        {
            currentLane = LanesToMove.Left;
            return;
        }
        targetDirection = transform.right * -1;
        GetNewPositionToMove();
        //Debug.Log(currentLane);
    }

    public void MoveRight()
    {
        currentLane += 2;
        if(currentLane > LanesToMove.Right)
        {
            currentLane = LanesToMove.Right;
            return;
        }
        targetDirection = transform.right;
        GetNewPositionToMove();
        //Debug.Log(currentLane);
    }

    void GetNewPositionToMove()
    {
        targetX = LanePositions.Instance.GetLanePosition(currentLane).x;
        isMovingInX = true;
    }

    void ResetDirection()
    {
        if (!isMovingInX)
        {
            return;
        }

        if(targetDirection == (transform.right * -1))
        {
            if(transform.position.x <= targetX)
            {
                targetDirection = Vector3.zero;
                isMovingInX = false;
                transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if(transform.position.x >= targetX)
            {
                targetDirection = Vector3.zero;
                isMovingInX = false;
                transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
            }
        }
    }

    public void SlideMovementStart()
    {
        capsuleColliderPlayer.height = slidingCapsuleColliderHeight;
        capsuleColliderPlayer.center = new Vector3(0, slidingCapsuleColliderHeight / 2, 0);
    }

    public void SlideMovementStop()
    {
        capsuleColliderPlayer.height = normalCapsuleColliderheight;
        capsuleColliderPlayer.center = new Vector3(0, normalCapsuleColliderheight / 2, 0);
    }

    public void PlayerJump()
    {
        //Debug.Log("Jumping start");
        rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void StartedJumping()
    {
        isJumping = true;
    }

    public void ResetIsInAir()
    {
        if (transform.position.y <= groundHeight)
        {
            isJumping = false;
            playerAnimations.SetIsInAirBool(false);
        }
    }

    public void OnCoinCollected(int points)
    {
        //increase player score / coin count
        playerData.InscreaseCollectedCoins();
        playerData.UpdaCoinsText(playerData.CollectedCoins);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Triggered");
        ICollectable collectable = null;
        ICollidable collidableObstacle = null;

        if (other.TryGetComponent<ICollectable>(out collectable))
        {
            collectable.OnCollected(this);
        }

        if(!isImmune && other.TryGetComponent<ICollidable>(out collidableObstacle))
        {
            //Debug.Log("Got Obstacle");
            collidableObstacle.OnCollided(this);
        }
    }

    public void OnCollidedWithObstacle()
    {
        playerAnimations.SetGetHitTrigger();
        //reduce player life etc.
        playerData.LoseLife();
        playerData.UpdateLifesText(playerData.Lifes);
        MakeImune();
    }

    void MakeImune()
    {
        isImmune = true;
        StartCoroutine(ImmunityTimer());
    }

    IEnumerator ImmunityTimer()
    {
        yield return new WaitForSeconds(immunityTime);
        isImmune = false;
    }
}
