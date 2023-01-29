using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character
{
    [CreateAssetMenu(fileName = "New Character State", menuName = "Dracollarium/Character/State")]
    public class CharacterState : ScriptableObject
    {
        [SerializeField] private string stateName;
    }
}