using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Dracollarium/Item/Consumable")]
public class Database_Consumable : Database_Item{
    [Header("CONSUMABLE DATA:"), Space(10)]
    [SerializeField] private consumableType consumableType;
    [SerializeField] private float cost;
    [SerializeField] private float quality;
    [SerializeField] private float size;
}
enum consumableType{
    Food,
    Potion,
    Artefact,
    Quest,
    Scroll,
    DEVELOPMENT
}