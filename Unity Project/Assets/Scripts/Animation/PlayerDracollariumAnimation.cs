using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDracollariumAnimation : MonoBehaviour{
    #region FIELDS
    private Animator animator;
    private Controller_PlayerManager playerGlobalController;
    #endregion
    #region ANIMATION METHODS
    public void SetMovementAnim(object sender, EventArgs e){
        if ((sender as IMovement).IsMoving){
            animator.SetBool("isMoving", true);
        }else{
            animator.SetBool("isMoving", false);
        }
        if ((sender as IMovement).IsSprinting)
        {
            animator.SetBool("isSprinting", true);
        }
        else
        {
            animator.SetBool("isSprinting", false);
        }
        if ((sender as IMovement).IsWalking)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if ((sender as IMovement).IsRunning)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void SetGrabbingAnim(object sender, EventArgs e){
        animator.SetBool("isGrabbing", true);
    }

    #endregion

    #region MOVEMENT METHODS
    public void SetMovementInput(object sender, EventArgs e){
        animator.SetFloat("MovementX", Mathf.Lerp(animator.GetFloat("MovementX"), (sender as IMovement).MoveInput.x, 0.05f));
        animator.SetFloat("MovementZ", Mathf.Lerp(animator.GetFloat("MovementZ"), (sender as IMovement).MoveInput.y, 0.05f));
    }

    #endregion

    #region UnityMethods
    private void Start(){
        animator = GetComponentInChildren<Animator>();
        playerGlobalController = GetComponent<Controller_PlayerManager>();
        animator.updateMode = AnimatorUpdateMode.Normal;
    }
    #endregion
}
