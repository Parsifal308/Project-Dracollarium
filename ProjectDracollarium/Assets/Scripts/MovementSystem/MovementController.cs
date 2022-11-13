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
    [Header("SETTINGS:")]
    [SerializeField] private float horizontalMoveMultiplier = 1;
    [SerializeField] private float frontalMoveMultiplier = 1;

    [SerializeField] private float gravitationalAceleration = -1;
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
    void Update()
    {
        fallingVelocity = CalculateGravity(fallingVelocity, gravitationalAceleration);
        PlayerFall(fallingVelocity);
        if (isMoving) MovePlayer(playerManager.PlayerStats.MovementSpeed);
        RotatePlayer();
    }
    #endregion

    #region METHODS
    public float CalculateGravity(float velocity, float aceleration)
    {
        return velocity + aceleration * Time.deltaTime;
    }

    internal void Moving(InputAction.CallbackContext obj)
    {
        isMoving = true;
    }

    public void PlayerFall(float fallingVelocity)
    {
        characterController.Move(new Vector3(0, fallingVelocity, 0));
    }

    internal void Sprint(InputAction.CallbackContext obj)
    {
        Debug.Log("SPRINT");
    }

    internal void Walk(InputAction.CallbackContext obj)
    {
        Debug.Log("WALK");
    }

    internal void Jump(InputAction.CallbackContext obj)
    {
        Debug.Log("JUMP");
        //throw new NotImplementedException();
    }

    //from old focused movement script
    public void MovePlayer(float speed)
    {
        characterController.Move((characterController.transform.right * playerManager.InputsController.Vertical.ReadValue<float>() * frontalMoveMultiplier + characterController.transform.forward * -playerManager.InputsController.Horizontal.ReadValue<float>() * horizontalMoveMultiplier) * Time.deltaTime * speed);
    }

    //from old focused shoulder camera script
    public void RotatePlayer()
    {
        characterController.transform.rotation = Quaternion.Euler(0f, playerManager.CameraController.PlayerCamera.transform.rotation.eulerAngles.y - 90f, 0f);//sumar o restar despues del y
    }
    #endregion
}
