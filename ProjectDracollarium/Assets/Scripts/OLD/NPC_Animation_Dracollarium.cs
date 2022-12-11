using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character
{

    /*  ======================================================================
     *  Clase que controla el animator del NPC, provee metodos que se
     *  subscriben a los diferentes metodos del componente controlador de 
     *  comportamientos
     *  ====================================================================== */
    public class NPC_Animation_Dracollarium : MonoBehaviour
    {
        [SerializeField] NPC_Controller npc_Controller;
        [SerializeField] Animator animator;

        public Animator Animator { get { return animator; } }
        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
            npc_Controller = GetComponent<NPC_Controller>();
        }

        internal void Walk(object sender, EventArgs e)
        {
            animator.SetBool("isWalking", true);
        }

        internal void Sprint(object sender, EventArgs e)
        {
            animator.SetBool("isSprinting", true);
        }
        public void Run(object sender, EventArgs e)
        {
            animator.SetBool("isRunning", true);
        }
        public void SetMovementZ(float movement)
        {
            animator.SetFloat("MovementZ", movement);
            if (movement == 0)
            {
                animator.SetBool("isMoving", false);
            }
            else
            {
                animator.SetBool("isMoving", true);
            }
        }
        public void Idle(object sender, EventArgs e)
        {
            animator.SetBool("isMoving", true);
        }
        public void LightAttackD1(object sender, EventArgs e)
        {
            animator.SetInteger("AttackDirection", 1);
        }
        public void LightAttackD3(object sender, EventArgs e)
        {
            animator.SetInteger("AttackDirection", 3);
        }
        public void LightAttack(object sender, EventArgs e)
        {
            animator.SetBool("Attack", true);
            npc_Controller.Equipment.RightHand.GetComponent<Weapon_Detection>().IsDoingDamage = true;
        }
        public void CombatMode(object sender, EventArgs e)
        {
            animator.SetBool("CombatMode", true);
        }
        public void OutOfCombat(object sender, EventArgs e)
        {
            animator.SetBool("CombatMode", false);
            animator.SetBool("Attack", false);
            npc_Controller.Equipment.RightHand.GetComponent<Weapon_Detection>().IsDoingDamage = false;
        }
        public void HitLightAttack_01(object sender, EventArgs e)
        {
            animator.SetBool("Hit", true);
            animator.SetBool("Hit_LightAttack", true);
        }
    }
}