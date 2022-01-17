using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;


[RequireComponent(typeof(LineRenderer))]
public class Player_ItemPickup : MonoBehaviour{
    #region EVENTS
    public event EventHandler OnRightHandItemPickup, OnLeftHandItemPickup, OnRightHandItemDrop, OnLeftHandItemDrop;
    public event EventHandler OnBackItemEquip, OnLeftShoulderEquip, OnRightShoulderEquip, OnLeftHipEquip, OnRightHipEquip;
    public event EventHandler OnTakingItem;
    #endregion

    #region FIELDS
    private Controller_PlayerManager controller_PlayerManager;
    private GameObject objectReached;

    [Header("RAYCASTING SETTINGS:"), Space(10)]
    [SerializeField] private bool isPickingEnabled;
    [SerializeField] private float actionsCooldown=1;
    [SerializeField] private bool isQuickEquipArmor;
    [SerializeField] private bool isQuickEquipWeapon;
    [SerializeField] private bool isQuickEquipBag;
    [SerializeField] private bool isQuickEquipAccesory;
    [SerializeField] private bool isGrabbing = false;
    [SerializeField] private bool isTaking = false;
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
    public GameObject ObjectReached { get { return objectReached; } }
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
    private void Start()
    {
        pickUpRayLine = GetComponent<LineRenderer>();
        itemMask = LayerMask.GetMask("Items");
        controller_PlayerManager = GetComponent<Controller_PlayerManager>();
        OnRightHandItemPickup += controller_PlayerManager.PlayerDracollariumAnimation.SetGrabbingAnim;
        OnRightHandItemPickup += controller_PlayerManager.PlayerDracollariumAnimation.ParentItemToRightHand;
        OnLeftHandItemPickup += controller_PlayerManager.PlayerDracollariumAnimation.SetGrabbingAnim;
        OnLeftHandItemPickup += controller_PlayerManager.PlayerDracollariumAnimation.ParentItemToLeftHand;

        OnLeftHandItemDrop += controller_PlayerManager.PlayerDracollariumAnimation.DropLeftItem;
        OnRightHandItemDrop += controller_PlayerManager.PlayerDracollariumAnimation.DropRightItem;

        OnBackItemEquip += controller_PlayerManager.PlayerDracollariumAnimation.ParentItemToBack;
        OnRightShoulderEquip += controller_PlayerManager.PlayerDracollariumAnimation.ParentItemToRightShoulder;
        OnLeftShoulderEquip += controller_PlayerManager.PlayerDracollariumAnimation.ParentItemToLeftShoulder;
        OnRightHipEquip += controller_PlayerManager.PlayerDracollariumAnimation.ParentItemToRightHip;
        OnLeftHipEquip += controller_PlayerManager.PlayerDracollariumAnimation.ParentItemToLeftHip;

        OnTakingItem += controller_PlayerManager.PlayerDracollariumAnimation.SetGrabbingAnim;


    }
    private void Update()
    {
        if (!isQuickEquipArmor && !isQuickEquipBag && !isQuickEquipWeapon && !isQuickEquipAccesory)
        {
            try
            {
                TargetItem();
            }
            catch (Exception e)
            {
                Debug.LogError("---->[ERROR] an " + e.GetType() + "has ocurred!");
            }
        }
        if (canvasQuickEquipWeapon.enabled && isQuickEquipWeapon)
        {
            RotateCanvas(canvasQuickEquipWeapon);
        }
        if (canvasQuickEquipBag.enabled && isQuickEquipBag)
        {
            RotateCanvas(canvasQuickEquipBag);
        }
        if (canvasQuickEquipArmor.enabled && isQuickEquipArmor)
        {
            RotateCanvas(canvasQuickEquipArmor);
        }
    }
    #endregion
    #region METHOD
    public void DisableCanvases(InputAction.CallbackContext obj)
    {
        isQuickEquipWeapon = false;
        isQuickEquipBag = false;
        isQuickEquipArmor = false;
        isQuickEquipAccesory = false;
        canvasQuickEquipWeapon.enabled = false;
        canvasQuickEquipArmor.enabled = false;
        canvasQuickEquipBag.enabled = false;
        controller_PlayerManager.EnableMouseRotation();
    }
    public void RotateCanvas(Canvas canvas)
    {
        canvas.transform.LookAt(2 * canvas.transform.position - Camera.main.transform.position);
    }
    public void PickUpItem()
    {
        if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask))
        {
            Debug.Log("Se alcanzo el item: " + itemHit.transform.name);
        }
    }
    public void Take(InputAction.CallbackContext obj)
    {
        if (isPickingEnabled && controller_PlayerManager.PlayerEquipment.Back != null && isGrabbing==false)
        {
            isTaking = true;
            if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask))
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] THIS ITEM SHOULD BE SAVE IN THE INVENTORY");
                try
                {
                    objectReached = itemHit.transform.gameObject;
                    controller_PlayerManager.PlayerEquipment.Back.AddItem(objectReached.transform.GetComponent<I_ItemData>());
                    OnTakingItem?.Invoke(this, EventArgs.Empty);
                    Destroy(objectReached);
                }
                catch (Exception e)
                {
                    Debug.LogError("---->[ERROR] An error has ocurred: " + e.GetType());
                }
            }
        }
        else
        {
            Debug.Log("NO BAG IS EQUIPPEDD");
        }
        StartCoroutine(ActionCooldown());
    }
    public void Drop(InputAction.CallbackContext obj)
    {

        switch (obj.action.name)
        {
            case "DropLeftItem":
                OnLeftHandItemDrop?.Invoke(this, EventArgs.Empty);
                controller_PlayerManager.PlayerEquipment.UnequipLeftHand();
                break;
            case "DropRightItem":
                OnRightHandItemDrop?.Invoke(this, EventArgs.Empty);
                controller_PlayerManager.PlayerEquipment.UnequipRightHand();
                break;
        }
    }
    public void Grab(InputAction.CallbackContext obj)
    {
        if (isPickingEnabled && isTaking==false)
        {
            isGrabbing = true;
            if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask))
            {
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] THIS ITEM SHOULD BE GRABBED");
                try
                {
                    objectReached = itemHit.transform.gameObject;
                    if (controller_PlayerManager.PlayerEquipment.RightHand == null && controller_PlayerManager.PlayerEquipment.RightHandCarry == null)
                    {
                        switch (itemHit.transform.gameObject.transform.GetComponent<I_ItemData>().GetType().ToString())
                        {
                            case "Data_Weapon":
                                OnRightHandItemPickup?.Invoke(this, EventArgs.Empty);
                                controller_PlayerManager.PlayerEquipment.EquipOnRightHand(itemHit.transform.gameObject.transform.GetComponent<Data_Weapon>());
                                break;
                            case "Data_Armor":
                                controller_PlayerManager.PlayerEquipment.HoldOnRighHand(itemHit.transform.gameObject);
                                OnRightHandItemPickup?.Invoke(this, EventArgs.Empty);
                                break;
                            case "Data_Bag":
                                controller_PlayerManager.PlayerEquipment.HoldOnRighHand(itemHit.transform.gameObject);
                                OnRightHandItemPickup?.Invoke(this, EventArgs.Empty);
                                break;
                            case "Data_Consumable":
                                controller_PlayerManager.PlayerEquipment.HoldOnRighHand(itemHit.transform.gameObject);
                                OnRightHandItemPickup?.Invoke(this, EventArgs.Empty);
                                break;
                            case "Data_Material":
                                controller_PlayerManager.PlayerEquipment.HoldOnRighHand(itemHit.transform.gameObject);
                                OnRightHandItemPickup?.Invoke(this, EventArgs.Empty);
                                break;
                        }
                    }
                    else if (controller_PlayerManager.PlayerEquipment.LeftHand == null && controller_PlayerManager.PlayerEquipment.LeftHandCarry == null)
                    {
                        switch (itemHit.transform.gameObject.transform.GetComponent<I_ItemData>().GetType().ToString())
                        {
                            case "Data_Weapon":
                                controller_PlayerManager.PlayerEquipment.EquipLeftHand(itemHit.transform.gameObject.transform.GetComponent<Data_Weapon>());
                                OnLeftHandItemPickup?.Invoke(this, EventArgs.Empty);
                                break;
                            case "Data_Armor":
                                controller_PlayerManager.PlayerEquipment.HoldOnLeftHand(itemHit.transform.gameObject);
                                OnLeftHandItemPickup?.Invoke(this, EventArgs.Empty);
                                break;
                            case "Data_Bag":
                                controller_PlayerManager.PlayerEquipment.HoldOnLeftHand(itemHit.transform.gameObject);
                                OnLeftHandItemPickup?.Invoke(this, EventArgs.Empty);
                                break;
                            case "Data_Consumable":
                                controller_PlayerManager.PlayerEquipment.HoldOnLeftHand(itemHit.transform.gameObject);
                                OnLeftHandItemPickup?.Invoke(this, EventArgs.Empty);
                                break;
                            case "Data_Material":
                                controller_PlayerManager.PlayerEquipment.HoldOnLeftHand(itemHit.transform.gameObject);
                                OnLeftHandItemPickup?.Invoke(this, EventArgs.Empty);
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("---->[ERROR] An error has ocurred: " + e.GetType());
                }
            }
        }
        StartCoroutine(ActionCooldown());
    }
    public void TargetItem()
    {
        pickUpRayLine.SetPosition(0, Camera.main.transform.position);
        pickUpRayLine.SetPosition(1, pickUpRay.origin + pickUpRay.direction * pickUpRange);
        pickUpRay.origin = Camera.main.transform.position;
        pickUpRay.direction = Camera.main.transform.forward;
        if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask))
        {
            canvasActions.enabled = true;
            canvasActions.transform.position = itemHit.transform.position + positionGap;
            RotateCanvas(canvasActions);

            guidingText.text = "Press [" + controller_PlayerManager.PlayerActionsController.Grab.bindings[0].effectivePath + "] to collect\n[" + itemHit.transform.GetComponent<I_ItemData>().GetData.ItemName + "]";
        }
        else
        {
            canvasActions.enabled = false;
        }
    }
    public void ActionB(InputAction.CallbackContext obj)
    {
        if (isPickingEnabled)
        {
            if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask))
            {
                objectReached = itemHit.transform.gameObject;
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Quickly equipping an item");
                switch (itemHit.transform.GetComponent<I_ItemData>().GetType().ToString())
                {
                    case "Data_Weapon":
                        Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] A weapon is trying to be quickly equipped");
                        isQuickEquipWeapon = true;
                        canvasQuickEquipWeapon.enabled = true;
                        canvasQuickEquipWeapon.transform.position = itemHit.transform.position + positionGap;
                        controller_PlayerManager.DisableMouseRotation();
                        canvasActions.enabled = false;
                        break;
                    case "Data_Bag":
                        Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] A Bag is trying to be quickly equipped");
                        isQuickEquipBag = true;
                        canvasQuickEquipBag.enabled = true;
                        canvasQuickEquipBag.transform.position = itemHit.transform.position + positionGap;
                        controller_PlayerManager.DisableMouseRotation();
                        canvasActions.enabled = false;
                        break;
                    case "Data_Armor":
                        Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] An armor is trying to be quickly equipped");
                        isQuickEquipArmor = true;
                        canvasQuickEquipArmor.enabled = true;
                        canvasQuickEquipArmor.transform.position = itemHit.transform.position + positionGap;
                        controller_PlayerManager.DisableMouseRotation();
                        canvasActions.enabled = false;
                        break;
                    default:
                        Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Trying to quickly equip a non equippable item");
                        break;
                }
            }
        }
    }
    public void QuickEquipBackBag()
    {
        controller_PlayerManager.PlayerEquipment.EquipBackBag(objectReached.transform.GetComponent<Data_Bag>());
        IsQuickEquipBag = false;
        OnBackItemEquip?.Invoke(this, EventArgs.Empty);
    }
    public void QuickEquipRightShoulderBag()
    {
        controller_PlayerManager.PlayerEquipment.EquipRightShoulderBag(objectReached.transform.GetComponent<Data_Bag>());
        IsQuickEquipBag = false;
        OnRightShoulderEquip?.Invoke(this, EventArgs.Empty);
    }
    public void QuickEquipLeftShoulderBag()
    {
        controller_PlayerManager.PlayerEquipment.EquipLeftShoulderBag(objectReached.transform.GetComponent<Data_Bag>());
        IsQuickEquipBag = false;
        OnLeftShoulderEquip?.Invoke(this, EventArgs.Empty);
    }
    public void QuickEquipRightHipBag()
    {
        controller_PlayerManager.PlayerEquipment.EquipRightHipBag(objectReached.transform.GetComponent<Data_Bag>());
        IsQuickEquipBag = false;
        OnRightHipEquip?.Invoke(this, EventArgs.Empty);
    }
    public void QuickEquipLeftHipBag()
    {
        controller_PlayerManager.PlayerEquipment.EquipLeftHipBag(objectReached.transform.GetComponent<Data_Bag>());
        IsQuickEquipBag = false;
        OnLeftHipEquip?.Invoke(this, EventArgs.Empty);
    }
    #endregion

    IEnumerator ActionCooldown()
    {
        Debug.Log("....Coroutine started....");
        yield return new WaitForSeconds(actionsCooldown);
        Debug.Log("....2 Seconds waited by coroutine....");
        isGrabbing = false;
        isTaking = false;
    }
}

