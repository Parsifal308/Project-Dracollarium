using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Resources
{
    [Serializable]
    public class CharacterResource
    {
        #region FIELDS
        [Header("RESOURCE SETTINGS")]
        [SerializeField] private Database_CharacterResource resource;
        [SerializeField] private float max;
        [SerializeField] private float current;

        [Space(20), Header("GENERATION SETTINGS")]
        [SerializeField] private ResourceUpdate updateMode;
        [SerializeField] private float amountPerTick;
        #endregion

        #region PROPERTIES
        #endregion

        #region PUBLIC METHODS
        public void Update(object sender, EventArgs e)
        {
            switch (updateMode)
            {
                case ResourceUpdate.INCREASE:
                    if (current < max)
                    {
                        current += amountPerTick;
                    }
                    break;
                case ResourceUpdate.DECREASE:
                    if (current > 0f)
                    {
                        current -= amountPerTick;
                    }
                    break;
            }
            current = Mathf.Clamp(current, 0, max);
        }
        #endregion

        #region PRIVATE METHODS

        #endregion
    }
    enum ResourceUpdate
    {
        NONE,
        INCREASE,
        DECREASE
    }
}