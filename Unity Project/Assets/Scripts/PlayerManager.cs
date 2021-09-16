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
    #endregion

    #region METHODS
    public void ChangeCameraScript(ICamera currentCam, ICamera objectiveCam){
        currentCam.Enabled = false;
        objectiveCam.Enabled = true;
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
