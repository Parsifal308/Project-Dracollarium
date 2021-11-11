using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableData : ScriptableObject{

    [Header("Equippable Stats:")]
    [SerializeField] string itemName;
    [TextArea(5, 10)]
    [SerializeField] string description;
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
