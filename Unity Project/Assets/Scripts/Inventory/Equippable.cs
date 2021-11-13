using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour, I_Item{
    [Header("Equippable Information:"), Space(10)]
    [SerializeField] EquippableData equippableData;
    [SerializeField] float usedSpace;
    [SerializeField] float currentDurability;
    [SerializeField] float effectIntensity;
    [SerializeField] float quality;

    public EquippableData EquippableData { get { return equippableData; } }
    public float CurrentDurability { get { return currentDurability; } set { currentDurability = value; } }
    public float EffectIntensity { get { return effectIntensity; } set { effectIntensity = value; } }
    public float Quality { get { return quality; } set { quality = value; } }
    public List<ItemStateStats> ItemsContainedData => throw new System.NotImplementedException();
    float I_Item.UsedSpace { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public ItemData GetData { get { return equippableData; } }
}
