using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public interface I_ItemData{
    public float CurrentDurability { get; set; }
    public float UsedSpace { get; set; }
    public float EffectIntensity { get; set; }
    public float Quality { get; set; }
    public Database_Item GetData { get; }
    public List<ItemStateStats> ItemsContainedData { get; }

}
public struct ItemStateStats{
    public float currentDurability;
    public float usedSpace;
    public float effectIntensity;
    public float quality;
    public List<ItemStateStats> itemsContained;
    public Database_Item data;

    public ItemStateStats(float currentDurability, float usedSpace, float effectIntensity, float quality, List<ItemStateStats> itemsContained, Database_Item data){
        this.currentDurability = currentDurability;
        this.usedSpace = usedSpace;
        this.effectIntensity = effectIntensity;
        this.quality = quality;
        this.itemsContained = itemsContained;
        this.data = data;
    }
    public ItemStateStats(float currentDurability)
    {
        this.currentDurability = currentDurability;
        this.usedSpace = 0;
        this.effectIntensity = 0;
        this.quality = 0;
        this.itemsContained = null;
        this.data = null;
    }
    public ItemStateStats(Database_Item data)
    {
        this.currentDurability = 0;
        this.usedSpace = 0;
        this.effectIntensity = 0;
        this.quality = 0;
        this.itemsContained = null;
        this.data = data;
    }
}
