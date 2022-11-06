using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_Free : MonoBehaviour {
    public event EventHandler OnPlayerMovement;
    private PlayerManager playerManager;
    private CharacterController controller;
    private void Start(){
        playerManager = GetComponent<PlayerManager>();
        controller = GetComponentInChildren<CharacterController>();   //Obtiene el componente CharacterController de este objeto
        OnPlayerMovement += GetComponent<Player_Animation_Dracollarium>().SetMovementAnim; //Subscribe el metodo del componente PlayerAnimation.cs a este evento

    }
    #region METHODS
    public void Move(float moveSpeed){
        controller.Move(playerManager.InputsController.Vertical.ReadValue<Vector2>() * Time.deltaTime * moveSpeed);  //Mueve el CharacterController usando las propiedades de PlayerInput.cs(Input x Velocidad x Tiempo)
        OnPlayerMovement?.Invoke(this, EventArgs.Empty);    //Si los subscriptores del evento no son nulos, entonces se dispara dicho metodo.
        Rotate();
    }
    public void Rotate(){
        if (playerManager.InputsController.Vertical.ReadValue<Vector2>() != Vector2.zero){
            controller.transform.right = playerManager.InputsController.Vertical.ReadValue<Vector2>();   //rota el CharacterController hacia la direccion del Input
        }
    }
    #endregion
    private void Update(){
        Move(playerManager.PlayerStats.WalkSpeed);
    }


    public void Jump(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }
    public void Move(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }
}
