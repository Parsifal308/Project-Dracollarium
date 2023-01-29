using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dracollarium.Player;
using Dracollarium.Character.Stats;
using Dracollarium.Character.Resources;

namespace Dracollarium.Character
{
    public class CharacterAttributesController : MonoBehaviour
    {

        #region FIELDS
        PlayerManager playerManager;
        public event EventHandler OnDeath, OnHitLightAttack, OnUpdateResources;

        [Header("CHARACTER MOVEMENT STATS:"), Space(10)]
        [SerializeField] private float movementSpeed;
        [SerializeField] private float walkSpeedModifier = 1.5f;
        [SerializeField] private float runSpeedModifier = 4f;
        [SerializeField] private float sprintSpeedModifier = 7f;
        [SerializeField] private float combatSpeedModifier = 2f;
        [SerializeField] private float globalSpeedModifier;
        [SerializeField] private float combatSpeedMode = 1f;

        [Header("CHARACTER RESOURCES:"), Space(10)]
        [SerializeField] private List<CharacterResource> resources;

        [Header("CHARACTER ATTRIBUTES:"), Space(10)]
        [SerializeField] private List<CharacterAttribute> attributes;

        [Header("CHARACTER STATES:"), Space(10)]
        [SerializeField] private bool isDead = false;
        [SerializeField] private CharacterState characterState;
        #endregion

        #region PROPERTIES
        public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
        public float WalkSpeed { get { return walkSpeedModifier; } set { walkSpeedModifier = value; } }
        public float RunSpeed { get { return runSpeedModifier; } set { runSpeedModifier = value; } }
        public float SprintSpeed { get { return sprintSpeedModifier; } set { sprintSpeedModifier = value; } }

        public float CombatSpeed { get { return combatSpeedModifier; } }
        #endregion

        #region UNITY METHODS
        private void Start()
        {
            playerManager = GetComponent<PlayerManager>();
            OnHitLightAttack += playerManager.AnimationsController.HitAttackLight01;
            foreach (CharacterResource resource in resources)
            {
                OnUpdateResources += resource.Update;
            }

            InvokeRepeating("OneSecondTick", 0, 1.0f);
        }

        public void TakeDamage(float dmg)
        {/*
            currentHealth -= dmg;
            OnHitLightAttack?.Invoke(this, EventArgs.Empty);
            if (currentHealth <= 0)
            {
                isDead = true;
                Debug.Log("PLAYER IS DEAD. GAME OVER");
            }
            */
        }

        #endregion

        #region PRIVATE METHODS
        private void OneSecondTick()
        {
            OnUpdateResources?.Invoke(this, EventArgs.Empty);
        }


        #endregion

        #region PUBLIC METHODS
        #endregion
    }
}