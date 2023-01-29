using System;
using System.Collections;
using System.Collections.Generic;
using Dracollarium.Character.Stats;
using UnityEngine;

namespace Dracollarium.Character.Abilities
{
    [Serializable]
    public class AttributeUsed
    {
        #region FIELDS
        [SerializeField] private Database_Attribute attribute;
        [SerializeField] private float amount;
        #endregion

        #region CONSTRUCTOR
        public AttributeUsed(Database_Attribute attribute, float amount)
        {
            this.attribute = attribute;
            this.amount = amount;
        }
        #endregion
    }
}