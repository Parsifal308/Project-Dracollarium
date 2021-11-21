using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_PlayerManager : MonoBehaviour {

    #region FIELDS
    [Header("INPUTS:"), Space(10)]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Controller_PlayerActions playerActionsController;

    [Header("GRAPHIC USER INTERFACE: "), Space(10)]
    //[SerializeField] private GameObject equipmentPanel;
    //[SerializeField] private GameObject buildingPanel;
    [SerializeField] private BuildingMenu buildingMenu;
    [SerializeField] private EquipmentMenu equipmentMenu;
    [SerializeField] private PauseMenu pauseMenu;

    [Header("MOVEMENT SCRIPTS:"), Space(10)]
    [SerializeField] private PlayerMovement_Shoulder focusedMovement;
    [SerializeField] private PlayerMovement_Free freeMovement;
    [SerializeField] private PlayerDracollariumAnimation playerDracollariumAnimation;
    private IMovement currentMovementScript;

    [Header("CAMERA SCRIPTS:"), Space(10)]
    [SerializeField] private PlayerCameraLookAround lookAroundCam;
    [SerializeField] private PlayerCamera_Shoulder focusedLookCam;
    private ICamera currentCameraScript;

    [Header("PLAYER:"), Space(25)]
    [SerializeField] private PlayerEquipment playerEquipment;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerItemPickup playerItemPickUp;
    [SerializeField] private ModularBuilding playerModularBuilding;
    private IFabricate[] fabricationActions;

    [Header("PLAYER MODE:"), Space(5)]
    [SerializeField] private GameMode playerGameMode;
    #endregion

    #region PROPERTIES
    public ICamera CurrentCameraScript { get { return currentCameraScript; } }
    public Controller_PlayerActions PlayerActionsController { get { return playerActionsController; } }
    public BuildingMenu BuildingMenu { get { return buildingMenu; }set{ buildingMenu = value; } }
    public PlayerDracollariumAnimation PlayerDracollariumAnimation { get { return playerDracollariumAnimation; } set { playerDracollariumAnimation = value; } }
    public EquipmentMenu EquipmentMenu { get { return equipmentMenu; } set { equipmentMenu = value; } }
    public PauseMenu PauseMenu { get { return pauseMenu; } set { pauseMenu = value; } }
    public PlayerInput PlayerInput { get { return playerInput; } }
    public PlayerStats PlayerStats { get { return playerStats; } }
    public PlayerMovement_Shoulder FocusedMovement { get { return focusedMovement; } }
    public PlayerMovement_Free FreeMovement { get { return freeMovement; } }
    public PlayerCameraLookAround LookAroundCam { get { return lookAroundCam; } }
    public PlayerCamera_Shoulder FocusedLookCam { get { return focusedLookCam; } }
    public ICamera CurrentCamera { get { return currentCameraScript; } set { currentCameraScript = value; } }
    public IMovement CurrentMovementScript { get { return currentMovementScript; } set { currentMovementScript = value; } }
    //public GameObject BuildingPanel { get { return buildingPanel; } set { buildingPanel = value; } }
    //public GameObject EquipmentPanel { get { return equipmentPanel; } set { equipmentPanel = value; } }
    public PlayerItemPickup PlayerItemPickup { get { return playerItemPickUp; } set { playerItemPickUp = value; } }
    public ModularBuilding PlayerModularBuilding { get { return playerModularBuilding; } set { playerModularBuilding = value; } }
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
        playerDracollariumAnimation = GetComponent<PlayerDracollariumAnimation>();
        currentCameraScript = FocusedLookCam;
        currentMovementScript = FocusedMovement;
        playerActionsController = GetComponent<Controller_PlayerActions>();
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
