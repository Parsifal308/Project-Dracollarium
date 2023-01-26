using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Abilities
{
    public abstract class Database_Ability : ScriptableObject
    {
        #region FIELDS
        [Header("ABILITY INFORMATION")]
        [Tooltip("The name of the ability")]
        [SerializeField] protected string abilityName;
        [Tooltip("In-game ability description")]
        [SerializeField, TextArea(10, 30)] protected string abilityDescription;

        [Tooltip("Ability icon for the UI")]
        [SerializeField] protected Sprite abilityIcon;

        [Space(20), Header("ABILITY SETTINGS:")]
        [Tooltip("The ability ID")]
        [SerializeField] protected int abilityId = -1;
        [Tooltip("Ability animation index, must match the corresponding animation in the character animator")]
        [SerializeField] protected int abilityAnimationIndex;
        #endregion

        #region PROPERTIES
        public int AbilityID { get { return abilityId; } }
        public string AbilityName { get { return abilityName; } }
        public string AbilityDescription { get { return abilityDescription; } }
        public Sprite AbilityIcon { get { return abilityIcon; } }
        public int AbilityAnimationIndex { get { return abilityAnimationIndex; } }
        #endregion

        #region UNITY METHODS
        #endregion
        #region PRIVATE METHODS
        #endregion
        #region PUBLIC METHODS
        #endregion
    }
}