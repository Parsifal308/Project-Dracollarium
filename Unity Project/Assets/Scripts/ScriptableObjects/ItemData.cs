using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject{
    [Header("Item Basic Informacion:"), Space(10)]
    [SerializeField] int itemID;
    [SerializeField] string itemName;
    [TextArea(5, 10)]
    [SerializeField] string description;

    public int GetID { get { return itemID; } }
    public string GetName { get { return itemName; } }
    public string GetDescription { get { return description; } }
}
