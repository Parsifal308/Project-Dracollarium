using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dracollarium.Player;

namespace Dracollarium.Character
{
    public class CharacterAttributesController : MonoBehaviour
    {

        #region FIELDS
        PlayerManager playerManager;
        public event EventHandler OnDeath, OnHitLightAttack;

        [Header("CHARACTER MOVEMENT STATS:"), Space(10)]
        [SerializeField] private float movementSpeed;
        [SerializeField] private float walkSpeedModifier = 1.5f;
        [SerializeField] private float runSpeedModifier = 4f;
        [SerializeField] private float sprintSpeedModifier = 7f;
        [SerializeField] private float combatSpeedModifier = 2f;
        [SerializeField] private float globalSpeedModifier;
        [SerializeField] private float combatSpeedMode = 1f;

        [Header("CHARACTER HEALTH STATS:"), Space(10)]
        [SerializeField] private float maxHealth;
        [SerializeField] private float currentHealth;

        [Header("CHARACTER ATTRIBUTES:"), Space(10)]
        [SerializeField] private float strength;
        [SerializeField] private float volition;
        [SerializeField] private float dextery;
        [SerializeField] private float endurance;
        [SerializeField] private float concentration;

        [Header("TOTAL ATTRIBUTES:"), Space(30)]
        [SerializeField] private float totalStrength;
        [SerializeField] private float totalVolition;
        [SerializeField] private float totalDextery;
        [SerializeField] private float totalEndurance;
        [SerializeField] private float totalConcentration;

        [Header("CHARACTER STATES:"), Space(10)]
        [SerializeField] private bool isDead = false;
        [SerializeField] private bool isGrounded = false;


        #endregion

        #region PROPERTIES
        public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
        public float WalkSpeed { get { return walkSpeedModifier; } set { walkSpeedModifier = value; } }
        public float RunSpeed { get { return runSpeedModifier; } set { runSpeedModifier = value; } }
        public float SprintSpeed { get { return sprintSpeedModifier; } set { sprintSpeedModifier = value; } }
        public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
        public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
        public float CombatSpeed { get { return combatSpeedModifier; } }
        #endregion

        private void Start()
        {
            playerManager = GetComponent<PlayerManager>();
            OnHitLightAttack += playerManager.AnimationsController.HitAttackLight01;
        }

        public void TakeDamage(float dmg)
        {
            currentHealth -= dmg;
            OnHitLightAttack?.Invoke(this, EventArgs.Empty);
            if (currentHealth <= 0)
            {
                isDead = true;
                Debug.Log("PLAYER IS DEAD. GAME OVER");
            }
        }
    }
}