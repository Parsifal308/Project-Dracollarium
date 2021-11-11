using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Game Database/Consumable")]
public class ConsumableData : ScriptableObject{
    [SerializeField] public int consumableId;
    [SerializeField] consumableType consumableType;
    [TextArea(5, 10)]
    [SerializeField] string itemName;
    [TextArea(5, 10)]
    [SerializeField] string description;
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