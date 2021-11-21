using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Container", menuName = "Game Database/Item/Container/Bag")]
public class Database_Bag : Database_Container{
    [Header("BAG DATA:"), Space(10)]
    [SerializeField] private float cost;
    [SerializeField] private float quality;
}
enum bagType
{
    Bag,
    DEVELOPMENT
}
