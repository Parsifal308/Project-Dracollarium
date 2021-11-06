using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnableOnKeyStarted : MonoBehaviour{
    public event EventHandler OnMenuEnabled; //escuchado desde ICamera para activar/desactivar mouse
    private void Start(){
        OnMenuEnabled += GetComponentInParent<PlayerManager>().CurrentCamera.DisableMouseRotation;   
    }
    public void EnableMenu(InputAction.CallbackContext value){    //invocado cada vez que se presiona tecla de construir desde InputSystem"
        if (value.started){
            this.gameObject.SetActive(true);
            OnMenuEnabled?.Invoke(this, EventArgs.Empty);
        }
    }
}
