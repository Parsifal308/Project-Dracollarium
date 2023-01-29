using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Resources
{
    [CreateAssetMenu(fileName = "New Character Resource", menuName = "Dracollarium/Character/Resource")]
    public class Database_CharacterResource : ScriptableObject
    {
        #region FIELDS
        [SerializeField] private string resourceName = "New Resource";
        #endregion

        #region PROPERTIES
        public string ResourceName { get { return resourceName; } }
        #endregion
    }
}