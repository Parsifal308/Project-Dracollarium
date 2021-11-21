using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemPickup : MonoBehaviour{

    #region FIELDS
    private Controller_PlayerManager playerGlobalController;

    [Header("RAYCASTING SETTINGS:"), Space(10)]
    [SerializeField] bool isPickingEnabled;
    [SerializeField] float pickUpRange = 8f;
    [SerializeField] string[] masksNames;
    int itemMask;
    Ray pickUpRay;
    RaycastHit itemHit;
    LineRenderer pickUpRayLine;

    [Header("Graphic User Interface"), Space(10)]
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Vector3 positionGap = new Vector3(0.5f, 0.5f, 0);
    #endregion

    #region PROPERTIES
    public bool IsPickingEnabled { get { return isPickingEnabled; } }
    #endregion

    #region UNITY METHODS
    private void Start(){
        pickUpRayLine = GetComponent<LineRenderer>();
        itemMask = LayerMask.GetMask("Items");
        playerGlobalController = GetComponent<Controller_PlayerManager>();

    }
    private void Update(){
        pickUpRayLine.SetPosition(0, Camera.main.transform.position);
        pickUpRayLine.SetPosition(1, pickUpRay.origin + pickUpRay.direction * pickUpRange);
        pickUpRay.origin = Camera.main.transform.position;
        pickUpRay.direction = Camera.main.transform.forward;
        if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask)){
            canvas.enabled = true;
            canvas.transform.position = itemHit.transform.position + positionGap;
            canvas.transform.LookAt(2 * canvas.transform.position - Camera.main.transform.position);

            //MEJORARA PARA QUE INDIQUE EL BOTON CORRECTO SEGUN LA CONFIGAURACION DEL INPUT
            text.text = "Press ["+playerGlobalController.PlayerActionsController.ActionA.bindings[0].effectivePath+"] to collect\n["+itemHit.transform.GetComponent<I_Item>().GetData.GetName +"]"; 

        }
        else
        {
            canvas.enabled = false;
        }
    }
    #endregion
    #region METHOD
    public void PickUpItem(){
        if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask)){
            Debug.Log("Se alcanzo el item: " + itemHit.transform.name);
        }
    }

    public void ActionA(InputAction.CallbackContext obj){
        if (isPickingEnabled){
            if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask)){
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] THIS ITEM SHOULD BE TAKEN");
            }
        }
    }

    public void ActionB(InputAction.CallbackContext obj){
        if (isPickingEnabled){
            if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask)){
                Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] THIS ITEM SHOULD BE EQUIPPED");
            }

        }
    }
    #endregion
}
