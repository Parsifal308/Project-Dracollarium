using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dracollarium.Input;
using Dracollarium.UI;
using Dracollarium.Character;

namespace Dracollarium.Player
{
    //╔══════════╗
    //║ Box Menu ║
    //╚══════════╝
    //=========================================================================================================
    //      This script is responsible for saving references to all the components necessary to make the     ||
    //  player character works. It has the necessary methods to enable and disable the functionalities       ||
    //=========================================================================================================
    /*
    [RequireComponent(typeof(UIController))]
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(CameraController))]
    [RequireComponent(typeof(InputsController))]
    [RequireComponent(typeof(AnimationsController))]

    [RequireComponent(typeof(Player_Equipment))]
    [RequireComponent(typeof(CharacterAttributesController))]
    [RequireComponent(typeof(Player_ItemPickup))]
    [RequireComponent(typeof(Player_ModularBuilding))]
    [RequireComponent(typeof(Player_Combat))]*/
    public class PlayerManager : MonoBehaviour
    {

        #region FIELDS
        [Header("CONTROLLERS:"), Space(10)]
        [SerializeField] private UIController uIController; //OCULTAR EN EL EDITOR DESPUES
        [SerializeField] private MovementController movementController; //OCULTAR EN EL EDITOR DESPUES
        [SerializeField] private CameraController cameraController; //OCULTAR EN EL EDITOR DESPUES
        [SerializeField] private InputsController inputsController; //OCULTAR EN EL EDITOR DESPUES
        [SerializeField] private AnimationsController animationsController; //OCULTAR EN EL EDITOR DESPUES
        [SerializeField] private CharacterAbilitiesController characterAbilitiesController;

        [Header("PLAYER SYSTEMS:"), Space(25)]
        [SerializeField] private Player_Equipment playerEquipment;
        [SerializeField] private CharacterAttributesController playerStats;
        [SerializeField] private Player_ItemPickup playerItemPickUp;
        [SerializeField] private Player_ModularBuilding playerModularBuilding;
        [SerializeField] private Player_Combat playerCombat;
        private IFabricate[] fabricationActions; //VER COMO FUNCIONALIZAR ESTO MEJOR

        [Header("PLAYER MODES:"), Space(5)]
        [SerializeField] private GameMode playerGameMode;
        [SerializeField] private bool buildingMode;
        #endregion

        #region PROPERTIES
        public CharacterAbilitiesController CharacterAbilitiesController { get { return characterAbilitiesController; } }
        public InputsController InputsController { get { return inputsController; } }
        public UIController UIController { get { return uIController; } }
        public CameraController CameraController { get { return cameraController; } }
        public MovementController MovementController { get { return movementController; } }
        public AnimationsController AnimationsController { get { return animationsController; } }
        public Player_Combat PlayerCombat { get { return playerCombat; } }
        public Player_Equipment PlayerEquipment { get { return playerEquipment; } }
        public CharacterAttributesController PlayerStats { get { return playerStats; } }
        public Player_ItemPickup PlayerItemPickup { get { return playerItemPickUp; } set { playerItemPickUp = value; } }
        public Player_ModularBuilding PlayerModularBuilding { get { return playerModularBuilding; } set { playerModularBuilding = value; } }
        #endregion

        #region PUBLIC METHODS
        public void ChangeCameraScript(ICamera currentCam, ICamera objectiveCam)
        {
            currentCam.Enabled = false;
            objectiveCam.Enabled = true;
        }
        public void DisableItemCollection()
        { //called from gui button event
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling player items collection system.....");
                playerItemPickUp.enabled = false;
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player items collection system DISABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] A '" + ex.GetType() + "' has ocurred.");
            }
        }
        public void EnableItemCollection()
        { //called from gui button event
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling player items collection system.....");
                playerItemPickUp.enabled = true;
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player items collection system ENABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
            }
        }
        public void EnableItemCollection(object sender, EventArgs e)
        {
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling player items collection system.....");
                playerItemPickUp.enabled = true;
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player items collection system ENABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
            }
        }
        public void EnableBuildingPositioning()
        {
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling player building positioning.....");
                playerModularBuilding.EnablePositioning();
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player building positioning ENABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
            }
        }

        public void DisableBuildingPositioning()
        {
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling player building positioning.....");
                playerModularBuilding.DisablePositioning();
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player building positioning DISABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
            }
        }
        public void DisableBuildingPositioning(object sender, EventArgs e)
        {
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling player building positioning.....");
                playerModularBuilding.DisablePositioning();
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Player building positioning DISABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] A '" + ex.GetType() + " has ocurred.");
            }
        }
        public void EnableMouseRotation()
        {
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling mouse rotation...");
                CameraController.IsMouseEnabled = true;
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] mouse rotation ENABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
            }
        }
        public void DisableMouseRotation()
        {
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling mouse rotation...");
                CameraController.IsMouseEnabled = false;
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] mouse rotation DISABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
            }
        }
        public void EnableMouseRotation(object sender, EventArgs e)
        {
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Enabling mouse rotation...");
                CameraController.IsMouseEnabled = true;
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] mouse rotation ENABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
            }
        }
        public void DisableMouseRotation(object sender, EventArgs e)
        {
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Disabling mouse rotation script...");
                CameraController.IsMouseEnabled = false;
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] mouse rotation DISABLED.");
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] an error of type '" + ex.GetType() + "' has ocurred");
            }
        }
        public void PositionBuilding(GameObject building)
        {
            try
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Positioning building...");
                playerModularBuilding.PositionBuilding(building);
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] An error of type '" + ex.GetType() + "' has ocurred!!!");
            }
        }
        #endregion

        #region UNITY METHODS
        void Awake()
        {
            inputsController = GetComponent<InputsController>();
            movementController = GetComponent<MovementController>();
            animationsController = GetComponent<AnimationsController>();
            uIController = GetComponent<UIController>();
            cameraController = GetComponent<CameraController>();
            characterAbilitiesController = GetComponent<CharacterAbilitiesController>();

            playerItemPickUp = GetComponent<Player_ItemPickup>();
            fabricationActions = gameObject.GetComponents<IFabricate>();
        }
        #endregion

    }
    #region ENUMERATORS
    public enum GameMode
    {
        DevMode,
        GodMode,
        SurvivalMode,
        StoryMode
    }
    #endregion

    /*
     * Debug.LogFormat("This is <color=#ff0000>{0}</color>", "red");
     * Debug.LogFormat("This is <color=#00ff00>{0}</color>", "green");
     * Debug.LogFormat("This is <color=#0000ff>{0}</color>", "blue");
     * Debug.LogFormat("This is <color=yellow>{0}</color>", "yellow");
    */
}