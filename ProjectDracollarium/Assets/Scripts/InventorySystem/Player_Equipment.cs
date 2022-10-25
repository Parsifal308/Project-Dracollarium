using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Equipment : MonoBehaviour, IEquipment{
    [SerializeField] Controller_PlayerManager controller_PlayerManager;

    [Header("ARMOR SLOTS:"), Space(10)]
    [SerializeField] Database_Armor head;
    [SerializeField] Database_Armor chest;
    [SerializeField] Database_Armor arms;
    [SerializeField] Database_Armor forearms;
    [SerializeField] Database_Armor hands;
    [SerializeField] Database_Armor legs;
    [SerializeField] Database_Armor feet;

    [Header("BAGS SLOTS:"), Space(10)]
    [SerializeField] Data_Bag rightHip;
    [SerializeField] Data_Bag leftHip;
    [SerializeField] Data_Bag rightShoulder;
    [SerializeField] Data_Bag leftShoulder;
    [SerializeField] Data_Bag back;

    [Header("HANDS SLOTS:"), Space(10)]
    [SerializeField] Data_Weapon rightHand;
    [SerializeField] Data_Weapon leftHand;
    [SerializeField] GameObject rightHandCarry;
    [SerializeField] GameObject leftHandCarry;

    public Data_Weapon RightHand { get { return rightHand; } set { rightHand = value; } }
    public Data_Weapon LeftHand { get { return leftHand; } set { leftHand = value; } }
    public GameObject RightHandCarry { get { return rightHandCarry; } set { rightHandCarry = value; } }
    public GameObject LeftHandCarry { get { return leftHandCarry; } set { leftHandCarry = value; } }
    public Data_Bag Back { get { return back; } }
    public Data_Bag LeftShoulder { get { return leftShoulder; } }
    public Data_Bag RightShoulder { get { return rightShoulder; } }
    public Data_Bag LeftHip { get { return leftHip; } }
    public Data_Bag RightHip { get { return rightHip; } }

    public void EquipOnRightHand(Data_Weapon weaponData)
    {
        this.rightHand = weaponData;
    }
    public void HoldOnRighHand(GameObject obj)
    {
        this.rightHandCarry = obj;
    }
    public void UnequipRightHand(){
        if (this.rightHand != null){
            this.rightHand = null;
        }
        if (this.rightHandCarry != null){
            this.rightHandCarry = null;
        }
    }
    public void EquipLeftHand(Data_Weapon weaponData)
    {
        this.leftHand = weaponData;
    }
    public void HoldOnLeftHand(GameObject obj)
    {
        this.leftHandCarry = obj;
    }
    public void UnequipLeftHand(){
        if (this.leftHand != null){
            this.leftHand = null;
        }
        if (this.leftHandCarry != null){
            this.leftHandCarry = null;
        }
    }
    public void EquipBackBag(Data_Bag bagData)
    {
        this.back = bagData;
    }
    public void UnequipBackBag()
    {
        if(this.back != null)
        {
            this.back = null;
        }
    }
    public void EquipRightShoulderBag(Data_Bag bagData)
    {
        this.rightShoulder = bagData;
    }
    public void UnequipRightShoulderBag()
    {
        if (this.rightShoulder != null)
        {
            this.rightShoulder = null;
        }
    }
    public void EquipLeftShoulderBag(Data_Bag bagData)
    {
        this.leftShoulder = bagData;
    }
    public void UnequipLeftShoulderBag()
    {
        if (this.leftShoulder != null)
        {
            leftShoulder = null;
        }
    }
    public void EquipRightHipBag(Data_Bag bagData)
    {
        this.rightHip = bagData;
    }
    public void UnequipRightHipBag()
    {
        if (this.rightHip != null)
        {
            this.rightHip = null;
        }
    }
    public void EquipLeftHipBag(Data_Bag bagData)
    {
        this.leftHip = bagData;
    }
    public void UnequipLeftHipBag()
    {
        if (this.leftHip != null)
        {
            this.leftHip = null;
        }
    }
    
}
