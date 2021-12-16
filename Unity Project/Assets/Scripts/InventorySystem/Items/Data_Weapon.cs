using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Weapon : Data_Equippable, I_ItemData
{
    [Header("WEAPON INFORMATION:"), Space(10)]
    [SerializeField] private Database_Weapon weaponData;
    public override Database_Item GetData { get { return weaponData; } }
}
