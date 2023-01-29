using System.Collections;
using System.Collections.Generic;
using Dracollarium.Character.Abilities;
using UnityEngine;

namespace Dracollarium.Character.Abilities
{
    [CreateAssetMenu(fileName = "New Throw Grenade Ability", menuName = "Dracollarium/Ability/Alchemy/Throw")]
    public class Database_ThrowGrenade : Database_AlchemyCombatAbility
    {
        #region FIELDS
        [Header("THROW SETTINGS")]
        [SerializeField] private GameObject grenadeModel;

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