using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour, I_Item{
    [Header("Consumable Information:"), Space(10)]
    [SerializeField] ConsumableData consumableData;
    [SerializeField] float usedSpace;
    [SerializeField] float currentDurability;
    [SerializeField] float effectIntensity;
    [SerializeField] float quality;

    public float CurrentDurability { get { return currentDurability; } set { currentDurability = value; } }
    public float UsedSpace { get { return usedSpace; } set { usedSpace = value; } }
    public float EffectIntensity { get { return effectIntensity; } set { effectIntensity = value; } }
    public float Quality { get { return quality; } set { quality = value; } }
    public List<ItemStateStats> ItemsContainedData => throw new System.NotImplementedException();
}
