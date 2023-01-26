using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Dracollarium.Player;

namespace Dracollarium.Input
{
    public class PlayerActions_CharacterMovement : MonoBehaviour
    {
        #region FIELDS
        private PlayerManager playerManager;

        private PlayerActions playerActions;

        private InputAction vertical;
        private InputAction horizontal;
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
            playerManager = transform.GetComponent<PlayerManager>();
        }
        private void OnEnable()
        {
            vertical = playerActions.PlayerCharacterMovement.Vertical;
            horizontal = playerActions.PlayerCharacterMovement.Horizontal;
            jump = playerActions.PlayerCharacterMovement.Jump;
            run = playerActions.PlayerCharacterMovement.Run;
            walk = playerActions.PlayerCharacterMovement.Walk;
            mouseDelta = playerActions.PlayerCharacterMovement.MouseDelta;
            mousePosition = playerActions.PlayerCharacterMovement.MousePosition;

            vertical.Enable();
            jump.Enable();
            run.Enable();
            walk.Enable();
            mouseDelta.Enable();
            mousePosition.Enable();

            vertical.performed += playerManager.MovementController.Moving;
            vertical.canceled += playerManager.MovementController.Moving;
            vertical.started += playerManager.PlayerItemPickup.DisableCanvases;
            jump.performed += playerManager.MovementController.Jump;
            run.performed += playerManager.MovementController.Sprint;
            run.canceled += playerManager.MovementController.Sprint;
            walk.performed += playerManager.MovementController.Walk;
            walk.canceled += playerManager.MovementController.Walk;

        }
        private void OnDisable()
        {
            vertical.Disable();
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
}