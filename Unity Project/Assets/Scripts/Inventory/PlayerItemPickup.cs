using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemPickup : MonoBehaviour{
    [Header("RAYCASTING SETTINGS:"), Space(10)]
    [SerializeField] float pickUpRange = 8f;
    [SerializeField] string[] masksNames;
    int itemMask;
    Ray pickUpRay;
    RaycastHit itemHit;
    LineRenderer pickUpRayLine;

    private void Start(){
        pickUpRayLine = GetComponent<LineRenderer>();
        itemMask = LayerMask.GetMask("BuildTerrain");
    }
    private void Update(){
        pickUpRayLine.SetPosition(0, Camera.main.transform.position);
        pickUpRayLine.SetPosition(1, pickUpRay.origin + pickUpRay.direction * pickUpRange);
        pickUpRay.origin = Camera.main.transform.position;
        pickUpRay.direction = Camera.main.transform.forward;
        if (Physics.Raycast(pickUpRay, out itemHit, pickUpRange, itemMask)){
        }
    }
}
