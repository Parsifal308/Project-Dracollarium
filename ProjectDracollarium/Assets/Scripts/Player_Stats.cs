using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {

    #region FIELDS
    [SerializeField] Controller_PlayerManager controller;
    public event EventHandler OnDeath,OnHitLightAttack;

    [Header("CHARACTER MOVEMENT STATS:"), Space(10)]
    [SerializeField] private float walkSpeed =1.5f;
    [SerializeField] private float runSpeed = 4f;
    [SerializeField] private float sprintSpeed =7f;
    [SerializeField] private float combatSpeed = 2f;
    [SerializeField] private float speedsModifier;
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


    #endregion

    #region PROPERTIES
    public float WalkSpeed { get { return walkSpeed; } set { walkSpeed = value; } }
    public float RunSpeed { get { return runSpeed; } set { runSpeed = value; } }
    public float SprintSpeed { get { return sprintSpeed; } set { sprintSpeed = value; } }
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
    public float CombatSpeed { get { return combatSpeed; } }
    #endregion

    private void Start()
    {
        controller = GetComponent<Controller_PlayerManager>();
        OnHitLightAttack += controller.PlayerDracollariumAnimation.HitAttackLight01;
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
