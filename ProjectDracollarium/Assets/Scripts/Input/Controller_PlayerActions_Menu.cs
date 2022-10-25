using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller_PlayerActions_Menu : MonoBehaviour
{
    #region FIELDS
    private Controller_PlayerManager playerGlobalController;

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
    private void Awake(){
        playerActions = new PlayerActions();
        playerGlobalController = transform.GetComponent<Controller_PlayerManager>();
    }
    private void OnEnable(){
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

        buildMenu.performed += playerGlobalController.BuildingMenu.MenuKey;
        equipmentMenu.performed += playerGlobalController.EquipmentMenu.MenuKey;
        cancelMenu.performed += playerGlobalController.DisableAllMenus;
    }
    private void OnDisable(){
        buildMenu.Disable();
        characterMenu.Disable();
        mapMenu.Disable();
        journeyMenu.Disable();
        facultiesMenu.Disable();
        equipmentMenu.Disable();
        cancelMenu.Disable();
    }
}
