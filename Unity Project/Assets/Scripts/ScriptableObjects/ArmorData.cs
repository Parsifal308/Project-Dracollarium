using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Game Database/Equippable/Armor")]
public class ArmorData : ScriptableObject{
    [SerializeField] public int armorId;
    [Space(10)]
    [SerializeField] armorType armorType;
    [SerializeField] armorPiece armorPiece;
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
enum armorType{
  Cloth,
  Light,
  Medium,
  Heavy,
  Natural,
  Magical,
  DEV
}
enum armorPiece{
    Head,
    Chest,
    Arm,
    Forearm,
    Hands,
    Legs,
    Feet
}

