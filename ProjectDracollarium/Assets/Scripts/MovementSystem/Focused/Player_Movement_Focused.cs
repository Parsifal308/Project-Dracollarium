using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement_Focused : MonoBehaviour , IMovement{

    #region FIELDS
    private PlayerManager playerGlobalController;
    public event EventHandler OnPlayerMovement;
    private CharacterController characterController;
    private Vector2 moveInput;
    [SerializeField] private float gravity;
    private float horizontalMoveMultiplier = 1;
    private float frontalMoveMultiplier = 1;
    [SerializeField] private float dashSpeed= 4;
    private bool isMoving;
    private bool isRunning;
    private bool isSprinting;
    private bool isWalking;
    private bool isCombating;

    [SerializeField] private float dashDuration;
    private bool isDashing;

    #endregion

    #region PROPERTIES
    public bool IsDashing { get { return isDashing; } set { isDashing = value; } }
    public bool IsMoving { get { return isMoving; } }
    public bool IsRunning { get { return isRunning; } }
    public bool IsSprinting { get { return isSprinting; } }
    public bool IsWalking { get { return isWalking; } }
    public bool IsCombating { get { return isCombating; } set { isCombating = value; } }
    public Vector2 MoveInput { get { return moveInput; } }
    public CharacterController CharacterController { get { return characterController; } }

    #endregion
    #region UNITY METHODS
    private void Start(){
        playerGlobalController = transform.GetComponent<PlayerManager>();
        characterController = transform.GetComponentInChildren<CharacterController>();
        OnPlayerMovement += playerGlobalController.PlayerDracollariumAnimation.SetMovementAnim;
        OnPlayerMovement += playerGlobalController.PlayerDracollariumAnimation.SetMovementInput;
    }

    private void Update(){
        gravity -= 9.81f * Time.deltaTime;
        characterController.Move(new Vector3(0, gravity, 0));
        if (moveInput != Vector2.zero){
            isMoving = true;
            if (isCombating)
            {
                Movement(playerGlobalController.PlayerStats.CombatSpeed);
            }
            else if (isWalking)
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
        if (isDashing)
        {
            StartCoroutine(DashDuration());
            StartCoroutine(DashMovement());
            characterController.Move((characterController.transform.right * dashSpeed) * Time.deltaTime * (speed));
            Rotation();
            OnPlayerMovement?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            characterController.Move((characterController.transform.right * (moveInput.y) * frontalMoveMultiplier + characterController.transform.forward * (-moveInput.x) * horizontalMoveMultiplier) * Time.deltaTime * speed);
            Rotation();
            OnPlayerMovement?.Invoke(this, EventArgs.Empty);
        }

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

    IEnumerator DashDuration()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
    IEnumerator DashMovement()
    {
        horizontalMoveMultiplier = 0;
        frontalMoveMultiplier = 0;
        yield return new WaitForSeconds(dashDuration*5);
        horizontalMoveMultiplier = 1;
        frontalMoveMultiplier = 1;
    }
}
