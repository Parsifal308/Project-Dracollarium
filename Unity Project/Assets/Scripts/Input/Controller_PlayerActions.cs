using UnityEngine;
using UnityEngine.InputSystem;

public class Controller_PlayerActions : MonoBehaviour{

    #region FIELDS
    private Controller_PlayerManager playerGlobalController;

    private PlayerActions playerActions;

    private InputAction movement;
    private InputAction jump;
    private InputAction run;
    private InputAction walk;
    private InputAction actionA;
    private InputAction actionB;

    private InputAction buildMenu;
    private InputAction characterMenu;
    private InputAction mapMenu;
    private InputAction journeyMenu;
    private InputAction inventoryMenu;
    private InputAction facultiesMenu;
    private InputAction equipmentMenu;

    private InputAction mouseDelta;
    private InputAction mousePosition;

    private InputAction buildVerticalRotation;
    private InputAction buildHorizontalRotation;
    private InputAction buildingCancel;

    [SerializeField] private Vector2 mouseDeltaValue;
    [SerializeField] private Vector2 mousePositionValue;
    #endregion

    #region PROPERTIES
    public PlayerActions PlayerActions { get { return playerActions; } }
    public InputAction ActionA { get { return actionA; } }
    public InputAction MouseDelta { get { return mouseDelta; } }
    #endregion

    #region UNITY METHODS
    private void Awake(){
        playerActions = new PlayerActions();
        playerGlobalController = GetComponent<Controller_PlayerManager>();
    }

    private void OnEnable(){
        movement = playerActions.PlayerCharacterMovement.Movement;
        jump = playerActions.PlayerCharacterMovement.Jump;
        run = playerActions.PlayerCharacterMovement.Run;
        walk = playerActions.PlayerCharacterMovement.Walk;
        mouseDelta = playerActions.PlayerCharacterMovement.MouseDelta;
        mousePosition = playerActions.PlayerCharacterMovement.MousePosition;

        actionA = playerActions.PlayerCharacterAction.ActionA;
        actionB = playerActions.PlayerCharacterAction.ActionB;

        buildMenu = playerActions.PlayerMenus.BuildMenu;
        characterMenu = playerActions.PlayerMenus.CharacterMenu;
        mapMenu = playerActions.PlayerMenus.MapMenu;
        journeyMenu = playerActions.PlayerMenus.JourneyMenu;
        facultiesMenu = playerActions.PlayerMenus.FacultiesMenu;
        equipmentMenu = playerActions.PlayerMenus.EquipmentMenu;

        buildVerticalRotation = playerActions.PlayerBuilding.VerticalRotation;
        buildHorizontalRotation = playerActions.PlayerBuilding.HorizontalRotation;
        buildingCancel = playerActions.PlayerBuilding.Cancel;

        movement.Enable();
        jump.Enable();
        run.Enable();
        walk.Enable();
        mouseDelta.Enable();
        mousePosition.Enable();
        actionA.Enable();
        actionB.Enable();
        buildMenu.Enable();
        characterMenu.Enable();
        mapMenu.Enable();
        journeyMenu.Enable();
        facultiesMenu.Enable();
        equipmentMenu.Enable();
        buildVerticalRotation.Enable();
        buildHorizontalRotation.Enable();
        buildingCancel.Enable();

        movement.performed += playerGlobalController.FocusedMovement.Run;
        movement.canceled += playerGlobalController.FocusedMovement.Run;
        movement.started += playerGlobalController.PlayerItemPickup.DisableCanvases;
        jump.performed += playerGlobalController.FocusedMovement.Jump;
        run.performed += playerGlobalController.FocusedMovement.Sprint;
        run.canceled += playerGlobalController.FocusedMovement.Sprint;
        walk.performed += playerGlobalController.FocusedMovement.Walk;
        walk.canceled += playerGlobalController.FocusedMovement.Walk;
        mouseDelta.performed += playerGlobalController.FocusedLookCam.MouseDelta;

        mousePosition.performed += playerGlobalController.FocusedLookCam.MousePosition;
        actionA.performed += playerGlobalController.PlayerItemPickup.ActionA;
        actionB.performed += playerGlobalController.PlayerItemPickup.ActionB;
        buildMenu.performed += playerGlobalController.BuildingMenu.MenuKey;
        equipmentMenu.performed += playerGlobalController.EquipmentMenu.MenuKey;
    }


    private void OnDisable(){
        movement.Disable();
        jump.Disable();
        run.Disable();
        walk.Disable();
        mouseDelta.Disable();
        mousePosition.Disable();
        actionA.Disable();
        actionB.Disable();
        buildMenu.Disable();
        characterMenu.Disable();
        mapMenu.Disable();
        journeyMenu.Disable();
        facultiesMenu.Disable();
        equipmentMenu.Disable();
        buildVerticalRotation.Disable();
        buildHorizontalRotation.Disable();
        buildingCancel.Disable();
    }
    #endregion

    private void Update()
    {
        mouseDeltaValue =  mouseDelta.ReadValue<Vector2>();
        mousePositionValue = mousePosition.ReadValue<Vector2>();

    }
}

