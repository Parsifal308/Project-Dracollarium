using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Game Database/Equippable/Weapon")]
public class WeaponData : EquippableData{

    [Header("Weapon Information:")]
    [SerializeField] public int weaponId;
    [Space(10)]
    [SerializeField] weaponType weaponType;
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
    DEVELOPMENT
}
