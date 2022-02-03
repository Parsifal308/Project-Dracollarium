using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera_PlayerShoulder : MonoBehaviour, ICamera{
    #region FIELDS
    [SerializeField] private float cameraSensibility;
    [SerializeField] private float positionLerp = 0.05f;
    [SerializeField] private float rotationLerp = 0.05f;
    private bool isMouseEnabled = true;
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    private Controller_PlayerManager playerGlobalController;
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
    #endregion
    #region UNITY METHODS
    private void Start(){
        playerCamera = Camera.main;
        playerGlobalController = GetComponent<Controller_PlayerManager>();
        rotationTarget = new GameObject("[Axis] Focused Camera Rotation Target");
        rotationTarget.transform.SetParent(transform);
        followTarget = new GameObject("[Axis] Focused Camera Follow Target");
        followTarget.transform.position = transform.position + new Vector3(-3f, 2.25f, -1f); 
        followTarget.transform.SetParent(GetComponentInChildren<CharacterController>().transform);
    }
    
    private void Update(){
        if (isMouseEnabled){
            mouseX += playerGlobalController.Controller_PlayerActions_CharacterMovement.MouseDelta.ReadValue<Vector2>().x * playerGlobalController.CurrentCameraScript.CameraSensibility;
            mouseY += playerGlobalController.Controller_PlayerActions_CharacterMovement.MouseDelta.ReadValue<Vector2>().y * playerGlobalController.CurrentCameraScript.CameraSensibility;
            mouseY = Mathf.Clamp(mouseY, -25f, 25f);
            rotationTarget.transform.localRotation = Quaternion.Euler(-mouseY, mouseX + 90f, 0);

        }
        Lerp();
    }
    #endregion
    public void MouseDelta(InputAction.CallbackContext obj)
    {
        
    }

    public void MousePosition(InputAction.CallbackContext obj)
    {

    }
}
