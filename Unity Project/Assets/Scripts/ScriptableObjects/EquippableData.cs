using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableData : ItemData{
    [Header("EQUIPABBLE DATA:"), Space(10)]
    [Header("Equippable Stats:")]
    [SerializeField] float cost;
    [SerializeField] float quality;
    [SerializeField] float durability;
    [SerializeField] float size;

    [Header("Attribute Requirements:"), Space(30)]
    [SerializeField] float strengthReq;
    [SerializeField] float volitionReq;
    [SerializeField] float dexteryReq;
    [SerializeField] float enduranceReq;
    [SerializeField] float concentrationReq;

    [Header("Attribute Modifiers:"), Space(30)]
    [SerializeField] float strengthMod;
    [SerializeField] float volitionMod;
    [SerializeField] float dexteryMod;
    [SerializeField] float enduranceMod;
    [SerializeField] float concentrationMod;
}
