using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour, I_Item {
    [Header("Container Information:"), Space(10)]
    [SerializeField] ContainerData bagData;
    [SerializeField] float usedSpace;
    [SerializeField] float currentDurability;
    [SerializeField] float effectIntensity;
    [SerializeField] float quality;

    [Header("Items Contained:"), Space(10)]
    [SerializeField] List<ItemStateStats> itemsContainedData = new List<ItemStateStats>();

    [Header("TESTING"), Space(10)]
    public GameObject itemA;
    public GameObject itemB;

    public ContainerData BagData { get { return bagData; } }
    public float CurrentDurability { get { return currentDurability; } set { currentDurability = value; } }
    public float UsedSpace { get { return usedSpace; } set { usedSpace = value; } }
    public float EffectIntensity { get { return effectIntensity; } set {effectIntensity = value; } }
    public float Quality { get { return quality; } set { quality = value; } }
    public List<ItemStateStats> ItemsContainedData { get { return itemsContainedData; } }
    public ItemData GetData { get { return bagData; } }

}
