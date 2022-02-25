using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {

    #region FIELDS
    [Header("CHARACTER MOVEMENT STATS:"), Space(10)]
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed;
    [SerializeField] private float sprintSpeed;
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

    #endregion

    #region PROPERTIES
    public float WalkSpeed { get { return walkSpeed; } set { walkSpeed = value; } }
    public float RunSpeed { get { return runSpeed; } set { runSpeed = value; } }
    public float SprintSpeed { get { return sprintSpeed; } set { sprintSpeed = value; } }
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
    #endregion
}
