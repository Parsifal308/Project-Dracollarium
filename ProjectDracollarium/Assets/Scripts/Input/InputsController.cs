using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
/*
╔═════════════════════════════════════════════════════════════╗
║     This script is in charge of registering the inputs of   ║
║ the Input Actions called PlayerActions. Provides methods    ║
║ to enable and disable the different ActionMaps.             ║
╚═════════════════════════════════════════════════════════════╝
*/
public class InputsController : MonoBehaviour
{
    #region FIELDS
    private bool scriptEnabled;
    [SerializeField] private bool enablePlayerCombatInputs = true;
    [SerializeField] private bool enablePlayerActionsInputs = true;
    [SerializeField] private bool enablePlayerMenuInputs = true;
    [SerializeField] private bool enablePlayerMovementInputs = true;
    [SerializeField] private bool enablePlayerBuildingInputs = true;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private PlayerActions playerActions;
    private InputAction actionA;
    private InputAction actionB;
    private InputAction actionC;
    private InputAction dropLeftItem;
    private InputAction dropRightItem;
    private InputAction grab;
    private InputAction take;
    private InputAction buildVerticalRotation;
    private InputAction buildHorizontalRotation;
    private InputAction buildingCancel;
    private InputAction buildingConfirm;
    private InputAction movement;
    private InputAction jump;
    private InputAction run;
    private InputAction walk;
    private InputAction mouseDelta;
    private InputAction mousePosition;
    private InputAction buildMenu;
    private InputAction characterMenu;
    private InputAction mapMenu;
    private InputAction journeyMenu;
    private InputAction inventoryMenu;
    private InputAction facultiesMenu;
    private InputAction equipmentMenu;
    private InputAction cancelMenu;
    private InputAction attackA;
    private InputAction attackB;
    private InputAction fightMode;
    private InputAction exploreMode;
    private InputAction reload;
    private InputAction aim;
    private InputAction attackDirection;
    #endregion

    #region PROPERTIES
    public bool EnablePlayerCombatInputs { get { return enablePlayerCombatInputs; } set { enablePlayerCombatInputs = value; } }
    public bool EnablePlayerActionsInputs { get { return enablePlayerActionsInputs; } set { enablePlayerActionsInputs = value; } }
    public bool EnablePlayerMenuInputs { get { return enablePlayerMenuInputs; } set { enablePlayerMenuInputs = value; } }
    public bool EnablePlayerMovementInputs { get { return enablePlayerMovementInputs; } set { enablePlayerMovementInputs = value; } }
    public bool EnablePlayerBuildingInputs { get { return enablePlayerBuildingInputs; } set { enablePlayerBuildingInputs = value; } }
    public InputAction ActionA { get { return actionA; } }
    public InputAction ActionB { get { return actionB; } }
    public InputAction ActionC { get { return actionC; } }
    public InputAction DropLeftItem { get { return dropLeftItem; } }
    public InputAction DropRightItem { get { return dropRightItem; } }
    public InputAction Grab { get { return grab; } }
    public InputAction Take { get { return take; } }
    public InputAction BuildVerticalRotation { get { return buildVerticalRotation; } }
    public InputAction BuildHorizontalRotation { get { return buildHorizontalRotation; } }
    public InputAction BuildingCancel { get { return buildingCancel; } }
    public InputAction BuildingConfirm { get { return buildingConfirm; } }
    public InputAction Movement { get { return movement; } }
    public InputAction Jump { get { return jump; } }
    public InputAction Run { get { return run; } }
    public InputAction Walk { get { return walk; } }
    public InputAction MouseDelta { get { return mouseDelta; } }
    public InputAction MousePosition { get { return mousePosition; } }
    public InputAction BuildMenu { get { return buildMenu; } }
    public InputAction CharacterMenu { get { return characterMenu; } }
    public InputAction MapMenu { get { return mapMenu; } }
    public InputAction JourneyMenu { get { return journeyMenu; } }
    public InputAction InventoryMenu { get { return inventoryMenu; } }
    public InputAction FacultiesMenu { get { return facultiesMenu; } }
    public InputAction EquipmentMenu { get { return equipmentMenu; } }
    public InputAction CancelMenu { get { return cancelMenu; } }
    public InputAction AttackA { get { return attackA; } }
    public InputAction AttackB { get { return attackB; } }
    public InputAction FightMode { get { return fightMode; } }
    public InputAction ExploreMode { get { return exploreMode; } }
    public InputAction Reload { get { return reload; } }
    public InputAction Aim { get { return aim; } }
    public InputAction AttackDirection { get { return attackDirection; } }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        playerActions = new PlayerActions();
        playerManager = GetComponent<PlayerManager>();
    }
    private void OnValidate()
    {
        if (scriptEnabled) CheckForChanges();
    }
    private void OnEnable()
    {
        actionA = playerActions.PlayerCharacterAction.ActionA;
        actionB = playerActions.PlayerCharacterAction.ActionB;
        actionC = playerActions.PlayerCharacterAction.ActionC;
        dropLeftItem = playerActions.PlayerCharacterAction.DropLeftItem;
        dropRightItem = playerActions.PlayerCharacterAction.DropRightItem;
        grab = playerActions.PlayerCharacterAction.Grab;
        take = playerActions.PlayerCharacterAction.Take;
        movement = playerActions.PlayerCharacterMovement.Movement;
        jump = playerActions.PlayerCharacterMovement.Jump;
        run = playerActions.PlayerCharacterMovement.Run;
        walk = playerActions.PlayerCharacterMovement.Walk;
        mouseDelta = playerActions.PlayerCharacterMovement.MouseDelta;
        mousePosition = playerActions.PlayerCharacterMovement.MousePosition;
        buildMenu = playerActions.PlayerMenus.BuildMenu;
        characterMenu = playerActions.PlayerMenus.CharacterMenu;
        mapMenu = playerActions.PlayerMenus.MapMenu;
        journeyMenu = playerActions.PlayerMenus.JourneyMenu;
        facultiesMenu = playerActions.PlayerMenus.FacultiesMenu;
        equipmentMenu = playerActions.PlayerMenus.EquipmentMenu;
        cancelMenu = playerActions.PlayerMenus.Cancel;
        attackA = playerActions.PlayerCharacterCombat.AttackA;
        attackB = playerActions.PlayerCharacterCombat.AttackB;
        fightMode = playerActions.PlayerCharacterCombat.FightMode;
        exploreMode = playerActions.PlayerCharacterCombat.ExploreMode;
        reload = playerActions.PlayerCharacterCombat.Reload;
        aim = playerActions.PlayerCharacterCombat.Aim;
        attackDirection = playerActions.PlayerCharacterCombat.AttackDirection;
        buildVerticalRotation = playerActions.PlayerBuilding.VerticalRotation;
        buildHorizontalRotation = playerActions.PlayerBuilding.HorizontalRotation;
        buildingCancel = playerActions.PlayerBuilding.Cancel;
        buildingConfirm = playerActions.PlayerBuilding.LeftClick;

        actionB.performed += playerManager.PlayerItemPickup.ActionB;
        take.performed += playerManager.PlayerItemPickup.Take;
        dropLeftItem.performed += playerManager.PlayerItemPickup.Drop;
        dropRightItem.performed += playerManager.PlayerItemPickup.Drop;
        grab.performed += playerManager.PlayerItemPickup.Grab;
        movement.performed += playerManager.MovementController.Run;
        movement.canceled += playerManager.MovementController.Run;
        movement.started += playerManager.PlayerItemPickup.DisableCanvases;
        jump.performed += playerManager.MovementController.Jump;
        run.performed += playerManager.MovementController.Sprint;
        run.canceled += playerManager.MovementController.Sprint;
        walk.performed += playerManager.MovementController.Walk;
        walk.canceled += playerManager.MovementController.Walk;
        buildMenu.performed += playerManager.UIController.BuildingMenu.MenuKey;
        equipmentMenu.performed += playerManager.UIController.EquipmentMenu.MenuKey;
        cancelMenu.performed += playerManager.UIController.DisableAllMenus;
        attackA.performed += playerManager.PlayerCombat.LightAttack;
        attackA.canceled += playerManager.PlayerCombat.ResetLightAttack;
        fightMode.performed += playerManager.PlayerCombat.EnterCombatMode;
        exploreMode.performed += playerManager.PlayerCombat.ExitCombatMode;
        attackDirection.performed += playerManager.PlayerCombat.SetAttackDirection;
        attackDirection.canceled += playerManager.PlayerCombat.ResetAttackDirectionZero;
        buildVerticalRotation.started += playerManager.PlayerModularBuilding.StartVerticalRotation;
        buildVerticalRotation.canceled += playerManager.PlayerModularBuilding.StopRotation;

        EnableActions();
        EnableBuilding();
        EnableCombat();
        EnableMenu();
        EnableMovement();

        scriptEnabled = true;
    }
    private void OnDisable()
    {
        DisableActions();
        DisableBuilding();
        DisableCombat();
        DisableMenu();
        DisableMovement();
        scriptEnabled = false;
    }
    #endregion

    #region METHODS
    public void EnableActions()
    {
        actionA.Enable();
        actionB.Enable();
        actionC.Enable();
        dropLeftItem.Enable();
        dropRightItem.Enable();
        grab.Enable();
        take.Enable();
    }
    public void DisableActions()
    {
        actionA.Disable();
        actionB.Disable();
        actionC.Disable();
        dropLeftItem.Disable();
        dropRightItem.Disable();
        grab.Disable();
        take.Disable();
    }
    public void EnableMovement()
    {
        movement.Enable();
        jump.Enable();
        run.Enable();
        walk.Enable();
        mouseDelta.Enable();
        mousePosition.Enable();
    }
    public void DisableMovement()
    {
        movement.Disable();
        jump.Disable();
        run.Disable();
        walk.Disable();
        mouseDelta.Disable();
        mousePosition.Disable();
    }
    public void EnableMenu()
    {
        buildMenu.Enable();
        characterMenu.Enable();
        mapMenu.Enable();
        journeyMenu.Enable();
        facultiesMenu.Enable();
        equipmentMenu.Enable();
        cancelMenu.Enable();
    }
    public void DisableMenu()
    {
        buildMenu.Disable();
        characterMenu.Disable();
        mapMenu.Disable();
        journeyMenu.Disable();
        facultiesMenu.Disable();
        equipmentMenu.Disable();
        cancelMenu.Disable();
    }
    public void EnableCombat()
    {
        attackA.Enable();
        attackB.Enable();
        fightMode.Enable();
        exploreMode.Enable();
        aim.Enable();
        reload.Enable();
        attackDirection.Enable();
    }
    public void DisableCombat()
    {
        attackA.Disable();
        attackB.Disable();
        fightMode.Disable();
        exploreMode.Disable();
        aim.Disable();
        reload.Disable();
        attackDirection.Disable();
    }
    public void EnableBuilding()
    {
        buildVerticalRotation.Enable();
        buildHorizontalRotation.Enable();
        buildingCancel.Enable();
        buildingConfirm.Enable();
    }
    public void DisableBuilding()
    {
        buildVerticalRotation.Disable();
        buildHorizontalRotation.Disable();
        buildingCancel.Disable();
        buildingConfirm.Disable();
    }
    public void CheckForChanges()
    {
        if (enablePlayerActionsInputs)
        {
            EnableActions();
        }
        else
        {
            DisableActions();
        }
        if (enablePlayerBuildingInputs)
        {
            EnableBuilding();
        }
        else
        {
            DisableBuilding();
        }
        if (enablePlayerCombatInputs)
        {
            EnableCombat();
        }
        else
        {
            DisableCombat();
        }
        if (enablePlayerMenuInputs)
        {
            EnableMenu();
        }
        else
        {
            DisableMenu();
        }
        if (enablePlayerMovementInputs)
        {
            EnableMovement();
        }
        else
        {
            EnableMovement();
        }
    }
    private void ChangeInput(object sender, EventArgs e)
    {
        CheckForChanges();
    }
    #endregion
}
