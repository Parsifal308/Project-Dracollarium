using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller_PlayerActions_PlayerCombat : MonoBehaviour
{
    #region FIELDS
    private Controller_PlayerManager playerGlobalController;

    private PlayerActions playerActions;

    private InputAction attackA;
    private InputAction attackB;
    #endregion

    #region PROPERTIES
    public PlayerActions PlayerActions { get { return playerActions; } }
    #endregion
    private void Awake(){
        playerActions = new PlayerActions();
        playerGlobalController = transform.GetComponent<Controller_PlayerManager>();
    }
    private void OnEnable(){
        attackA = playerActions.PlayerCharacterCombat.AttackA;
        attackB = playerActions.PlayerCharacterCombat.AttackB;

        attackA.Enable();
        attackB.Enable();
    }
    private void OnDisable(){
        attackA.Disable();
        attackB.Disable();
    }
}
