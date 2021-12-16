using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {

    #region FIELDS
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    #endregion

    #region PROPERTIES
    public float WalkSpeed { get { return walkSpeed; } set { walkSpeed = value; } }
    public float RunSpeed { get { return runSpeed; } set { runSpeed = value; } }
    public float SprintSpeed { get { return sprintSpeed; } set { sprintSpeed = value; } }
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
    #endregion
}
