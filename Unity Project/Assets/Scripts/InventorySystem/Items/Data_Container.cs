using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Data_Container : MonoBehaviour, I_ItemData{
    [Header("CONTAINER INFORMATION:"), Space(10)]
    [SerializeField] protected float usedSpace;
    [SerializeField] protected float currentDurability;
    List<I_ItemData> itemsContainer;

    public float CurrentDurability { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float UsedSpace { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float EffectIntensity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float Quality { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public List<ItemStateStats> ItemsContainedData => throw new System.NotImplementedException();

    abstract public Database_Item GetData { get; }
}
