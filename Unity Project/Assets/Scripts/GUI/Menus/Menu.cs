using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    
    #region FIELDS
    private Controller_PlayerManager playerGlobalController;
    private bool isEnabled;
    private event EventHandler OnMenuEnabled;
    private event EventHandler OnMenuDisabled;
    #endregion

    #region PROPERTIES
    public Controller_PlayerManager PlayerGlobalController { get { return playerGlobalController; } }
    public bool IsEnabled { get { return isEnabled; } }
    #endregion

    #region METHODS
    public void MenuKey(InputAction.CallbackContext obj){
        Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] '" + obj.control.name + "' key has been pressed.");
        if (isEnabled){
            try{
                this.gameObject.SetActive(false);
                OnMenuDisabled?.Invoke(this, EventArgs.Empty);
                isEnabled = false;
            }catch (Exception ex){
                Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
            }
        }
        else{
            try{
                this.gameObject.SetActive(true);
                OnMenuEnabled?.Invoke(this, EventArgs.Empty);
                isEnabled = true;
            }catch (Exception ex){
                Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
            }
        }
    }
    #endregion
    

    #region UNITY METHOD
    private void Start(){
        this.transform.gameObject.SetActive(true);
        playerGlobalController = GetComponentInParent<Controller_PlayerManager>();
        OnMenuDisabled += playerGlobalController.EnableMouseRotation;
        OnMenuEnabled += playerGlobalController.DisableMouseRotation;
    }
    #endregion
}
