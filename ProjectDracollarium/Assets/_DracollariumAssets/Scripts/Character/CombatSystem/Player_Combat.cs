using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dracollarium.Player
{
    public class Player_Combat : MonoBehaviour
    {
        #region FIELDS
        [SerializeField] PlayerManager playerManager;
        [Header("ANIMATION SYSTEM:"), Space(10)]
        private Animator animator;

        private bool combatModeEnabled;
        [SerializeField] private bool isAttacking;
        private int attackDirection;

        [Header("DIRECTION VECTORS:"), Space(10)]
        private Vector2 direction;
        private Vector2 d0 = new Vector2(0, 0);
        private Vector2 d1 = new Vector2(-0.707107f, 0.707107f);
        private Vector2 d2 = new Vector2(0, 1);
        private Vector2 d3 = new Vector2(0.707107f, 0.707107f);
        private Vector2 d4 = new Vector2(-1, 0);
        private Vector2 d5 = new Vector2(0, 0);
        private Vector2 d6 = new Vector2(1, 0);
        private Vector2 d7 = new Vector2(-0.707107f, -0.707107f);
        private Vector2 d8 = new Vector2(0, -1);
        private Vector2 d9 = new Vector2(0.707107f, -0.707107f);

        [Header("COMBAT SETTINGS:"), Space(10)]
        [SerializeField] private float attackDirectionDelay = 0.5f;
        [SerializeField] private float attackDelay = 0.5f;
        [SerializeField] private float attackReset = 0.5f;
        [SerializeField] private float lastAttackTime;
        #endregion

        #region UNITY METHODS
        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
            playerManager = GetComponent<PlayerManager>();
        }
        private void Update()
        {
            if (combatModeEnabled)
            {
                if (Time.time - (lastAttackTime + 0.5f) > attackDelay)
                {
                    animator.SetBool("NextAttack", false);
                    playerManager.PlayerEquipment.RightHand.GetComponent<Weapon_Detection>().IsDoingDamage = false;
                }
            }
        }
        #endregion

        #region METHODS
        internal void LightAttack(InputAction.CallbackContext obj)
        {
            if (combatModeEnabled && Time.time - lastAttackTime >= attackDelay)
            {
                isAttacking = true;
                lastAttackTime = Time.time;
                animator.SetBool("Attack", true);
                animator.SetBool("NextAttack", true);
                //controller_PlayerManager.FocusedMovement.IsDashing = true; //Dash shit
                playerManager.PlayerEquipment.RightHand.GetComponent<Weapon_Detection>().IsDoingDamage = true;

            }
        }
        internal void ResetLightAttack(InputAction.CallbackContext obj)
        {
            animator.SetBool("Attack", false);
        }
        internal void EnterCombatMode(InputAction.CallbackContext obj)
        {
            combatModeEnabled = true;
            animator.SetBool("CombatMode", true);
            playerManager.MovementController.IsCombating = true;
        }
        internal void ResetAttackDirectionZero(InputAction.CallbackContext obj)
        {
            animator.SetInteger("AttackDirection", 0);
        }
        internal void ExitCombatMode(InputAction.CallbackContext obj)
        {
            combatModeEnabled = false;
            animator.SetBool("CombatMode", false);
            playerManager.MovementController.IsCombating = false;
        }
        internal void SetAttackDirection(InputAction.CallbackContext obj)
        {
            direction = obj.ReadValue<Vector2>();
            if (direction == d1)
            {
                animator.SetInteger("AttackDirection", 1);
            }
            else if (direction == d2)
            {
                animator.SetInteger("AttackDirection", 2);
            }
            else if (direction == d3)
            {
                animator.SetInteger("AttackDirection", 3);
            }
            else if (direction == d4)
            {
                animator.SetInteger("AttackDirection", 4);
            }
            else if (direction == d5)
            {
                animator.SetInteger("AttackDirection", 5);
            }
            else if (direction == d6)
            {
                animator.SetInteger("AttackDirection", 6);
            }
            else if (direction == d7)
            {
                animator.SetInteger("AttackDirection", 7);
            }
            else if (direction == d8)
            {
                animator.SetInteger("AttackDirection", 8);
            }
            else if (direction == d9)
            {
                animator.SetInteger("AttackDirection", 9);
            }
        }
        #endregion



        #region COROUTINES
        IEnumerator ResetDirection()
        {
            yield return new WaitForSeconds(attackDirectionDelay);
            animator.SetInteger("AttackDirection", 0);
        }
        IEnumerator ResetAttackTime()
        {
            yield return new WaitForSeconds(attackReset);
            animator.SetBool("Attack", false);
        }
        #endregion
    }
}