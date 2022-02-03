using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*  ====================================================================
 *  Clase que implementa los comportamientos del sistema de construccion
 *  
 *  NOTA: Hay que settear los layers de los axis para poder detectarlos
 *  y conectar las piezas contiguas
 *  ====================================================================
 */

[RequireComponent(typeof(LineRenderer))]
public class Player_ModularBuilding : MonoBehaviour, IFabricate{
    #region FIELDS
    public event EventHandler OnPickingItemsEnabled, OnPickingItemsDisabled;

    private Controller_PlayerManager controller_PlayerManager;

    [Header("BUILDING SETTINGS:"), Space(10)]
    [SerializeField] private float buildingRotation;
    [SerializeField] GameObject outline;
    [SerializeField] GameObject outlinePivot;
    private GameObject building;
    [Header("OUTLINE MATERIAL:"), Space(10)]
    [SerializeField] private Material outlineMaterial;

    [Header("RAYCASTING SETTINGS:"), Space(10)]
    [SerializeField] float buildRange = 8f;
    [SerializeField] string[] masksNames;
    int buildTerrainMask;
    int modularBuildingMask;
    Ray buildRay;
    RaycastHit hit;
    LineRenderer buildRayLine;

    [Header("CONTROL VARIABLES:"), Space(10)]
    [SerializeField] bool isPositioning;
    [SerializeField] bool isRotationVertically;
    [SerializeField] bool isAddingRotation;
    [SerializeField] bool isSubtractingRotation;
    [SerializeField] bool outlineCreated;
    [SerializeField] Axis pivotAxis;
    Quaternion rotationGap = Quaternion.Euler(90, 0, 0);


    [SerializeField] private InputActionAsset actionsMap;
    #endregion
    #region UNITY METHODS
    private void Start(){
        buildRayLine = GetComponent<LineRenderer>();
        buildTerrainMask = LayerMask.GetMask("BuildTerrain");
        modularBuildingMask = LayerMask.GetMask("ModularBuilding");
        OnPickingItemsEnabled += GetComponent<Controller_PlayerManager>().EnableItemCollection;
        OnPickingItemsDisabled += GetComponent<Controller_PlayerManager>().DisableBuildingPositioning;
    }
    private void Update()
    {
        if (isPositioning)
        {
            if (!outlineCreated)
            {
                outline.SetActive(true);
                outlineCreated = true;
            }
            Create(building);
        }
        if (isRotationVertically)
        {
            if (isAddingRotation)
            {
                buildingRotation += Time.deltaTime + 1;
            }
            else if (isSubtractingRotation)
            {
                buildingRotation += Time.deltaTime - 1;
            }
            outlinePivot.transform.localEulerAngles = new Vector3(-90f, 0f, buildingRotation);
        }
    }
    #endregion
    #region METHODS
    internal void StopRotation(InputAction.CallbackContext obj)
    {
        isRotationVertically = false;
        isSubtractingRotation = false;
        isAddingRotation = false;
    }
    internal void StartVerticalRotation(InputAction.CallbackContext obj)
    {
        isRotationVertically = true;
        if (obj.control.path == "/Keyboard/t")
        {
            isAddingRotation = true;
        }
        else if (obj.control.path == "/Keyboard/g")
        {
            isSubtractingRotation = true;
        }
    }
    public void PositionBuilding(GameObject building){ //CALLED FROM GUI
        isPositioning = true;
        this.building = building;
        outline = Instantiate(this.building).GetComponentInChildren<ModularBuildingAxisReferences>().gameObject;
        Collider[] colliders = outline.GetComponents<Collider>();
        foreach (Collider collider in colliders){
            collider.enabled = false;
        }
        outline.GetComponent<ModularBuildingAxisReferences>().LeftAxis.GetComponentInChildren<Collider>().enabled = false;
        outline.GetComponent<ModularBuildingAxisReferences>().RightAxis.GetComponentInChildren<Collider>().enabled = false;
        outline.GetComponent<ModularBuildingAxisReferences>().CenterAxis.GetComponentInChildren<Collider>().enabled = false;
        outline.GetComponent<ModularBuildingAxisReferences>().LowerAxis.GetComponentInChildren<Collider>().enabled = false;
        outline.GetComponent<ModularBuildingAxisReferences>().UpperAxis.GetComponentInChildren<Collider>().enabled = false;
        SetAllAxis();

        MeshRenderer[] outlineRenderers = outline.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in outlineRenderers){
            Material[] outlineMaterials = renderer.materials;
            for (int i = 0; i < outlineMaterials.Length; i++){
                outlineMaterials[i] = outlineMaterial;
            }
            renderer.materials = outlineMaterials;
        }
    }
    public void SetAllAxis()
    {
        outline.GetComponent<ModularBuildingAxisReferences>().LeftAxis.transform.parent = outline.transform;
        outline.GetComponent<ModularBuildingAxisReferences>().RightAxis.transform.parent = outline.transform;
        outline.GetComponent<ModularBuildingAxisReferences>().LowerAxis.transform.parent = outline.transform;
        outline.GetComponent<ModularBuildingAxisReferences>().UpperAxis.transform.parent = outline.transform;
        outline.GetComponent<ModularBuildingAxisReferences>().CenterAxis.transform.parent = outline.transform;
    }
    public void SetAxisPivot(GameObject axis)
    {
        if (outlinePivot != null){
            outline.transform.parent = outline.transform.parent.parent;
            outlinePivot.transform.parent = outline.transform;
        }
            outlinePivot = axis;
            axis.transform.parent = axis.transform.parent.parent;
            outline.transform.parent = axis.transform;

    }
    public void Create(GameObject building){
        buildRayLine.SetPosition(0, Camera.main.transform.position);
        buildRayLine.SetPosition(1, buildRay.origin + buildRay.direction * buildRange);
        buildRay.origin = Camera.main.transform.position;
        buildRay.direction = Camera.main.transform.forward;
        if (Physics.Raycast(buildRay, out hit, buildRange, buildTerrainMask)){
            if (pivotAxis != Axis.LowerAxis){
                SetAxisPivot(outline.GetComponent<ModularBuildingAxisReferences>().LowerAxis);
                pivotAxis = Axis.LowerAxis;
            }
            outlinePivot.transform.position = hit.point;
            if(Mouse.current.leftButton.isPressed)
            {
                try {
                    Debug.LogFormat("<color=#00ff00> {0} </color>", "-- >[LOG] Instantiating " + building + "...");

                    GameObject.Instantiate(building, outline.transform.position, outlinePivot.transform.localRotation * rotationGap);
                    Destroy(outlinePivot.transform.parent.gameObject);
                    pivotAxis = Axis.None;
                }catch (Exception ex){
                    Debug.LogError("----->[ERROR] An Error of type: "+ ex.GetType()+ "has occurred!!!");
                }
                finally{
                    Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] '" + building + "' instantiated successfully");
                    building = null;
                    Destroy(outline);
                    outlineCreated = false;
                    OnPickingItemsEnabled?.Invoke(this, EventArgs.Empty);
                    isPositioning = false;
                    buildingRotation = 0;
                }
            }       
        }
        else if(Physics.Raycast(buildRay, out hit, buildRange, modularBuildingMask))
        {
            switch (hit.transform.GetComponent<ModularBuilidingAxis>().Axis)
            {
                case Axis.LeftAxis:
                    Debug.Log("LEFT axis alcanzado :D");
                    if (pivotAxis != Axis.LeftAxis){
                        SetAxisPivot(outline.GetComponent<ModularBuildingAxisReferences>().LeftAxis);
                        pivotAxis = Axis.LeftAxis;
                    }
                    break;
                case Axis.RightAxis:
                    Debug.Log("RIGHT axis alcanzado :D");
                    if (pivotAxis != Axis.RightAxis){
                        SetAxisPivot(outline.GetComponent<ModularBuildingAxisReferences>().RightAxis);
                        pivotAxis = Axis.RightAxis;
                    }
                    break;
                case Axis.UpperAxis:
                    Debug.Log("UPPER axis alcanzado :D");
                    if (pivotAxis != Axis.UpperAxis){
                        SetAxisPivot(outline.GetComponent<ModularBuildingAxisReferences>().UpperAxis);
                        pivotAxis = Axis.UpperAxis;
                    }
                    break;
                case Axis.LowerAxis:
                    Debug.Log("LOWER axis alcanzado :D");
                    if (pivotAxis != Axis.LowerAxis){
                        SetAxisPivot(outline.GetComponent<ModularBuildingAxisReferences>().LowerAxis);
                        pivotAxis = Axis.LowerAxis;
                    }
                    break;
                case Axis.CenterAxis:
                    Debug.Log("CENTER axis alcanzado :D");
                    if (pivotAxis != Axis.CenterAxis){
                        SetAxisPivot(outline.GetComponent<ModularBuildingAxisReferences>().CenterAxis);
                        pivotAxis = Axis.CenterAxis;
                    }
                    break;
                default:
                    break;
            }
            outlinePivot.transform.position = hit.transform.position;
            if (Mouse.current.leftButton.isPressed){
                try
                {
                    Debug.LogFormat("<color=#00ff00> {0} </color>", "-- >[LOG] Instantiating " + building + "...");
                    //outline.transform.rotation = Quaternion.Euler(-90f, buildingRotation, 0f);
                    GameObject.Instantiate(building, outline.transform.position, outlinePivot.transform.localRotation * rotationGap);
                    Destroy(outlinePivot.transform.parent.gameObject);
                    pivotAxis = Axis.None;
                }
                catch (Exception ex){
                    Debug.LogError("----->[ERROR] An Error of type: " + ex.GetType() + "has occurred!!!");
                }
                finally{
                    Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] '" + building + "' instantiated successfully");
                    building = null;
                    Destroy(outline);
                    outlineCreated = false;
                    OnPickingItemsEnabled?.Invoke(this, EventArgs.Empty);
                    isPositioning = false;
                    buildingRotation = 0;
                }
            }
        }
        else
        {
            if (outline != null){
                outline.SetActive(false);
                outlineCreated = false;
            }
        }
    }
    public void Destroy()
    {
        throw new System.NotImplementedException();
    }
    public void Dismantle()
    {
        throw new System.NotImplementedException();
    }

    public void EnablePositioning()
    {
        isPositioning = true;
    }

    public void DisablePositioning()
    {
        isPositioning = false;
    }
    #endregion
}