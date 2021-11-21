using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Bag : Data_Container, I_Item {
    [Header("BAG INFORMATION:"), Space(10)]
    [SerializeField] private Database_Bag bagData;
    [SerializeField] private float effectIntensity;
    [SerializeField] private float quality;

    [Header("ITEMS CONTAINED:"), Space(10)]
    [SerializeField] List<ItemStateStats> itemsContainedData = new List<ItemStateStats>();

    [Header("-> TESTING <-"), Space(10)]
    public GameObject itemA;
    public GameObject itemB;

    public override Database_Item GetData { get { return bagData; } }
    public float CurrentDurability { get { return currentDurability; } set { currentDurability = value; } }
    public float UsedSpace { get { return usedSpace; } set { usedSpace = value; } }
    public float EffectIntensity { get { return effectIntensity; } set {effectIntensity = value; } }
    public float Quality { get { return quality; } set { quality = value; } }
    public List<ItemStateStats> ItemsContainedData { get { return itemsContainedData; } }

}
