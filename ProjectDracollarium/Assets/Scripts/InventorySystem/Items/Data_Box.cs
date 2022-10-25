using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Box : Data_Container
{
    [Header("BOX INFORMATION:"), Space(10)]
    [SerializeField] private Database_Box boxData;
    public override Database_Item GetData { get { return boxData; } }
    public override float EffectIntensity { get; set; } = -1;
    public override float Quality { get; set; } = -1;
}
