using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFocusedLook : MonoBehaviour, ICamera{
    #region FIELDS
    [SerializeField] private float cameraSensibility;
    [SerializeField] private float positionLerp = 0.05f;
    [SerializeField] private float rotationLerp = 0.05f;
    [SerializeField] private bool isMouseEnabled = true;
    private PlayerManager playerManager;
    private Camera playerCamera;
    private GameObject followTarget;
    private GameObject rotationTarget;
    
    #endregion

    #region PROPERTIES
    public float CameraSensibility { get { return cameraSensibility; } }
    public bool Enabled { get { return enabled; } set { enabled = value; } }
    public Camera Camera { get { return playerCamera; } }
    public GameObject RotationTarget { get { return RotationTarget; } }
    public bool IsMouseEnabled { get { return isMouseEnabled; } set { isMouseEnabled = value; } }
    #endregion

    #region METHODS
    public void Lerp(){
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, followTarget.transform.position, positionLerp);
        playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, rotationTarget.transform.rotation, rotationLerp);
    }
    public void EnableMouseRotation(object sender, EventArgs e){
        IsMouseEnabled = true;
    }
    public void DisableMouseRotation(object sender, EventArgs e){
        IsMouseEnabled = false;
    }

    #endregion
    private void Start(){
        playerCamera = Camera.main;
        playerManager = GetComponent<PlayerManager>();
        rotationTarget = new GameObject("[Axis] Focused Camera Rotation Target");
        rotationTarget.transform.SetParent(transform);
        followTarget = new GameObject("[Axis] Focused Camera Follow Target");
        followTarget.transform.position = transform.position + new Vector3(-2.5f, 2f, -0.5f); 
        followTarget.transform.SetParent(GetComponentInChildren<CharacterController>().transform);

    }
    
    private void Update(){
        if (isMouseEnabled){
            playerManager.PlayerInput.CalculateMouseToCameraInput();
        }
        rotationTarget.transform.localRotation = Quaternion.Euler(-playerManager.PlayerInput.MouseY, playerManager.PlayerInput.MouseX + 90f, 0);
        Lerp();
    } 
}
