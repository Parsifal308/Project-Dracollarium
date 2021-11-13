using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Game Database/Consumable")]
public class ConsumableData : ItemData{
    [Header("CONSUMABLE DATA:"), Space(10)]
    [SerializeField] consumableType consumableType;
    [SerializeField] float cost;
    [SerializeField] float quality;
    [SerializeField] float size;
}
enum consumableType{
    Food,
    Potion,
    Artefact,
    Quest,
    Scroll,
    DEVELOPMENT
}