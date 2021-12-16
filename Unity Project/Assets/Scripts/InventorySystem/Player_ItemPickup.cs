using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_ItemPickup : MonoBehaviour{

    #region FIELDS
    private Controller_PlayerManager playerGlobalController;
    public event EventHandler OnItemPickup;

    [Header("RAYCASTING SETTINGS:"), Space(10)]
    [SerializeField] private bool isPickingEnabled;
    private bool isQuickEquipArmor;
    private bool isQuickEquipWeapon;
    private bool isQuickEquipBag;
    private bool isQuickEquipAccesory;
    [SerializeField] private float pickUpRange = 8f;
    [SerializeField] private string[] masksNames;
    private int itemMask;
    private Ray pickUpRay;
    private RaycastHit itemHit;
    private LineRenderer pickUpRayLine;

    [Header("Graphic User Interface"), Space(10)]
    [SerializeField] private Canvas canvasActions;
    [SerializeField] private Canvas canvasQuickEquipWeapon;    
    [SerializeField] private Canvas canvasQuickEquipArmor;
    [SerializeField] private Canvas canvasQuickEquipBag;
    [SerializeField] private TextMeshProUGUI guidingText;
    [SerializeField] private Vector3 positionGap = new Vector3(0.5f, 0.5f, 0);
    #endregion

    #region PROPERTIES
    public bool IsQuickEquipArmor { get { return isQuickEquipArmor; } set { isQuickEquipArmor = value; } }
    public bool iIQuickEquipWeapon { get { return isQuickEquipWeapon; } set { isQuickEquipWeapon = value; } }
    public bool IsQuickEquipBag { get { return isQuickEquipBag; } set { isQuickEquipBag = value; } }
    public bool IsQuickEquipAccesory { get { return isQuickEquipAccesory; } set { isQuickEquipAccesory = value; } }
    public bool IsPickingEnabled { get { return isPickingEnabled; } set { isPickingEnabled = value; } }
    public Canvas CanvasActions { get { return canvasActions; } }
    public Canvas CanvasQuickEquip { get { return canvasQuickEquipWeapon; } }
    public Canvas CanvasQuickBag { get { return canvasQuickEquipBag; } }
    public TextMeshProUGUI GuidingText { get { return guidingText; } }
    #endregion

    #region UNITY METHODS
    private void Start(){
        pickUpRayLine = GetComponent<LineRenderer>();
        itemMask = LayerMask.GetMask("Items");
        playerGlobalController = GetComponent<Controller_PlayerManager>();
        guidingText = GetComponentInChildren<TextMeshProUGUI>();
        OnItemPickup += playerGlobalController.PlayerDracollariumAnimation.SetGrabbingAnim;
    }
    private void Update(){
        if(!isQuickEquipArmor && !isQuickEquipBag && !isQuickEquipWeapon && !isQuickEquipAccesory){
            try{
                TargetItem();
            }
            catch (Exception e){
                Debug.LogError("---->[ERROR] an " + e.GetType() + "has ocurred!");
            }
        }
        if (canvasQuickEquipWeapon.enabled && isQuickEquipWeapon){
            RotateCanvas(canvasQuickEquipWeapon);
        }
        if (canvasQuickEquipBag.enabled && isQuickEquipBag){
            RotateCanvas(canvasQuickEquipBag);
        }
        if (canvasQuickEquipArmor.enabled && isQuickEquipArmor){
            RotateCanvas(canvasQuickEquipArmor);
        }
    }
    #endregion
    #region METHOD
    public void DisableCanvases(InputAction.CallbackContext obj){
        isQuickEquipWeapon = false;
        isQuickEquipBag = false;
        isQuickEquipArmor = false;
        isQuickEquipAccesory = false;
        canvasQuickEquipWeapon.enabled = false;
        canvasQuickEquipArmor.enabled = false;
        canvasQuickEquipBag.enabled = false;
        playerGlobalController.EnableMouseRotation();
    }
        public void RotateCanvas(Canvas canvas){
        canvas.transform.LookAt(2 * canvas.transform.position - Camera.main.transform.position);
    }
    public void PickUpItem(){
        if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask)){
            Debug.Log("Se alcanzo el item: " + itemHit.transform.name);
        }
    }
    public void TargetItem(){
        pickUpRayLine.SetPosition(0, Camera.main.transform.position);
        pickUpRayLine.SetPosition(1, pickUpRay.origin + pickUpRay.direction * pickUpRange);
        pickUpRay.origin = Camera.main.transform.position;
        pickUpRay.direction = Camera.main.transform.forward;
        if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask)){
            canvasActions.enabled = true;
            canvasActions.transform.position = itemHit.transform.position + positionGap;
            RotateCanvas(canvasActions);

            guidingText.text = "Press [" + playerGlobalController.PlayerActionsController.ActionA.bindings[0].effectivePath + "] to collect\n[" + itemHit.transform.GetComponent<I_ItemData>().GetData.GetName + "]";
        }else{
            canvasActions.enabled = false;
        }
    }
    public void ActionA(InputAction.CallbackContext obj){
        if (isPickingEnabled){
            if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask)){
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] THIS ITEM SHOULD BE TAKEN");
                OnItemPickup?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public void ActionB(InputAction.CallbackContext obj){
        if (isPickingEnabled){
            if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask)){
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Quickly equipping an item");
                if (itemHit.transform.GetComponent<I_ItemData>().GetType() == typeof(Data_Weapon)){
                    Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] A weapon is trying to be quickly equipped");
                    isQuickEquipWeapon = true;
                    canvasQuickEquipWeapon.enabled = true;
                    canvasQuickEquipWeapon.transform.position = itemHit.transform.position + positionGap;
                    playerGlobalController.DisableMouseRotation();
                    canvasActions.enabled = false;
                }
                else if (itemHit.transform.GetComponent<I_ItemData>().GetType() == typeof(Data_Bag)){
                    Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] A Bag is trying to be quickly equipped");
                    isQuickEquipBag = true;
                    canvasQuickEquipBag.enabled = true;
                    canvasQuickEquipBag.transform.position = itemHit.transform.position + positionGap;
                    playerGlobalController.DisableMouseRotation();
                    canvasActions.enabled = false;
                }
                else if (itemHit.transform.GetComponent<I_ItemData>().GetType() == typeof(Data_Armor)){
                    Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] An armor is trying to be quickly equipped");
                    isQuickEquipArmor = true;
                    canvasQuickEquipArmor.enabled = true;
                    canvasQuickEquipArmor.transform.position = itemHit.transform.position + positionGap;
                    playerGlobalController.DisableMouseRotation();
                    canvasActions.enabled = false;
                }
                else{
                    Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Trying to quickly equip a non equippable item");
                }
            }
        }
    }
    #endregion
}
