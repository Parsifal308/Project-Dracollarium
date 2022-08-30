using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Equipment : MonoBehaviour
{
    [SerializeField] NPC_Controller controller;

    [Space(10), Header("ARMOR SLOTS:")]
    [SerializeField] Database_Armor head;
    [SerializeField] Database_Armor chest;
    [SerializeField] Database_Armor arms;
    [SerializeField] Database_Armor forearms;
    [SerializeField] Database_Armor hands;
    [SerializeField] Database_Armor legs;
    [SerializeField] Database_Armor feet;

    [Space(10), Header("BAGS SLOTS:")]
    [SerializeField] Data_Bag rightHip;
    [SerializeField] Data_Bag leftHip;
    [SerializeField] Data_Bag rightShoulder;
    [SerializeField] Data_Bag leftShoulder;
    [SerializeField] Data_Bag back;

    [Space(10),Header("HANDS SLOTS:")]
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

    private void Start()
    {
        controller = GetComponent<NPC_Controller>();
    }
}
