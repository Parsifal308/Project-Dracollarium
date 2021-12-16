using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Material : MonoBehaviour ,I_ItemData{
    [Header("MATERIAL INFORMATION:"), Space(10)]
    [SerializeField] private Database_Material materialData;
    [SerializeField] private float quality;
    public float Quality { get { return quality; } set { quality = value; } }
    public float CurrentDurability { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float UsedSpace { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float EffectIntensity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public List<ItemStateStats> ItemsContainedData => throw new System.NotImplementedException();
    public Database_Item GetData { get { return materialData; } }
}
