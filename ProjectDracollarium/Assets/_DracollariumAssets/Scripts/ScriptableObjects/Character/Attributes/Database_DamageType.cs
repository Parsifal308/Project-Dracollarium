using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Stats
{
    [CreateAssetMenu(fileName = "New Damage Type", menuName = "Dracollarium/Stats/Damage Type")]
    public class Database_DamageType : ScriptableObject
    {
        #region FIELDS
        [SerializeField] private string damageName;
        [SerializeField] private Sprite damageIcon;
        [SerializeField, TextArea(10, 30)] private string attributeDescription;
        #endregion
    }
}