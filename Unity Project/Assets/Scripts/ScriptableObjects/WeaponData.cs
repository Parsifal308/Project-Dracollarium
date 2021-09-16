using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Game Database/Equippable/Weapon")]
public class WeaponData : ScriptableObject{


    [SerializeField] public int weaponId;
    [Space(10)]
    [SerializeField] weaponType weaponType;
    [SerializeField] string itemName;
    [TextArea(5, 10)]
    [SerializeField] string description;
    [SerializeField] float cost;
    [SerializeField] float quality;
    [SerializeField] float durability;
    [SerializeField] float size;

    //Atribute Requisits
    [Space(30)]
    [SerializeField] float strengthReq;
    [SerializeField] float volitionReq;
    [SerializeField] float dexteryReq;
    [SerializeField] float enduranceReq;
    [SerializeField] float concentrationReq;

    //Attribute Modifier
    [Space(30)]
    [SerializeField] float strengthMod;
    [SerializeField] float volitionMod;
    [SerializeField] float dexteryMod;
    [SerializeField] float enduranceMod;
    [SerializeField] float concentrationMod;
}
enum weaponType{
    OneHandedSword,
    TwoHandedSword,
    OneHandedAxe,
    TwoHandedAxe,
    OneHandedMace,
    TwoHandedMace,
    Spear,
    Lance,
    Javelin,
    Atlatl,
    Bow,
    ThrowingAxe,
    Boomstick,
    Tool,
    DEV
}
