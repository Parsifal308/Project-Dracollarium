using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Abilities
{
    [CreateAssetMenu(fileName = "New Locomotion Ability", menuName = "Dracollarium/Ability/Locomotion")]
    public class Database_LocomotionAbility : Database_Ability
    {
        #region FIELDS
        [Space(20), Header("LOCOMOTION SETTINGS:")]
        [Tooltip("The amount by which the base velocity will be multiplied")]
        [SerializeField] private float speedModifier = -1;
        #endregion

        #region PROPERTIES
        public float SpeedModifier { get { return speedModifier; } }




        #endregion

        #region UNITY METHODS
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        public override void Activate()
        {
            throw new System.NotImplementedException();
        }

        public override void Activate(GameObject objective)
        {
            throw new System.NotImplementedException();
        }

        public override void Activate(Vector3 location)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }

}