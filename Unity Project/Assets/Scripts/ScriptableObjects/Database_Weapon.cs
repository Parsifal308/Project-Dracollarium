using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Game Database/Item/Equippable/Weapon")]
public class Database_Weapon : Database_Equippable{

    [Header("WEAPON DATA:"),Space(10)]
    [SerializeField] private weaponType weaponType;
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
