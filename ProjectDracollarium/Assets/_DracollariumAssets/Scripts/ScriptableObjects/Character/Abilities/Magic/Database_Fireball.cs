using System.Collections;
using System.Collections.Generic;
using Dracollarium.Character.Abilities;
using UnityEngine;

namespace Dracollarium.Character.Abilities
{
    [CreateAssetMenu(fileName = "New Fireball", menuName = "Dracollarium/Ability/Magic/Fireball")]
    public class Database_Fireball : Database_MagicAbility
    {
        #region FIELDS
        #endregion

        #region PROPERTIES
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