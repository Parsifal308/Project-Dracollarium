using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Abilities
{
    public abstract class Database_Ability : ScriptableObject
    {
        #region FIELDS
        [Header("ABILITY BASE INFORMATION")]
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
        [SerializeField] private List<AttributeUsed> attributes;
        [SerializeField] private float effectivenessModifier = 1;
        #endregion

        #region PROPERTIES
        public int AbilityID { get { return abilityId; } }
        public string AbilityName { get { return abilityName; } }
        public string AbilityDescription { get { return abilityDescription; } }
        public Sprite AbilityIcon { get { return abilityIcon; } }
        public int AbilityAnimationIndex { get { return abilityAnimationIndex; } }
        public List<AttributeUsed> Attributes { get { return attributes; } }
        public float EffectivenessModifier { get { return effectivenessModifier; } }
        #endregion

        #region UNITY METHODS
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        public abstract void Activate();
        public abstract void Activate(GameObject objective);
        public abstract void Activate(Vector3 location);
        #endregion
    }
}