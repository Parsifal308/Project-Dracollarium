using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeMovement : MonoBehaviour, IMovement{
    public event EventHandler OnPlayerMovement;
    private PlayerManager playerManager;
    private CharacterController controller;
    private void Start(){
        playerManager = GetComponent<PlayerManager>();
        controller = GetComponentInChildren<CharacterController>();   //Obtiene el componente CharacterController de este objeto
        OnPlayerMovement += GetComponent<PlayerDracollariumAnimation>().SetMovementAnimationBoolean; //Subscribe el metodo del componente PlayerAnimation.cs a este evento

    }
    public void Move(float moveSpeed){
        controller.Move(playerManager.PlayerInput.MovementInput * Time.deltaTime * moveSpeed);  //Mueve el CharacterController usando las propiedades de PlayerInput.cs(Input x Velocidad x Tiempo)
        OnPlayerMovement?.Invoke(this, EventArgs.Empty);    //Si los subscriptores del evento no son nulos, entonces se dispara dicho metodo.
        Rotate();
    }
    public void Rotate(){
        if (playerManager.PlayerInput.MovementInput != Vector3.zero){
            controller.transform.right = playerManager.PlayerInput.MovementInput;   //rota el CharacterController hacia la direccion del Input
        }
    }
    private void Update(){
        Move(playerManager.PlayerStats.WalkSpeed);
    }
}
