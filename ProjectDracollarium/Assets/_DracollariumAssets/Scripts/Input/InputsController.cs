using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Dracollarium.Player;

namespace Dracollarium.Input
{
    /*
    ╔═════════════════════════════════════════════════════════════╗
    ║     This script is in charge of registering the inputs of   ║
    ║ the Input Actions called PlayerActions. Provides methods    ║
    ║ to enable and disable the different ActionMaps and to       ║
    ║ show the inputs values.                                     ║
    ╚═════════════════════════════════════════════════════════════╝
    */
    public class InputsController : MonoBehaviour
    {
        #region FIELDS
        private bool scriptInitialized = false;

        [Header("INPUTS ACTIONS MANAGEMENT:")]
        [Tooltip("Enable/disable the player combat inputs.")]
        [SerializeField] private bool enablePlayerCombatInputs;
        [Tooltip("Enable/disable the player actions inputs.")]
        [SerializeField] private bool enablePlayerActionsInputs;
        [Tooltip("Enable/disable the player menu inputs.")]
        [SerializeField] private bool enablePlayerMenuInputs;
        [Tooltip("Enable/disable the player movement inputs.")]
        [SerializeField] private bool enablePlayerMovementInputs;
        [Tooltip("Enable/disable the player building inputs.")]
        [SerializeField] private bool enablePlayerBuildingInputs;

        [Space(10), Header("DEBUG:")]
        [SerializeField] private bool debugLogging = true;
        private PlayerManager playerManager;
        private PlayerActions playerActions;
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
        private InputAction vertical;
        private InputAction horizontal;
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

        #region CONTROL FIELDS
        [Space(15), Header("INPUTS VALUES:")]
        [Tooltip("Select if want to read and show inputs in real time. Only kepp enabled while developing.")]
        [SerializeField] private bool readInputs = false;
        [Space(10)]
        [ShowOnly][SerializeField] private float actionAValue;
        [ShowOnly][SerializeField] private float actionBValue;
        [ShowOnly][SerializeField] private float actionCValue;
        [ShowOnly][SerializeField] private float dropLeftItemValue;
        [ShowOnly][SerializeField] private float dropRightItemValue;
        [ShowOnly][SerializeField] private float grabValue;
        [ShowOnly][SerializeField] private float takeValue;
        [Space(10)]
        [ShowOnly][SerializeField] private float buildVerticalRotationValue;
        [ShowOnly][SerializeField] private float buildHorizontalRotationValue;
        [ShowOnly][SerializeField] private float buildingCancelValue;
        [ShowOnly][SerializeField] private float buildingConfirmValue;
        [Space(10)]
        [ShowOnly][SerializeField] private float horizontalValue;
        [ShowOnly][SerializeField] private float verticalValue;
        [Space(10)]
        [ShowOnly][SerializeField] private float jumpValue;
        [ShowOnly][SerializeField] private float runValue;
        [ShowOnly][SerializeField] private float walkValue;
        [Space(10)]
        [ShowOnly][SerializeField] private float mouseDeltaXValue;
        [ShowOnly][SerializeField] private float mouseDeltaYValue;
        [Space(5)]
        [ShowOnly][SerializeField] private float mousePositionXValue;
        [ShowOnly][SerializeField] private float mousePositionYValue;
        [Space(10)]
        [ShowOnly][SerializeField] private float buildMenuValue;
        [ShowOnly][SerializeField] private float characterMenuValue;
        [ShowOnly][SerializeField] private float mapMenuValue;
        [ShowOnly][SerializeField] private float journeyMenuValue;
        [ShowOnly][SerializeField] private float inventoryMenuValue;
        [ShowOnly][SerializeField] private float facultiesMenuValue;
        [ShowOnly][SerializeField] private float equipmentMenuValue;
        [ShowOnly][SerializeField] private float cancelMenuValue;
        [Space(10)]
        [ShowOnly][SerializeField] private float attackAValue;
        [ShowOnly][SerializeField] private float attackBValue;
        [ShowOnly][SerializeField] private float fightModeValue;
        [ShowOnly][SerializeField] private float exploreModeValue;
        [ShowOnly][SerializeField] private float reloadValue;
        [ShowOnly][SerializeField] private float aimValue;
        [Space(5)]
        [ShowOnly][SerializeField] private float attackDirectionXValue;
        [ShowOnly][SerializeField] private float attackDirectionYValue;
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
        public InputAction Vertical { get { return vertical; } }
        public InputAction Horizontal { get { return horizontal; } }
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
        void Start()
        {
            CheckForChanges();
        }
        private void OnValidate()
        {
            if (scriptInitialized) CheckForChanges();
        }

        private void OnEnable()
        {
            //StartCoroutine(WaitForLoading());
            actionA = playerActions.PlayerCharacterAction.ActionA;
            actionB = playerActions.PlayerCharacterAction.ActionB;
            actionC = playerActions.PlayerCharacterAction.ActionC;
            dropLeftItem = playerActions.PlayerCharacterAction.DropLeftItem;
            dropRightItem = playerActions.PlayerCharacterAction.DropRightItem;
            grab = playerActions.PlayerCharacterAction.Grab;
            take = playerActions.PlayerCharacterAction.Take;

            vertical = playerActions.PlayerCharacterMovement.Vertical;
            horizontal = playerActions.PlayerCharacterMovement.Horizontal;
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
            vertical.started += playerManager.PlayerItemPickup.DisableCanvases;

            vertical.performed += playerManager.MovementController.Moving;
            vertical.canceled += playerManager.MovementController.Moving;
            horizontal.performed += playerManager.MovementController.Moving;
            horizontal.canceled += playerManager.MovementController.Moving;
            jump.performed += playerManager.MovementController.Jump;
            run.performed += playerManager.CharacterAbilitiesController.Sprint;
            run.canceled += playerManager.CharacterAbilitiesController.Sprint;
            walk.performed += playerManager.CharacterAbilitiesController.Walk;
            walk.canceled += playerManager.CharacterAbilitiesController.Walk;

            //buildMenu.performed += playerManager.UIController.BuildingMenu.MenuKey;
            //equipmentMenu.performed += playerManager.UIController.EquipmentMenu.MenuKey;
            //cancelMenu.performed += playerManager.UIController.DisableAllMenus;

            attackA.performed += playerManager.PlayerCombat.LightAttack;
            attackA.canceled += playerManager.PlayerCombat.ResetLightAttack;
            fightMode.performed += playerManager.PlayerCombat.EnterCombatMode;
            exploreMode.performed += playerManager.PlayerCombat.ExitCombatMode;
            attackDirection.performed += playerManager.PlayerCombat.SetAttackDirection;
            attackDirection.canceled += playerManager.PlayerCombat.ResetAttackDirectionZero;

            buildVerticalRotation.started += playerManager.PlayerModularBuilding.StartVerticalRotation;
            buildVerticalRotation.canceled += playerManager.PlayerModularBuilding.StopRotation;

            if (debugLogging) { Debug.LogFormat("<color=#FFFF00> {0} </color>", "--->[" + this + "] INPUTS INITIALIZED."); }
            EnableActions();
            EnableBuilding();
            EnableCombat();
            EnableMenu();
            EnableMovement();

            if (!scriptInitialized) scriptInitialized = true;
        }
        private void OnDisable()
        {
            DisableActions();
            DisableBuilding();
            DisableCombat();
            DisableMenu();
            DisableMovement();
        }
        void Update()
        {
            if (readInputs)
            {
                actionAValue = actionA.ReadValue<float>();
                actionBValue = actionB.ReadValue<float>();
                actionCValue = actionC.ReadValue<float>();
                dropLeftItemValue = dropLeftItem.ReadValue<float>();
                dropRightItemValue = dropRightItem.ReadValue<float>();
                grabValue = grab.ReadValue<float>();
                takeValue = take.ReadValue<float>();
                buildVerticalRotationValue = buildVerticalRotation.ReadValue<float>();
                buildHorizontalRotationValue = buildHorizontalRotation.ReadValue<float>();
                buildingCancelValue = buildingCancel.ReadValue<float>();
                buildingConfirmValue = buildingConfirm.ReadValue<float>();
                verticalValue = vertical.ReadValue<float>();
                horizontalValue = horizontal.ReadValue<float>();
                jumpValue = jump.ReadValue<float>();
                runValue = run.ReadValue<float>();
                walkValue = walk.ReadValue<float>();
                mouseDeltaXValue = mouseDelta.ReadValue<Vector2>().x;
                mouseDeltaYValue = mouseDelta.ReadValue<Vector2>().y;
                mousePositionXValue = mousePosition.ReadValue<Vector2>().x;
                mousePositionYValue = mousePosition.ReadValue<Vector2>().y;
                buildMenuValue = buildMenu.ReadValue<float>();
                characterMenuValue = characterMenu.ReadValue<float>();
                mapMenuValue = mapMenu.ReadValue<float>();
                journeyMenuValue = journeyMenu.ReadValue<float>();
                //inventoryMenuValue = inventoryMenu.ReadValue<float>(); //no existe este input :v
                facultiesMenuValue = facultiesMenu.ReadValue<float>();
                equipmentMenuValue = equipmentMenu.ReadValue<float>();
                cancelMenuValue = cancelMenu.ReadValue<float>();
                attackAValue = attackA.ReadValue<float>();
                attackBValue = attackB.ReadValue<float>();
                fightModeValue = fightMode.ReadValue<float>();
                exploreModeValue = exploreMode.ReadValue<float>();
                reloadValue = reload.ReadValue<float>();
                aimValue = aim.ReadValue<float>();
                attackDirectionXValue = attackDirection.ReadValue<Vector2>().x;
                attackDirectionYValue = attackDirection.ReadValue<Vector2>().y;
            }
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
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Actions inputs enabled.");
            }
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
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Actions inputs disabled.");
            }
        }
        public void EnableMovement()
        {
            horizontal.Enable();
            vertical.Enable();
            jump.Enable();
            run.Enable();
            walk.Enable();
            mouseDelta.Enable();
            mousePosition.Enable();
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Movement inputs enabled.");
            }
        }
        public void DisableMovement()
        {
            horizontal.Disable();
            vertical.Disable();
            jump.Disable();
            run.Disable();
            walk.Disable();
            mouseDelta.Disable();
            mousePosition.Disable();
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Movement inputs disabled.");
            }
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
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Menu inputs enabled.");
            }
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
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Menu inputs disabled.");
            }
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
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Combat inputs enabled.");
            }
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
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Combat inputs disabled.");
            }
        }
        public void EnableBuilding()
        {
            buildVerticalRotation.Enable();
            buildHorizontalRotation.Enable();
            buildingCancel.Enable();
            buildingConfirm.Enable();
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Building inputs enabled.");
            }
        }
        public void DisableBuilding()
        {
            buildVerticalRotation.Disable();
            buildHorizontalRotation.Disable();
            buildingCancel.Disable();
            buildingConfirm.Disable();
            if (debugLogging)
            {
                Debug.LogFormat("<color=#FFFF00> {0} </color>", "-->[" + this + "] Building inputs disabled.");
            }
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
                DisableMovement();
            }
        }
        private void ChangeInput(object sender, EventArgs e)
        {
            CheckForChanges();
        }
        #endregion

        IEnumerator WaitForLoading()
        {
            //Print the time of when the function is first called.
            Debug.Log("Started Coroutine at timestamp : " + Time.time);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(5);

            //After we have waited 5 seconds print the time again.
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }
    }
}