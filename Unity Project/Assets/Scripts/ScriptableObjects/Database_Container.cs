using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database_Container : Database_Item{
    [Header("CONTAINER DATA:"), Space(10)]
    [SerializeField] private float size;

    public float Size { get { return size; } }
    public string ItemName { get { return name; } }
}