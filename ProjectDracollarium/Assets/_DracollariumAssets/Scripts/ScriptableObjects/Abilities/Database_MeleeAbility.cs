using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Abilities
{
    [CreateAssetMenu(fileName = "New Melee Ability", menuName = "Dracollarium/Ability/Melee")]
    public class Database_MeleeAbility : Database_Ability
    {
        [SerializeField] private float baseDamage;
    }

}