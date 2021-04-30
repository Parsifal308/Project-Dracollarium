using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDracollariumAnimation : MonoBehaviour{
    private Animator animator;
    private PlayerManager playerManager;

    public void SetMovementAnimationBoolean(object sender, EventArgs e){
        if (playerManager.PlayerInput.IsMoving)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        if (playerManager.PlayerInput.IsRunning)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    public void SetMovementInput(object sender, EventArgs e)
    {
        animator.SetFloat("MovementX", Mathf.Lerp(animator.GetFloat("MovementX"), playerManager.PlayerInput.MovementInput.x, 0.05f));
        animator.SetFloat("MovementZ", Mathf.Lerp(animator.GetFloat("MovementZ"), playerManager.PlayerInput.MovementInput.z, 0.05f));
    }
    private void Start(){
        animator = GetComponentInChildren<Animator>();
        playerManager = GetComponent<PlayerManager>();
        animator.updateMode = AnimatorUpdateMode.Normal;
    }
}
