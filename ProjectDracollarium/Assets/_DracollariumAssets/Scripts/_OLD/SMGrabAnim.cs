using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGrabAnim : StateMachineBehaviour
{
    [SerializeField] private string animationBoolName;
    public event EventHandler OnAnimMiddle;
    private bool grabbed = false;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
            animator.SetBool(animationBoolName, false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && !grabbed){
            grabbed = true;
            Debug.Log("animacion a la mitad");
        }
    }
}
