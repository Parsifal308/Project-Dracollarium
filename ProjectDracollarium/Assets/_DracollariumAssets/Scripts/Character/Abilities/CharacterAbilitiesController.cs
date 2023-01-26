using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dracollarium.Character.Abilities;
using System;
using Dracollarium.Player;
using UnityEngine.InputSystem;

namespace Dracollarium.Character
{
    //SALTAR
    //CAMBIO DE VELOCIDAD
    //AGACHARSE
    //DASH
    //CONSUMIR ITEM
    public class CharacterAbilitiesController : MonoBehaviour
    {

        #region FIELDS
        [ShowOnly, SerializeField] private string locomotion = "None";
        [ShowOnly, SerializeField] private string ability = "None";
        private Locomotion currentLocomotion;
        private ActiveAbility currentActiveAbility;
        private PlayerManager playerManager;
        [Space(10), Header("LOCOMOTION:")]
        [Space(5), SerializeField] private List<Locomotion> locomotionAbilities;
        [Space(10), Header("COMBAT:")]
        [Space(5), SerializeField] private List<Melee> meleeAbilities;
        [Space(5), SerializeField] private List<Magic> magicAbilities;
        [Space(5), SerializeField] private List<Range> rangeAbilities;
        [Space(5), SerializeField] private List<Alchemy> alchemyAbilities;
        [Space(10), Header("UTILITY:")]
        [Space(5), SerializeField] private List<Utility> utilityAbilities;
        [Space(5), SerializeField] private List<MagicUtility> magicUtilityAbilities;
        [Space(5), SerializeField] private List<Crafting> craftingAbilities;

        #region DELEGATES
        public delegate void OnSprintCallback();
        #endregion

        #region EVENTS
        public event OnSprintCallback OnSprintPerformed, OnSprintCanceled;
        #endregion

        #endregion

        #region PROPERTIES
        public Locomotion CurrentLocomotion { get { return currentLocomotion; } set { currentLocomotion = value; locomotion = currentLocomotion.ability.AbilityName; } }
        public ActiveAbility CurrentActiveAbility { get { return currentActiveAbility; } set { currentActiveAbility = value; ability = currentActiveAbility.GetAbility().AbilityName; } }
        public List<Locomotion> LocomotionAbilities { get { return locomotionAbilities; } }
        public List<Melee> MeleeAbilities { get { return meleeAbilities; } }
        public List<Magic> MagicAbilities { get { return magicAbilities; } }
        public List<Range> RangeAbilities { get { return rangeAbilities; } }
        public List<Alchemy> AlchemyAbilities { get { return alchemyAbilities; } }
        public List<Utility> UtilityAbilities { get { return utilityAbilities; } }
        public List<MagicUtility> MagicUtilityAbilities { get { return magicUtilityAbilities; } }
        public List<Crafting> CraftingAbilities { get { return craftingAbilities; } }

        #region INPUT EVENTS METHODS
        internal void Sprint(InputAction.CallbackContext obj)
        {
            switch (obj.phase)
            {
                case InputActionPhase.Performed:
                    Debug.Log("SPRINT PERFORMED");
                    break;
                case InputActionPhase.Canceled:
                    Debug.Log("SPRINT CANCELED");
                    break;
            }

        }

        internal void Walk(InputAction.CallbackContext obj)
        {
            Debug.Log("WALKING");
        }
        #endregion

        #endregion

        #region UNITY METHODS
        void Start()
        {
            playerManager = GetComponent<PlayerManager>();

            //START TESTING (DELETE LATER)
            currentLocomotion = LocomotionAbilities[0]; //ALGO ASI MANEJADO POR LOS INPUTS
            //END TESTEING
        }
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        public Locomotion GetLocomotion(string ability)
        {
            foreach (Locomotion locomotionAbility in locomotionAbilities)
            {
                if (locomotionAbility.ability.AbilityName == ability) return locomotionAbility;
            }
            return new Locomotion(null, AbilityPhase.NotAvalaible);
        }
        #endregion

        #region STRUCTS
        [Serializable]
        public struct Locomotion
        {
            public Database_LocomotionAbility ability;
            public AbilityPhase phase;
            public Locomotion(Database_LocomotionAbility ability, AbilityPhase phase)
            {
                this.ability = ability;
                this.phase = phase;
            }
        }
        [Serializable]
        public struct Melee : ActiveAbility
        {
            public Database_MeleeAbility ability;
            public AbilityPhase phase;

            public Database_Ability GetAbility()
            {
                return ability;
            }

            public AbilityPhase GetPhase()
            {
                return phase;
            }
        }
        [Serializable]
        public struct Utility : ActiveAbility
        {
            public Database_UtilityAbility ability;
            public AbilityPhase phase;

            public Database_Ability GetAbility()
            {
                return ability;
            }

            public AbilityPhase GetPhase()
            {
                return phase;
            }
        }
        [Serializable]
        public struct Magic : ActiveAbility
        {
            public Database_MagicAbility ability;
            public AbilityPhase phase;

            public Database_Ability GetAbility()
            {
                return ability;
            }

            public AbilityPhase GetPhase()
            {
                return phase;
            }
        }
        [Serializable]
        public struct MagicUtility : ActiveAbility
        {
            public Database_MagicUtilityAbility ability;
            public AbilityPhase phase;

            public Database_Ability GetAbility()
            {
                return ability;
            }

            public AbilityPhase GetPhase()
            {
                return phase;
            }
        }
        [Serializable]
        public struct Range : ActiveAbility
        {
            public Database_RangeAbility ability;
            public AbilityPhase phase;

            public Database_Ability GetAbility()
            {
                return ability;
            }

            public AbilityPhase GetPhase()
            {
                return phase;
            }
        }
        [Serializable]
        public struct Alchemy : ActiveAbility
        {
            public Database_AlchemyCombatAbility ability;
            public AbilityPhase phase;

            public Database_Ability GetAbility()
            {
                return ability;
            }

            public AbilityPhase GetPhase()
            {
                return phase;
            }
        }
        [Serializable]
        public struct Crafting : ActiveAbility
        {
            public Database_CraftingAbility ability;
            public AbilityPhase phase;

            public Database_Ability GetAbility()
            {
                return ability;
            }

            public AbilityPhase GetPhase()
            {
                return phase;
            }
        }
        #endregion
    }
    #region ENUMS
    public enum AbilityPhase
    {
        Ready,
        Started,
        Finished,
        Interrupted,
        Cancelled,
        NotAvalaible
    }
    #endregion

    #region INTERFACE
    public interface ActiveAbility
    {
        public Database_Ability GetAbility();
        public AbilityPhase GetPhase();
    }
    #endregion
}