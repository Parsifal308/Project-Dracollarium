using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnableMenu : MonoBehaviour{
    public event EventHandler OnMenuEnabled; //escuchado desde ICamera para activar/desactivar mouse
    public event EventHandler OnMenuDisabled;
    private void Start()
    {
        OnMenuEnabled += GetComponentInParent<PlayerManager>().CurrentCamera.EnableMouseRotation;
        OnMenuDisabled += GetComponentInParent<PlayerManager>().CurrentCamera.DisableMouseRotation;
    }
    public void ShowMenu(InputAction.CallbackContext value){    //invocado cada vez que se presiona tecla de construir desde InputSystem"
        if (value.started){
            this.gameObject.SetActive(true);
            OnMenuDisabled?.Invoke(this, EventArgs.Empty);
        }
        if (value.canceled){
            this.gameObject.SetActive(false);
            OnMenuEnabled?.Invoke(this, EventArgs.Empty);
        }
    }
}
