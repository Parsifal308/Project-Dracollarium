using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Data_Equippable : MonoBehaviour, I_ItemData{
    [Header("EQUIPPABLE INFORMATION:"), Space(10)]
    [SerializeField] protected float usedSpace;
    [SerializeField] protected float currentDurability;
    [SerializeField] protected float effectIntensity;
    [SerializeField] protected float quality;

    public float CurrentDurability { get { return currentDurability; } set { currentDurability = value; } }
    public float EffectIntensity { get { return effectIntensity; } set { effectIntensity = value; } }
    public float Quality { get { return quality; } set { quality = value; } }
    public List<ItemStateStats> ItemsContainedData => throw new System.NotImplementedException();

    abstract public Database_Item GetData { get; }

    float I_ItemData.UsedSpace { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
