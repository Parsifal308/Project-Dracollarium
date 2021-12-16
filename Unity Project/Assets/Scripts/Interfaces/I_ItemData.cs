using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_ItemData{
    public float CurrentDurability { get; set; }
    public float UsedSpace { get; set; }
    public float EffectIntensity { get; set; }
    public float Quality { get; set; }
    public List<ItemStateStats> ItemsContainedData { get ; }
    public Database_Item GetData { get; }

}
public struct ItemStateStats{
    public float? currentDurability;
    private float? usedSpace;
    private float? effectIntensity;
    private float? quality;
    private List<ItemStateStats> itemsContained;

    public ItemStateStats(float? currentDurability, float? usedSpace, float? effectIntensity, float? quality, List<ItemStateStats> itemsContained)
    {
        this.currentDurability = currentDurability;
        this.usedSpace = usedSpace;
        this.effectIntensity = effectIntensity;
        this.quality = quality;
        this.itemsContained = itemsContained;
    }

    public float? CurrentDurability{get { return currentDurability; }set { currentDurability = value; }
    }

}
