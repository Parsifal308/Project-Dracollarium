using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database_Equippable : Database_Item{
    [Header("EQUIPABBLE DATA:"), Space(10)]
    [Header("Equippable Stats:")]
    [SerializeField] private float cost;
    [SerializeField] private float quality;
    [SerializeField] private float durability;
    [SerializeField] private float size;

    [Header("Attribute Requirements:"), Space(30)]
    [SerializeField] private float strengthReq;
    [SerializeField] private float volitionReq;
    [SerializeField] private float dexteryReq;
    [SerializeField] private float enduranceReq;
    [SerializeField] private float concentrationReq;

    [Header("Attribute Modifiers:"), Space(30)]
    [SerializeField] private float strengthMod;
    [SerializeField] private float volitionMod;
    [SerializeField] private float dexteryMod;
    [SerializeField] private float enduranceMod;
    [SerializeField] private float concentrationMod;
}
