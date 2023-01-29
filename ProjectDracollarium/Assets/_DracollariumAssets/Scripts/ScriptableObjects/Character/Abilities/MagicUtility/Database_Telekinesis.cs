using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Abilities
{
    [CreateAssetMenu(fileName = "New Telekinesis Spell", menuName = "Dracollarium/Ability/Magic Utility/Telekinesis")]
    public class Database_Telekinesis : Database_MagicUtilityAbility
    {
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