using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour, IEquipment{
    [SerializeField] Controller_PlayerManager playerManager;
    [SerializeField] Data_Equippable head;
    [SerializeField] Data_Equippable chest;
    [SerializeField] Data_Equippable arms;
    [SerializeField] Data_Equippable forearms;
    [SerializeField] Data_Equippable hands;
    [SerializeField] Data_Equippable legs;
    [SerializeField] Data_Equippable feet;
    [SerializeField] Data_Bag rightHip;
    [SerializeField] Data_Bag leftHip;
    [SerializeField] Data_Bag rightUpperBack;
    [SerializeField] Data_Bag leftUpperBack;
    [SerializeField] Data_Bag back;
    [SerializeField] Data_Equippable rightHand;
    [SerializeField] Data_Equippable leftHand;

}
