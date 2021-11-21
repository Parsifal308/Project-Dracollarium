using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database_Item : ScriptableObject{
    [Header("Item Basic Informacion:"), Space(10)]
    [SerializeField] private int itemID;
    [SerializeField] private string itemName;
    [TextArea(5, 10)]
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;

    public int GetID { get { return itemID; } }
    public string GetName { get { return itemName; } }
    public string GetDescription { get { return description; } }
}
