using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Material : MonoBehaviour ,I_ItemData{
    [Header("MATERIAL INFORMATION:"), Space(10)]
    [SerializeField] private Database_Material materialData;
    [SerializeField] private float quality;
    public float CurrentDurability { get; set; } = -1;
    public float EffectIntensity { get; set; } = -1;
    public float Quality { get { return quality; } set { quality = value; } }
    public List<ItemStateStats> ItemsContainedData { get; } = null;
    public Database_Item GetData { get { return materialData; } }
    public float UsedSpace { get; set; } = -1;

}
