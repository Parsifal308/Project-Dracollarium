using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Game Database/Equippable/Armor")]
public class ArmorData : EquippableData{
    [Header("Armor Information:")]
    [SerializeField] public int armorId;
    [Space(10)]
    [SerializeField] armorType armorType;
    [SerializeField] armorPiece armorPiece;
}
enum armorType{
  Cloth,
  Light,
  Medium,
  Heavy,
  Natural,
  Magical,
  DEVELOPMENT
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

