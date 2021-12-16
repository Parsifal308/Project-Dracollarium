using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Armor : Data_Equippable, I_ItemData{

    [Header("ARMOR INFORMATION:"), Space(10)]
    [SerializeField] private Database_Armor armorData;

    public override Database_Item GetData { get { return armorData; } }
}
