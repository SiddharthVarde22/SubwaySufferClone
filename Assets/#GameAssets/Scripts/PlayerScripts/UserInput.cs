using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    PlayerAnimations playerAnimations;
    //PlayerMovements playerMovements;

    float horizontalInput, verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        //playerMovements = GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeHorizontalInput();
        TakeVerticalInput();
        TakePauseInput();
    }

    void OnJumpPressed()
    {
        //make player jump
        playerAnimations.SetJumpTrigger();
        playerAnimations.SetIsInAirBool(true);
    }

    void TakeHorizontalInput()
    {
        if(Input.GetButtonDown("Horizontal"))
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput > 0)
            {
                OnRightPressed();
            }
            else if (horizontalInput < 0)
            {
                OnLeftPressed();
            }
        }
    }

    void TakeVerticalInput()
    {
        if(Input.GetButtonDown("Vertical"))
        {
            verticalInput = Input.GetAxisRaw("Vertical");

            if (verticalInput > 0)
            {
                OnJumpPressed();
            }
            else if (verticalInput < 0)
            {
                OnSlidePressed();
            }
        }
    }

    void OnSlidePressed()
    {
        //make player slide
        playerAnimations.SetSlideTrigger();
    }

    void OnLeftPressed()
    {
        //make player move left if can
        playerAnimations.SetLeftTrigger();
    }

    void OnRightPressed()
    {
        //make player move right if can
        playerAnimations.SetRightTrigger();
    }

    void TakePauseInput()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            //pause the game
            LevelManager.Instance.OnPausePressed();
        }
    }
}
