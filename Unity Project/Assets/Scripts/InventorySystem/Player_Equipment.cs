using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Equipment : MonoBehaviour, IEquipment{
    [SerializeField] Controller_PlayerManager playerManager;
    [SerializeField] Database_Armor head;
    [SerializeField] Database_Armor chest;
    [SerializeField] Database_Armor arms;
    [SerializeField] Database_Armor forearms;
    [SerializeField] Database_Armor hands;
    [SerializeField] Database_Armor legs;
    [SerializeField] Database_Armor feet;
    [SerializeField] Data_Bag rightHip;
    [SerializeField] Data_Bag leftHip;
    [SerializeField] Data_Bag rightUpperBack;
    [SerializeField] Data_Bag leftUpperBack;
    [SerializeField] Data_Bag back;
    [SerializeField] Database_Weapon rightHand;
    [SerializeField] Database_Weapon leftHand;

}
