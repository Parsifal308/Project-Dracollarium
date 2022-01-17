using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*  ======================================================================
 *  Clase base de los elementos de la GUI
 *  por que? no hay por que
 *  ======================================================================
 */
public class GUI_Menu : MonoBehaviour
{
    #region FIELDS
    [SerializeField] protected Controller_PlayerManager controller_PlayerManager;
    private bool isEnabled;
    private event EventHandler OnMenuEnabled;
    private event EventHandler OnMenuDisabled;
    #endregion

    #region PROPERTIES
    public Controller_PlayerManager ControllerPlayerManager { get { return controller_PlayerManager; } }
    public bool IsEnabled { get { return isEnabled; } }
    #endregion

    #region METHODS
    public void MenuKey(InputAction.CallbackContext obj){
        Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] '" + obj.control.name + "' key has been pressed.");
        EnableDisableMenu();
    }
    public void EnableDisableMenu(){
        if (isEnabled){
            DisableMenu();
        }
        else{
            EnableMenu();
        }
    }
    public void EnableMenu(){
        try{
            this.gameObject.SetActive(true);
            OnMenuEnabled?.Invoke(this, EventArgs.Empty);
            isEnabled = true;
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    public void DisableMenu(){
        try{
            this.gameObject.SetActive(false);
            OnMenuDisabled?.Invoke(this, EventArgs.Empty);
            isEnabled = false;
        }
        catch (Exception ex){
            Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
        }
    }
    
    #endregion
    

    #region UNITY METHOD
    private void Start(){
        this.transform.gameObject.SetActive(false);
        controller_PlayerManager = GetComponentInParent<Controller_PlayerManager>();
        OnMenuDisabled += controller_PlayerManager.EnableMouseRotation;
        OnMenuEnabled += controller_PlayerManager.DisableMouseRotation;
    }
    #endregion
}
