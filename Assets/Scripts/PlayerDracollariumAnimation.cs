using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDracollariumAnimation : MonoBehaviour{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInput input;
       public void SetMovementAnimationBoolean(object sender, EventArgs e){
           if (input.IsMoving){
               animator.SetBool("isMoving", true);
           }
           else{
               animator.SetBool("isMoving", false);
           }
           if (input.IsRunning) {
               animator.SetBool("isRunning", true);
           }
           else{
               animator.SetBool("isRunning", false);
           }
       }   
    private void Start(){
        animator = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInput>();
        animator.updateMode = AnimatorUpdateMode.Normal;
    }
}
