using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement_Focused : MonoBehaviour , IMovement{

    #region FIELDS
    private Controller_PlayerManager playerGlobalController;
    public event EventHandler OnPlayerMovement;
    private CharacterController characterController;
    private Vector2 moveInput;
    private bool isMoving;
    private bool isRunning;
    private bool isSprinting;
    private bool isWalking;

    #endregion

    #region PROPERTIES
    public bool IsMoving { get { return isMoving; } }
    public bool IsRunning { get { return isRunning; } }
    public bool IsSprinting { get { return isSprinting; } }
    public bool IsWalking { get { return isWalking; } }
    public Vector2 MoveInput { get { return moveInput; } }
    public CharacterController CharacterController { get { return characterController; } }

    #endregion
    #region UNITY METHODS
    private void Start(){
        playerGlobalController = transform.GetComponent<Controller_PlayerManager>();
        characterController = transform.GetComponentInChildren<CharacterController>();
        OnPlayerMovement += playerGlobalController.PlayerDracollariumAnimation.SetMovementAnim;
        OnPlayerMovement += playerGlobalController.PlayerDracollariumAnimation.SetMovementInput;
    }

    private void Update(){
        if (moveInput != Vector2.zero){
            isMoving = true;

            if (isWalking)
            {
                Movement(playerGlobalController.PlayerStats.WalkSpeed);
            }
            else if (isSprinting)
            {
                Movement(playerGlobalController.PlayerStats.SprintSpeed);
            }
            else if (isRunning)
            {
                Movement(playerGlobalController.PlayerStats.RunSpeed);
            }
        }
        else{
            isMoving = false;
            Movement(0f);
        }
    }
    #endregion

    #region METHODS
    public void Movement(float speed){
        characterController.Move((characterController.transform.right * moveInput.y + characterController.transform.forward * (-moveInput.x)) * Time.deltaTime * speed);
        Rotation();
        OnPlayerMovement?.Invoke(this, EventArgs.Empty);    //Si los subscriptores del evento no son nulos, entonces se dispara dicho metodo.
    }
    public void Rotation(){
        characterController.transform.rotation = Quaternion.Euler(0f, playerGlobalController.FocusedLookCam.Camera.transform.rotation.eulerAngles.y - 90f, 0f);
    }
    #endregion

    #region INPUT METHODS
    public void Jump(InputAction.CallbackContext obj){
        throw new NotImplementedException();
    }
    public void Run(InputAction.CallbackContext obj){ //Movement mode by default
        if (obj.performed)
        {
            moveInput = obj.ReadValue<Vector2>();
            isRunning = true;
        }
        if (obj.canceled)
        {
            moveInput = obj.ReadValue<Vector2>();
            isRunning = false;
        }

    }
    public void Sprint(InputAction.CallbackContext obj){
        if (obj.canceled){
            isSprinting = false;
        }
        else{
            isSprinting = true;
        }
    }

    public void Walk(InputAction.CallbackContext obj){
        if (obj.performed)
        {
            isWalking = true;
        }
        if (obj.canceled)
        {
            isWalking = false;
        }
    }
    #endregion


}
