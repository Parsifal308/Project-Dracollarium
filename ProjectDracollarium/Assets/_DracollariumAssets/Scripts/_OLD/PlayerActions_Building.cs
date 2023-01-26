using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dracollarium.Player
{
    public class PlayerActions_Building : MonoBehaviour
    {
        #region FIELDS
        private PlayerManager controller_PlayerManager;

        private PlayerActions playerActions;

        private InputAction buildVerticalRotation;
        private InputAction buildHorizontalRotation;
        private InputAction buildingCancel;
        private InputAction buildingConfirm;
        #endregion


        #region PROPERTIES
        public PlayerActions PlayerActions { get { return playerActions; } }
        #endregion
        private void Awake()
        {
            playerActions = new PlayerActions();
            controller_PlayerManager = transform.GetComponent<PlayerManager>();
        }
        private void OnEnable()
        {
            buildVerticalRotation = playerActions.PlayerBuilding.VerticalRotation;
            buildHorizontalRotation = playerActions.PlayerBuilding.HorizontalRotation;
            buildingCancel = playerActions.PlayerBuilding.Cancel;
            buildingConfirm = PlayerActions.PlayerBuilding.LeftClick;

            buildVerticalRotation.Enable();
            buildHorizontalRotation.Enable();
            buildingCancel.Enable();
            buildingConfirm.Enable();

            buildVerticalRotation.started += controller_PlayerManager.PlayerModularBuilding.StartVerticalRotation;
            buildVerticalRotation.canceled += controller_PlayerManager.PlayerModularBuilding.StopRotation;
        }
        private void OnDisable()
        {
            buildVerticalRotation.Disable();
            buildHorizontalRotation.Disable();
            buildingCancel.Disable();
            buildingConfirm.Disable();
        }
    }
}