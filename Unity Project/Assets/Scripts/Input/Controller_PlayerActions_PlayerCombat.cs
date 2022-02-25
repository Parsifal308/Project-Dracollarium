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
    private InputAction fightMode;
    private InputAction exploreMode;
    private InputAction reload;
    private InputAction aim;
    private InputAction attackDirection;
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
        fightMode = playerActions.PlayerCharacterCombat.FightMode;
        exploreMode = playerActions.PlayerCharacterCombat.ExploreMode;
        reload = playerActions.PlayerCharacterCombat.Reload;
        aim = playerActions.PlayerCharacterCombat.Aim;
        attackDirection = playerActions.PlayerCharacterCombat.AttackDirection;

        attackA.Enable();
        attackB.Enable();
        fightMode.Enable();
        exploreMode.Enable();
        aim.Enable();
        reload.Enable();
        attackDirection.Enable();

        attackA.performed += playerGlobalController.PlayerCombat.LightAttack;
        attackA.canceled += playerGlobalController.PlayerCombat.ResetLightAttack;
        fightMode.performed += playerGlobalController.PlayerCombat.EnterCombatMode;
        exploreMode.performed += playerGlobalController.PlayerCombat.ExitCombatMode;
        attackDirection.performed += playerGlobalController.PlayerCombat.SetAttackDirection;
        attackDirection.canceled += playerGlobalController.PlayerCombat.ResetAttackDirectionZero;
    }
    private void OnDisable(){
        attackA.Disable();
        attackB.Disable();
        fightMode.Disable();
        exploreMode.Disable();
        aim.Disable();
        reload.Disable();
        attackDirection.Disable();
    }
}
