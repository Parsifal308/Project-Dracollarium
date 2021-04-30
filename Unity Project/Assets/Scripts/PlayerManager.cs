using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    #region FIELDS
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerStats playerStats;  
    [SerializeField] private PlayerFocusedMovement focusedMovement;
    [SerializeField] private PlayerFreeMovement freeMovement;
    [SerializeField] private PlayerCameraLookAround lookAroundCam;
    [SerializeField] private PlayerCameraFocusedLook focusedLookCam;
    #endregion

    #region PROPERTIES
    public PlayerInput PlayerInput { get { return playerInput; } }
    public PlayerStats PlayerStats { get { return playerStats; } }
    public PlayerFocusedMovement FocusedMovement { get { return focusedMovement; } }
    public PlayerFreeMovement FreeMovement { get { return freeMovement; } }
    public PlayerCameraLookAround LookAroundCam { get { return lookAroundCam; } }
    public PlayerCameraFocusedLook FocusedLookCam { get { return focusedLookCam; } }
    #endregion

    #region METHODS
    public void ChangeCameraScript(ICamera currentCam, ICamera objectiveCam){
        currentCam.Enabled = false;
        objectiveCam.Enabled = true;
    }
    #endregion
}
