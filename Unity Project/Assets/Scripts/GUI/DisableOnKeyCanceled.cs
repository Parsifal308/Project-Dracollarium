using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisableOnKeyCanceled : MonoBehaviour{
    public event EventHandler OnMenuEnabled;
    private void Start(){
        OnMenuEnabled += GetComponentInParent<PlayerManager>().CurrentCamera.EnableMouseRotation;
    }
    public void DisableMenu(InputAction.CallbackContext value){   
        //invocado cada vez que se presiona tecla de construir desde InputSystem"
        if (value.canceled){
            this.gameObject.SetActive(false);
            OnMenuEnabled?.Invoke(this, EventArgs.Empty);
        }
    }
}
