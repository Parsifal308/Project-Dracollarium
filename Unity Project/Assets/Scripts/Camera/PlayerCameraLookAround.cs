using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraLookAround : MonoBehaviour, ICamera{
    #region FIELDS
    private PlayerManager playerManager;
    private Camera playerCamera;
    private GameObject followTarget;
    private GameObject rotationTarget;
    private float clampedX;
    private float clampedY;
    [SerializeField] private float cameraSensibility = 0.25f;
    [SerializeField] private float positionLerp = 0.05f;
    [SerializeField] private float rotationLerp = 0.05f;
    [SerializeField] private bool disableMouse = true;
    #endregion
    #region PROPERTIES
    public GameObject RotationTarget { get { return rotationTarget; } }
    public GameObject FollowTarget { get { return followTarget; } }
    public float CameraSensibility { get{ return cameraSensibility; } }
    public bool Enabled { get{return enabled; } set{ enabled = value; } }
    public bool IsMouseEnabled { get { return disableMouse; } set { disableMouse = value; } }
    #endregion
    #region METHODS
    public void LerpCamera(){
        playerCamera.transform.position = Vector3.Slerp(playerCamera.transform.position, followTarget.transform.position, positionLerp);
        playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, rotationTarget.transform.rotation, rotationLerp);
    }
    public void EnableMouseRotation(object sender, EventArgs e)
    {
        IsMouseEnabled = true;
    }
    public void DisableMouseRotation(object sender, EventArgs e)
    {
        IsMouseEnabled = false;
    }
    #endregion
    private void Start(){
        playerManager = GetComponent<PlayerManager>();
        playerCamera = Camera.main;
        rotationTarget = new GameObject("[Axis] Free Camera Rotator");
        rotationTarget.transform.SetParent(transform.GetComponentInChildren<CharacterController>().transform);
        followTarget = new GameObject("[Axis] Free Camera Follow Target");
        followTarget.transform.SetParent(rotationTarget.transform);
        rotationTarget.transform.position = transform.position + new Vector3(-2.5f, 2f, -0.5f);
        rotationTarget.transform.localRotation = Quaternion.Euler(0, 90, 0);
        playerCamera.transform.LookAt(rotationTarget.transform);
    }
    private void Update(){
        playerManager.PlayerInput.CalculateMouseToCameraInput();
        rotationTarget.transform.localRotation = Quaternion.Euler(-playerManager.PlayerInput.MouseY, playerManager.PlayerInput.MouseX, 0);    
    }
    private void LateUpdate(){
        LerpCamera();    
    }
}
