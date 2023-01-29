using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character.Stats
{
    [CreateAssetMenu(fileName = "New Armor Type", menuName = "Dracollarium/Stats/Armor Type")]
    public class Database_ArmorType : ScriptableObject
    {
        #region FIELDS
        [SerializeField] private string damageName;
        [SerializeField] private Sprite damageIcon;
        [SerializeField, TextArea(10, 30)] private string attributeDescription;
        [SerializeField]private List<ArmorDamageRatio> armorDamageRatios;
        #endregion
    }
}