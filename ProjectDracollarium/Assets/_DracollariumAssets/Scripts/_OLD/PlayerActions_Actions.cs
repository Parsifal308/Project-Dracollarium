using UnityEngine;
using UnityEngine.InputSystem;
using Dracollarium.Player;

namespace Dracollarium.Input
{
    public class PlayerActions_Actions : MonoBehaviour
    {

        #region FIELDS
        private PlayerManager playerGlobalController;
        private PlayerActions playerActions;
        private InputAction actionA;
        private InputAction actionB;
        private InputAction actionC;
        private InputAction dropLeftItem;
        private InputAction dropRightItem;
        private InputAction grab;
        private InputAction take;
        #endregion

        #region PROPERTIES
        public PlayerActions PlayerActions { get { return playerActions; } }
        public InputAction ActionA { get { return actionA; } }
        public InputAction Grab { get { return grab; } }
        #endregion

        #region UNITY METHODS
        private void Awake()
        {
            playerActions = new PlayerActions();
            playerGlobalController = transform.GetComponent<PlayerManager>();
        }

        private void OnEnable()
        {
            actionA = playerActions.PlayerCharacterAction.ActionA;
            actionB = playerActions.PlayerCharacterAction.ActionB;
            actionC = playerActions.PlayerCharacterAction.ActionC;
            dropLeftItem = playerActions.PlayerCharacterAction.DropLeftItem;
            dropRightItem = playerActions.PlayerCharacterAction.DropRightItem;
            grab = playerActions.PlayerCharacterAction.Grab;
            take = playerActions.PlayerCharacterAction.Take;

            actionA.Enable();
            actionB.Enable();
            actionC.Enable();
            dropLeftItem.Enable();
            dropRightItem.Enable();
            grab.Enable();
            take.Enable();

            actionB.performed += playerGlobalController.PlayerItemPickup.ActionB;
            take.performed += playerGlobalController.PlayerItemPickup.Take;
            dropLeftItem.performed += playerGlobalController.PlayerItemPickup.Drop;
            dropRightItem.performed += playerGlobalController.PlayerItemPickup.Drop;
            grab.performed += playerGlobalController.PlayerItemPickup.Grab;
        }

        private void OnDisable()
        {
            actionA.Disable();
            actionB.Disable();
            actionC.Disable();
            dropLeftItem.Disable();
            dropRightItem.Disable();
            grab.Disable();
            take.Disable();
        }
        #endregion


    }

}