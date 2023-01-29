using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Stats
{
    [Serializable]
    public class CharacterAttribute
    {
        #region FIELDS
        [SerializeField] private Database_Attribute attribute;
        [SerializeField] private int baseAttribute = 1;
        [SerializeField] private int totalAttribute;
        #endregion

        #region PROPERTIES
        public Database_Attribute Attribute { get { return attribute; } set { attribute = value; } }
        public int BaseAttribute { get { return baseAttribute; } set { baseAttribute = value; } }
        public int TotalAttribute { get { return totalAttribute; } set { totalAttribute = value; } }
        #endregion

        #region UNITY METHODS
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        #endregion

    }
}