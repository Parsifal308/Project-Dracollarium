using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Dracollarium/Item/Equippable/Armor")]
public class Database_Armor : Database_Equippable{
    [Header("ARMOR DATA:"), Space(10)]
    [SerializeField] private armorType armorType;
    [SerializeField] private armorPiece armorPiece;
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

