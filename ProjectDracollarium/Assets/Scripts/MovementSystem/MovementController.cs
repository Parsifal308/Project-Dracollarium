using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    #region FIELDS
    private PlayerManager playerManager;
    private CharacterController characterController;

    [SerializeField] private float horizontalMoveMultiplier = 1;
    [SerializeField] private float frontalMoveMultiplier = 1;


    [SerializeField] private float aceleration = -1;
    [Header("CONTROL VARIABLES:")]
    [ShowOnly][SerializeField] private float fallingVelocity; //Cuando este en el suelo hay que reiniciarlo
    [ShowOnly][SerializeField] private bool isMoving;
    [ShowOnly][SerializeField] private bool isRunning;
    [ShowOnly][SerializeField] private bool isSprinting;
    [ShowOnly][SerializeField] private bool isWalking;
    [ShowOnly][SerializeField] private bool isCombating;
    #endregion

    #region PROPERTIES
    public bool IsCombating { get { return isCombating; } set { isCombating = value; } }
    #endregion

    #region UNITY METHODS
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        characterController = transform.GetComponentInChildren<CharacterController>();
    }
    void FixedUpdate()
    {
        fallingVelocity = CalculateGravity(fallingVelocity, aceleration);
        PlayerFall(fallingVelocity);
        MovePlayer(playerManager.PlayerStats.MovementSpeed);
        RotatePlayer();
    }
    #endregion

    #region METHODS
    public float CalculateGravity(float velocity, float aceleration)
    {
        return velocity + aceleration * Time.deltaTime;
    }

    internal void Run(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    public void PlayerFall(float fallingVelocity)
    {
        characterController.Move(new Vector3(0, fallingVelocity, 0));
    }

    internal void Sprint(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    internal void Walk(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    internal void Jump(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    //from old focused movement script
    public void MovePlayer(float speed)
    {
        characterController.Move((characterController.transform.right * (playerManager.InputsController.Movement.ReadValue<Vector2>().y) * frontalMoveMultiplier + characterController.transform.forward * (-playerManager.InputsController.Movement.ReadValue<Vector2>().x) * horizontalMoveMultiplier) * Time.deltaTime * speed);
    }

    //from old focused shoulder camera script
    public void RotatePlayer()
    {
        characterController.transform.rotation = Quaternion.Euler(0f, playerManager.CameraController.PlayerCamera.transform.rotation.eulerAngles.y - 90f, 0f);
    }
    #endregion
}
