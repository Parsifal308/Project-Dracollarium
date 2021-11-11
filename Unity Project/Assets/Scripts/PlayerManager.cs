using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    #region FIELDS
    [Header("INPUTS:"), Space(10)]
    [SerializeField] private PlayerInput playerInput;

    [Header("GRAPHIC USER INTERFACE: "), Space(10)]
    [SerializeField] private GameObject equipmentPanel;
    [SerializeField] private GameObject buildingPanel;

    [Header("MOVEMENT SCRIPTS:"), Space(10)]
    [SerializeField] private PlayerFocusedMovement focusedMovement;
    [SerializeField] private PlayerFreeMovement freeMovement;
    private IMovement currentMovementScript;

    [Header("CAMERA SCRIPTS:"), Space(10)]
    [SerializeField] private PlayerCameraLookAround lookAroundCam;
    [SerializeField] private PlayerCameraFocusedLook focusedLookCam;
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
    public PlayerInput PlayerInput { get { return playerInput; } }
    public PlayerStats PlayerStats { get { return playerStats; } }
    public PlayerFocusedMovement FocusedMovement { get { return focusedMovement; } }
    public PlayerFreeMovement FreeMovement { get { return freeMovement; } }
    public PlayerCameraLookAround LookAroundCam { get { return lookAroundCam; } }
    public PlayerCameraFocusedLook FocusedLookCam { get { return focusedLookCam; } }
    public ICamera CurrentCamera { get { return currentCameraScript; } set { currentCameraScript = value; } }
    public GameObject BuildingPanel { get { return buildingPanel; } set { buildingPanel = value; } }
    public GameObject EquipmentPanel { get { return equipmentPanel; } set { equipmentPanel = value; } }
    public PlayerItemPickup PlayerItemPickup { get { return PlayerItemPickup; } set { playerItemPickUp = value; } }
    public ModularBuilding PlayerModularBuilding { get { return playerModularBuilding; } set { playerModularBuilding = value; } }
    #endregion

    #region METHODS
    public void ChangeCameraScript(ICamera currentCam, ICamera objectiveCam){
        currentCam.Enabled = false;
        objectiveCam.Enabled = true;
    }
    public void DisableItemCollection(){ //called from gui button event
        try{
            Debug.Log("-->[LOG] Disabling player items collection system.....");
            playerItemPickUp.enabled = false;
            Debug.Log("-->[LOG] Player items collection system DISABLED.");
        }
        catch (Exception ex){
            Debug.Log("----->[ERROR] A '" + ex.GetType() + "' has ocurred.");
        }
    }
    public void EnableItemCollection(){ //called from gui button event
        try{
            Debug.Log("-->[LOG] Enabling player items collection system.....");
            playerItemPickUp.enabled = true;
            Debug.Log("-->[LOG] Player items collection system ENABLED.");
        }
        catch (Exception ex){
            Debug.Log("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void EnableItemCollection(object sender, EventArgs e){
        try{
            Debug.Log("-->[LOG] Enabling player items collection system.....");
            playerItemPickUp.enabled = true;
            Debug.Log("-->[LOG] Player items collection system ENABLED.");
        }
        catch (Exception ex){
            Debug.Log("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void EnableBuildingPositioning(){
        try{
            Debug.Log("-->[LOG] Enabling player building positioning.....");
            playerModularBuilding.EnablePositioning();
            Debug.Log("-->[LOG] Player building positioning ENABLED.");
        }
        catch (Exception ex){
            Debug.Log("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void DisableBuildingPositioning(){
        try{
            Debug.Log("-->[LOG] Disabling player building positioning.....");
            playerModularBuilding.DisablePositioning();
            Debug.Log("-->[LOG] Player building positioning DISABLED.");
        }
        catch (Exception ex){
            Debug.Log("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void DisableBuildingPositioning(object sender, EventArgs e){
        try{
            Debug.Log("-->[LOG] Disabling player building positioning.....");
            playerModularBuilding.DisablePositioning();
            Debug.Log("-->[LOG] Player building positioning DISABLED.");
        }
        catch (Exception ex){
            Debug.Log("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void EnableMouseRotation(){
        try{
            Debug.Log("-->[LOG] Enabling mouse rotation on " + currentCameraScript + " script...");
            currentCameraScript.IsMouseEnabled = true;
            Debug.Log("-->[LOG] mouse rotation on " + currentCameraScript + " script ENABLED");
        }
        catch(Exception ex){
            Debug.Log("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
        }
    }
    public void DisableMouseRotation(){
        try{
            Debug.Log("-->[LOG] Disabling mouse rotation on " + currentCameraScript + " script...");
            currentCameraScript.IsMouseEnabled = false;
            Debug.Log("-->[LOG] mouse rotation on " + currentCameraScript + " script DISABLED");
        }
        catch (Exception ex){
            Debug.Log("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
        }
    }
    public void EnableMouseRotation(object sender, EventArgs e){
        try{
            Debug.Log("-->[LOG] Enabling mouse rotation on " + currentCameraScript + " script...");
            currentCameraScript.IsMouseEnabled = true;
            Debug.Log("-->[LOG] mouse rotation on " + currentCameraScript + " script ENABLED");
        }
        catch (Exception ex){
            Debug.Log("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
        }
    }
    public void DisableMouseRotation(object sender, EventArgs e){
        try{
            Debug.Log("-->[LOG] Disabling mouse rotation on " + currentCameraScript + " script...");
            currentCameraScript.IsMouseEnabled = false;
            Debug.Log("-->[LOG] mouse rotation on " + currentCameraScript + " script DISABLED");
        }
        catch (Exception ex){
            Debug.Log("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
        }
    }

    public void PositionBuilding(GameObject building){
        try{
            Debug.Log("-->[LOG] Positioning building...");
            playerModularBuilding.PositionBuilding(building);
        }catch(Exception ex){
            Debug.Log("----->[ERROR] An error of type '" + ex.GetType() + "' has ocurred!!!");
        }
    }
    #endregion

    #region UNITY METHODS
    private void Start(){
        fabricationActions = gameObject.GetComponents<IFabricate>();
        currentCameraScript = FocusedLookCam;
        currentMovementScript = FocusedMovement;
    }
    #endregion

}
public enum GameMode
{
    DevMode,
    GodMode,
    SurvivalMode
}
