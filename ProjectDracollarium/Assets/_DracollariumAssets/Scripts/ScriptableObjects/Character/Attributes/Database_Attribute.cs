using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Stats
{
    [CreateAssetMenu(fileName = "New Attributte", menuName = "Dracollarium/Stats/Attribute")]
    public class Database_Attribute : ScriptableObject
    {
        #region FIELDS
        [Header("INFORMATION:"), Space(5)]
        [SerializeField] private string attributeName;
        [SerializeField, TextArea(10, 30)] private string attributeDescription;
        #endregion

        #region PROPERTIES
        public string AttributeName { get { return attributeName; } }
        public string AttributeDescription { get { return attributeDescription; } }
        #endregion

        #region UNITY METHODS
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        #endregion
    }
}