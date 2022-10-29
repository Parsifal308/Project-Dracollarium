using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions_CharacterMovement : MonoBehaviour
{
    #region FIELDS
    private PlayerManager playerGlobalController;

    private PlayerActions playerActions;

    private InputAction movement;
    private InputAction jump;
    private InputAction run;
    private InputAction walk;
    private InputAction mouseDelta;
    private InputAction mousePosition;

    //[SerializeField] private Vector2 mouseDeltaValue;
    //[SerializeField] private Vector2 mousePositionValue;
    #endregion

    #region PROPERTIES
    public PlayerActions PlayerActions { get { return playerActions; } }
    public InputAction MouseDelta { get { return mouseDelta; } }
    #endregion
    private void Awake()
    {
        playerActions = new PlayerActions();
        playerGlobalController = transform.GetComponent<PlayerManager>();
    }
    private void OnEnable(){
        movement = playerActions.PlayerCharacterMovement.Movement;
        jump = playerActions.PlayerCharacterMovement.Jump;
        run = playerActions.PlayerCharacterMovement.Run;
        walk = playerActions.PlayerCharacterMovement.Walk;
        mouseDelta = playerActions.PlayerCharacterMovement.MouseDelta;
        mousePosition = playerActions.PlayerCharacterMovement.MousePosition;

        movement.Enable();
        jump.Enable();
        run.Enable();
        walk.Enable();
        mouseDelta.Enable();
        mousePosition.Enable();

        movement.performed += playerGlobalController.FocusedMovement.Run;
        movement.canceled += playerGlobalController.FocusedMovement.Run;
        movement.started += playerGlobalController.PlayerItemPickup.DisableCanvases;
        jump.performed += playerGlobalController.FocusedMovement.Jump;
        run.performed += playerGlobalController.FocusedMovement.Sprint;
        run.canceled += playerGlobalController.FocusedMovement.Sprint;
        walk.performed += playerGlobalController.FocusedMovement.Walk;
        walk.canceled += playerGlobalController.FocusedMovement.Walk;

    }
    private void OnDisable(){
        movement.Disable();
        jump.Disable();
        run.Disable();
        walk.Disable();
        mouseDelta.Disable();
        mousePosition.Disable();
    }
    /*
    private void Update(){
        mouseDeltaValue = mouseDelta.ReadValue<Vector2>();
        mousePositionValue = mousePosition.ReadValue<Vector2>();

    }
    */
}
