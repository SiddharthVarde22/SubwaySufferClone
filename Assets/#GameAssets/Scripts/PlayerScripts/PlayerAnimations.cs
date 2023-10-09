using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator playerAnimator;
    [SerializeField]
    string slidingParameterName, jumpParamName, leftParamName, rightParamName, isInAirParamName, getHitParamName;

    int slidingParamId, jumpParamId, leftParamId, rightParamId, isInAirParamId, getHitParamId;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        TakeParametersIds();
    }

    void TakeParametersIds()
    {
        slidingParamId = Animator.StringToHash(slidingParameterName);
        jumpParamId = Animator.StringToHash(jumpParamName);
        leftParamId = Animator.StringToHash(leftParamName);
        rightParamId = Animator.StringToHash(rightParamName);
        isInAirParamId = Animator.StringToHash(isInAirParamName);
        getHitParamId = Animator.StringToHash(getHitParamName);
    }

    public void SetSlideTrigger()
    {
        playerAnimator.SetTrigger(slidingParamId);
    }

    public void SetLeftTrigger()
    {
        playerAnimator.SetTrigger(leftParamId);
    }

    public void SetRightTrigger()
    {
        playerAnimator.SetTrigger(rightParamId);
    }

    public void SetJumpTrigger()
    {
        playerAnimator.SetTrigger(jumpParamId);
    }

    public void SetIsInAirBool(bool value)
    {
        playerAnimator.SetBool(isInAirParamId, value);
    }

    public void SetGetHitTrigger()
    {
        playerAnimator.SetTrigger(getHitParamId);
    }
}
