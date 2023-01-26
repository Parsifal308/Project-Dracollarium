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
    [SerializeField] private GameObject prefab;

    public int ItemID { get { return itemID; } }
    public string ItemName { get { return itemName; } }
    public string Description { get { return description; } }
    public GameObject Prefab { get { return prefab; } }
}
