using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player_Equipment))]
[RequireComponent(typeof(Player_Stats))]
[RequireComponent(typeof(Player_ItemPickup))]
[RequireComponent(typeof(Player_ModularBuilding))]
[RequireComponent(typeof(Camera_PlayerShoulder))]
[RequireComponent(typeof(Player_Movement_Focused))]
[RequireComponent(typeof(Player_Animation_Dracollarium))]
[RequireComponent(typeof(Controller_PlayerActions_Actions))]
public class Controller_PlayerManager : MonoBehaviour {

    #region FIELDS
    [Header("INPUTS:"), Space(10)]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Controller_PlayerActions_Actions controller_PlayerActionsMap_Actions;
    [SerializeField] private Controller_PlayerActions_Building controller_PlayerActions_Building;
    [SerializeField] private Controller_PlayerActions_CharacterMovement controller_PlayerActions_Movement;
    [SerializeField] private Controller_PlayerActions_Menu controller_PlayerActions_Menu;
    [SerializeField] private Controller_PlayerActions_PlayerCombat controller_PlayerActions_Combat;

    [Header("GRAPHIC USER INTERFACE: "), Space(10)]
    //[SerializeField] private GameObject equipmentPanel;
    //[SerializeField] private GameObject buildingPanel;
    [SerializeField] private GUI_Menu menuBuilding;
    [SerializeField] private GUI_Menu menuBuildingCategory;
    [SerializeField] private GUI_Menu menuBuildingModule;
    [SerializeField] private GUI_Menu menuEquipment;
    [SerializeField] private GameObject menuEquipmentContent;
    [SerializeField] private PauseMenu menuPause;
    [SerializeField] private GUI_Menu menuInventory;
   // [SerializeField] private 

    [Header("MOVEMENT SCRIPTS:"), Space(10)]
    [SerializeField] private Player_Movement_Focused focusedMovement;
    [SerializeField] private Movement_Free freeMovement;
    [SerializeField] private Player_Animation_Dracollarium playerDracollariumAnimation;
    private IMovement currentMovementScript;

    [Header("CAMERA SCRIPTS:"), Space(10)]
    [SerializeField] private Camera_LookAround lookAroundCam;
    [SerializeField] private Camera_PlayerShoulder focusedLookCam;
    private ICamera currentCameraScript;

    [Header("PLAYER:"), Space(25)]
    [SerializeField] private Player_Equipment playerEquipment;
    [SerializeField] private Player_Stats playerStats;
    [SerializeField] private Player_ItemPickup playerItemPickUp;
    [SerializeField] private Player_ModularBuilding playerModularBuilding;
    [SerializeField] private Player_Combat playerCombat;
    private IFabricate[] fabricationActions;

    [Header("PLAYER MODES:"), Space(5)]
    [SerializeField] private GameMode playerGameMode;
    [SerializeField] private bool buildingMode;

    [Header("AXIS REFERENCES:"), Space(5)]
    [SerializeField] protected GameObject dropLocation;
    #endregion

    #region PROPERTIES
    public Player_Combat PlayerCombat { get { return playerCombat; } }
    public GameObject DropPosition { get { return dropLocation; } }
    public GameObject MenuEquipmentContent { get { return menuEquipmentContent; } }
    public Player_Equipment PlayerEquipment { get { return playerEquipment; } }
    public ICamera CurrentCameraScript { get { return currentCameraScript; } }
    public Controller_PlayerActions_Actions Controller_PlayerActions_Actions { get { return controller_PlayerActionsMap_Actions; } }
    public Controller_PlayerActions_CharacterMovement Controller_PlayerActions_CharacterMovement { get { return controller_PlayerActions_Movement; } }
    public Controller_PlayerActions_Building Controller_PlayerActions_Building { get { return controller_PlayerActions_Building; } }
    public GUI_Menu BuildingMenu { get { return menuBuilding; }set{ menuBuilding = value; } }
    public Player_Animation_Dracollarium PlayerDracollariumAnimation { get { return playerDracollariumAnimation; } set { playerDracollariumAnimation = value; } }
    public GUI_Menu EquipmentMenu { get { return menuEquipment; } set { menuEquipment = value; } }
    public PauseMenu PauseMenu { get { return menuPause; } set { menuPause = value; } }
    public PlayerInput PlayerInput { get { return playerInput; } }
    public Player_Stats PlayerStats { get { return playerStats; } }
    public Player_Movement_Focused FocusedMovement { get { return focusedMovement; } }
    public Movement_Free FreeMovement { get { return freeMovement; } }
    public Camera_LookAround LookAroundCam { get { return lookAroundCam; } }
    public Camera_PlayerShoulder FocusedLookCam { get { return focusedLookCam; } }
    public ICamera CurrentCamera { get { return currentCameraScript; } set { currentCameraScript = value; } }
    public IMovement CurrentMovementScript { get { return currentMovementScript; } set { currentMovementScript = value; } }
    //public GameObject BuildingPanel { get { return buildingPanel; } set { buildingPanel = value; } }
    //public GameObject EquipmentPanel { get { return equipmentPanel; } set { equipmentPanel = value; } }
    public Player_ItemPickup PlayerItemPickup { get { return playerItemPickUp; } set { playerItemPickUp = value; } }
    public Player_ModularBuilding PlayerModularBuilding { get { return playerModularBuilding; } set { playerModularBuilding = value; } }
    #endregion

    #region METHODS
    public void ChangeCameraScript(ICamera currentCam, ICamera objectiveCam){
        currentCam.Enabled = false;
        objectiveCam.Enabled = true;
    }
    public void DisableItemCollection(){ //called from gui button event
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling player items collection system.....");
            playerItemPickUp.enabled = false;
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player items collection system DISABLED.");
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] A '" + ex.GetType() + "' has ocurred.");
        }
    }
    public void EnableItemCollection(){ //called from gui button event
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling player items collection system.....");
            playerItemPickUp.enabled = true;
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player items collection system ENABLED.");
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void EnableItemCollection(object sender, EventArgs e){
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling player items collection system.....");
            playerItemPickUp.enabled = true;
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player items collection system ENABLED.");
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void EnableBuildingPositioning(){
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling player building positioning.....");
            playerModularBuilding.EnablePositioning();
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player building positioning ENABLED.");
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }

    public void DisableAllMenus(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        menuBuilding.DisableMenu();
        menuBuildingCategory.DisableMenu();
        menuBuildingModule.DisableMenu();
        menuEquipment.DisableMenu();
        menuInventory.DisableMenu();
    }

    public void DisableBuildingPositioning(){
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling player building positioning.....");
            playerModularBuilding.DisablePositioning();
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player building positioning DISABLED.");
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void DisableBuildingPositioning(object sender, EventArgs e){
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling player building positioning.....");
            playerModularBuilding.DisablePositioning();
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player building positioning DISABLED.");
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void EnableMouseRotation(){
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling mouse rotation on " + currentCameraScript + " script...");
            currentCameraScript.IsMouseEnabled = true;
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] mouse rotation on " + currentCameraScript + " script ENABLED");
        }
        catch(Exception ex){
            Debug.LogError("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
        }
    }
    public void DisableMouseRotation(){
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling mouse rotation on " + currentCameraScript + " script...");
            currentCameraScript.IsMouseEnabled = false;
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] mouse rotation on " + currentCameraScript + " script DISABLED");
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
        }
    }
    public void EnableMouseRotation(object sender, EventArgs e){
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling mouse rotation on " + currentCameraScript + " script...");
            currentCameraScript.IsMouseEnabled = true;
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] mouse rotation on " + currentCameraScript + " script ENABLED");
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
        }
    }
    public void DisableMouseRotation(object sender, EventArgs e){
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling mouse rotation on " + currentCameraScript + " script...");
            currentCameraScript.IsMouseEnabled = false;
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] mouse rotation on " + currentCameraScript + " script DISABLED");
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
        }
    }
    public void PositionBuilding(GameObject building){
        try{
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Positioning building...");
            playerModularBuilding.PositionBuilding(building);
        }catch(Exception ex){
            Debug.LogError("----->[ERROR] An error of type '" + ex.GetType() + "' has ocurred!!!");
        }
    }
    #endregion

    #region UNITY METHODS
    private void Start(){
        fabricationActions = gameObject.GetComponents<IFabricate>();
        playerDracollariumAnimation = GetComponent<Player_Animation_Dracollarium>();
        currentCameraScript = FocusedLookCam;
        currentMovementScript = FocusedMovement;
        controller_PlayerActionsMap_Actions = GetComponent<Controller_PlayerActions_Actions>();
        controller_PlayerActions_Building = GetComponent<Controller_PlayerActions_Building>();
        controller_PlayerActions_Movement = GetComponent<Controller_PlayerActions_CharacterMovement>();
        controller_PlayerActions_Menu = GetComponent<Controller_PlayerActions_Menu>();
        controller_PlayerActions_Combat = GetComponent<Controller_PlayerActions_PlayerCombat>();
        //Cursor.lockState = CursorLockMode.Confined;
    }
    #endregion

}
public enum GameMode
{
    DevMode,
    GodMode,
    SurvivalMode
}

/*
 * Debug.LogFormat("This is <color=#ff0000>{0}</color>", "red");
 * Debug.LogFormat("This is <color=#00ff00>{0}</color>", "green");
 * Debug.LogFormat("This is <color=#0000ff>{0}</color>", "blue");
 * Debug.LogFormat("This is <color=yellow>{0}</color>", "yellow");
*/
