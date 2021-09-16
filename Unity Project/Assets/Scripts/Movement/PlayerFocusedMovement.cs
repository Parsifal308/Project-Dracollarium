using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFocusedMovement : MonoBehaviour , IMovement{
    private PlayerManager playerManager;
    public event EventHandler OnPlayerMovement;
    private CharacterController controller;
    private Vector3 movementVector;

    #region METHODS
    public void Move(float moveSpeed){
        movementVector = controller.transform.right * playerManager.PlayerInput.MovementInput.z + controller.transform.forward * -playerManager.PlayerInput.MovementInput.x;
        controller.Move(movementVector * Time.deltaTime * moveSpeed);
        //controller.Move(playerManager.PlayerInput.MovementInput * Time.deltaTime * moveSpeed);  //Mueve el CharacterController usando las propiedades de PlayerInput.cs(Input x Velocidad x Tiempo)
        Rotate();
        OnPlayerMovement?.Invoke(this, EventArgs.Empty);    //Si los subscriptores del evento no son nulos, entonces se dispara dicho metodo.
    }
    public void Rotate(){
        controller.transform.rotation = Quaternion.Euler(0f, playerManager.FocusedLookCam.Camera.transform.rotation.eulerAngles.y - 90f, 0f);
    }
    public void Enable()
    {
        this.enabled = true;
    }

    public void Disable()
    {
        this.enabled = false;
    }
    #endregion
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        controller = GetComponentInChildren<CharacterController>();
        OnPlayerMovement += GetComponent<PlayerDracollariumAnimation>().SetMovementAnimationBoolean;
        OnPlayerMovement += GetComponent<PlayerDracollariumAnimation>().SetMovementInput;
    }
    private void Update(){
        if (playerManager.PlayerInput.IsRunning){
            Move(playerManager.PlayerStats.RunSpeed);
        }
        else{
            Move(playerManager.PlayerStats.WalkSpeed);
        }
        
    }
}
