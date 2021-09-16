using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour, IEquipment{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] Equippable head;
    [SerializeField] Equippable chest;
    [SerializeField] Equippable arms;
    [SerializeField] Equippable forearms;
    [SerializeField] Equippable hands;
    [SerializeField] Equippable legs;
    [SerializeField] Equippable feet;
    [SerializeField] Bag rightHip;
    [SerializeField] Bag leftHip;
    [SerializeField] Bag rightUpperBack;
    [SerializeField] Bag leftUpperBack;
    [SerializeField] Bag back;
    [SerializeField] Equippable rightHand;
    [SerializeField] Equippable leftHand;
}
