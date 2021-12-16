using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Consumable : MonoBehaviour, I_ItemData{
    [Header("CONSUMABLE INFORMATION:"), Space(10)]
    [SerializeField] private Database_Consumable consumableData;
    [SerializeField] private float currentDurability;
    [SerializeField] private float effectIntensity;
    [SerializeField] private float quality;

    public float CurrentDurability { get { return currentDurability; } set { currentDurability = value; } }
    public float EffectIntensity { get { return effectIntensity; } set { effectIntensity = value; } }
    public float Quality { get { return quality; } set { quality = value; } }
    public List<ItemStateStats> ItemsContainedData => throw new System.NotImplementedException();
    public Database_Item GetData { get { return consumableData; } }
    public float UsedSpace { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
