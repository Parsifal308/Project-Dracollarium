using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Hit : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {

            animator.SetBool("Hit", false);
            animator.SetBool("Hit_LightAttack", false);
        }
    }
}
