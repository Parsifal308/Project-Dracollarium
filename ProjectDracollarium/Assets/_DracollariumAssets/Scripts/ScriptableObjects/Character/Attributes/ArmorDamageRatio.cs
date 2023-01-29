using System;
using System.Collections;
using System.Collections.Generic;
using Dracollarium.Character.Stats;
using UnityEngine;

[Serializable]
public class ArmorDamageRatio
{
    [SerializeField] private Database_DamageType damageType;
    [SerializeField] private float effectivenessModifier = 1;
}
