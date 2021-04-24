using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeMovement : MonoBehaviour, IMovement{
    public event EventHandler OnPlayerMovement;
    [SerializeField] private PlayerInput input;
    [SerializeField] private CharacterController controller;
    [SerializeField] private CameraPlayerFreeLook cameraScript;
    [SerializeField] private float speed = 8f;
    private void Start(){
        input = GetComponent<PlayerInput>();    //Obtiene el componente PlayerInput.cs de este objeto
        controller = GetComponentInChildren<CharacterController>();   //Obtiene el componente CharacterController de este objeto
        cameraScript = GetComponent<CameraPlayerFreeLook>();
        OnPlayerMovement += GetComponent<PlayerDracollariumAnimation>().SetMovementAnimationBoolean; //Subscribe el metodo del componente PlayerAnimation.cs a este evento

    }
    public void FreeMove(){
        controller.Move(input.MovementInput * Time.deltaTime * speed);  //Mueve el CharacterController usando las propiedades de PlayerInput.cs(Input x Velocidad x Tiempo)
        OnPlayerMovement?.Invoke(this, EventArgs.Empty);    //Si los subscriptores del evento no son nulos, entonces se dispara dicho metodo.
        Rotate();
    }
    public void FocusedMove(){

    }
    public void Rotate(){
        if (input.MovementInput != Vector3.zero){
            controller.transform.right = input.MovementInput;   //rota el CharacterController hacia la direccion del Input
        }
    }
    private void Update(){
        FreeMove();
    }
}
