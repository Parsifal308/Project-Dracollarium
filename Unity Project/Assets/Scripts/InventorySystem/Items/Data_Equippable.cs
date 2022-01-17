using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Data_Equippable : MonoBehaviour, I_ItemData{
    [Header("EQUIPPABLE INFORMATION:"), Space(10)]
    [SerializeField] protected float usedSpace;
    [SerializeField] protected float currentDurability;
    [SerializeField] protected float effectIntensity;
    [SerializeField] protected float quality;
    [SerializeField] protected string prefabDirectory;

    public float CurrentDurability { get { return currentDurability; } set { currentDurability = value; } }
    public float EffectIntensity { get { return effectIntensity; } set { effectIntensity = value; } }
    public float Quality { get { return quality; } set { quality = value; } }
    abstract public Database_Item GetData { get; }
    public float UsedSpace { get { return usedSpace; } set { usedSpace = value; } }
    public List<ItemStateStats> ItemsContainedData { get; } = null;
}
