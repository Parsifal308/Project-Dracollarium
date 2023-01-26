using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Dracollarium.Player;

namespace Dracollarium.Input
{
    public class PlayerActions_Menu : MonoBehaviour
    {
        #region FIELDS
        private PlayerManager playerManager;

        private PlayerActions playerActions;

        private InputAction buildMenu;
        private InputAction characterMenu;
        private InputAction mapMenu;
        private InputAction journeyMenu;
        private InputAction inventoryMenu;
        private InputAction facultiesMenu;
        private InputAction equipmentMenu;
        private InputAction cancelMenu;
        #endregion

        #region PROPERTIES
        public PlayerActions PlayerActions { get { return playerActions; } }
        #endregion
        private void Awake()
        {
            playerActions = new PlayerActions();
            playerManager = transform.GetComponent<PlayerManager>();
        }
        private void OnEnable()
        {
            buildMenu = playerActions.PlayerMenus.BuildMenu;
            characterMenu = playerActions.PlayerMenus.CharacterMenu;
            mapMenu = playerActions.PlayerMenus.MapMenu;
            journeyMenu = playerActions.PlayerMenus.JourneyMenu;
            facultiesMenu = playerActions.PlayerMenus.FacultiesMenu;
            equipmentMenu = playerActions.PlayerMenus.EquipmentMenu;
            cancelMenu = playerActions.PlayerMenus.Cancel;

            buildMenu.Enable();
            characterMenu.Enable();
            mapMenu.Enable();
            journeyMenu.Enable();
            facultiesMenu.Enable();
            equipmentMenu.Enable();
            cancelMenu.Enable();

            //buildMenu.performed += playerManager.UIController.BuildingMenu.MenuKey;
            //equipmentMenu.performed += playerManager.UIController.EquipmentMenu.MenuKey;
            //cancelMenu.performed += playerManager.UIController.DisableAllMenus;
        }
        private void OnDisable()
        {
            buildMenu.Disable();
            characterMenu.Disable();
            mapMenu.Disable();
            journeyMenu.Disable();
            facultiesMenu.Disable();
            equipmentMenu.Disable();
            cancelMenu.Disable();
        }
    }
}