using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour{
    ICamera cameraScript;

    //En estos campos se almacenan los valores recibidos por el InputSystem de Unity
    [SerializeField] private Vector3 movementInput;
    [SerializeField] private Vector2 mouseDelta;
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isJumping;
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;

    public event EventHandler OnRunKey;
    public event EventHandler OnWalkKey;
    public event EventHandler OnJumpKey;
    public event EventHandler OnMoving;
    public void CalculateMouseToCameraInput(){
        mouseX += mouseDelta.x * cameraScript.CameraSensibility;
        mouseY += mouseDelta.y * cameraScript.CameraSensibility;
    }
    private void Awake(){
        cameraScript = GetComponent<ICamera>();
    }

    #region PROPERTIES
    //Estas propiedades son utilizadas para acceder a los campos privados de esta clase
    public Vector3 MovementInput {get {return movementInput;} }
    public Vector2 MouseDelta { get { return mouseDelta; } }
    public Vector2 MousePosition { get { return mousePosition; } }
    public bool IsMoving { get { return isMoving; } }
    public bool IsRunning { get { return isRunning; } }
    public bool IsWalking { get { return isWalking; } }
    public bool IsJumping { get { return isJumping; } }
    public float MouseX { get { return mouseX; } }
    public float MouseY { get { return mouseY; } }
    #endregion

    #region INPUT ACTIONS
    public void SetMovementInput(InputAction.CallbackContext value){ //UnityEvent que se invoca cuando el jugador presiona alguna de las teclas de movimiento(ej. WASD)
        Vector2 input = value.ReadValue<Vector2>();
        movementInput.Set(input.x, 0, input.y);
        if(movementInput != Vector3.zero){
            isMoving = true;
        }
        else{
            isMoving = false;
        }
    }
    public void SetRunInput(InputAction.CallbackContext value){ //UnityEvent que se invoca cuando el jugador presiona la tecla para correr(ej. shift)
        isRunning = value.ReadValueAsButton();
    }
    public void SetWalkInput(InputAction.CallbackContext value){ //UnityEvent que se invoca cuando el jugador presiona la tecla para caminar(ej. X)
        isWalking = value.ReadValueAsButton();
    }
    public void SetJumpInput(InputAction.CallbackContext value){ //UnityEvent que se invoca cuando el jugador presiona la tecla para saltar(ej. spacebar)
    isJumping = value.ReadValueAsButton();
    }
    public void SetMouseDelta(InputAction.CallbackContext value){
        mouseDelta = value.ReadValue<Vector2>();
    }
    public void SetMousePosition(InputAction.CallbackContext value){
        mousePosition = value.ReadValue<Vector2>();
    }

    #endregion
}
