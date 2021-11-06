using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModularBuilding : MonoBehaviour, IFabricate{
    [Header("OUTLINE MATERIAL:"), Space(10)]
    [SerializeField] private Material outlineMaterial;

    [Header("RAYCASTING SETTINGS:"), Space(10)]
    [SerializeField] float buildRange = 8f;
    [SerializeField] string[] masksNames;
    int buildTerrainMask;
    int modularBuildingMask;
    Ray buildRay;
    RaycastHit terrainHit;
    LineRenderer buildRayLine;

    [Header("CONTROL VARIABLES:"), Space(10)]
    [SerializeField] bool isPositioning;
    [SerializeField] bool isRotating;
    [SerializeField] bool outlineCreated;
    [SerializeField] GameObject outline;
    private GameObject building;

    [SerializeField] private InputActionAsset actionsMap;
    
    private void Start(){
        buildRayLine = GetComponent<LineRenderer>();
        buildTerrainMask= LayerMask.GetMask("BuildTerrain");


    }
    private void Update(){
        if (isPositioning){
            if (!outlineCreated){
                outline.SetActive(true);
                outlineCreated = true;
            }
            Create(building);
        }
    }
    public void PositionBuilding(GameObject building){
        isPositioning = true;
        this.building = building;
        outline = Instantiate(this.building);
        MeshRenderer[] outlineRenderers = outline.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in outlineRenderers){
            Material[] outlineMaterials = renderer.materials;
            for (int i = 0; i < outlineMaterials.Length; i++){
                outlineMaterials[i] = outlineMaterial;
            }
            renderer.materials = outlineMaterials;
        }
    }
    public void Create(GameObject building){
        buildRayLine.SetPosition(0, Camera.main.transform.position);
        buildRayLine.SetPosition(1, buildRay.origin + buildRay.direction * buildRange);
        buildRay.origin = Camera.main.transform.position;
        buildRay.direction = Camera.main.transform.forward;
        if (Physics.Raycast(buildRay, out terrainHit, buildRange, buildTerrainMask)){
            outline.transform.position = terrainHit.point;

            if(Mouse.current.leftButton.isPressed){
                Debug.Log("Se Presiono el boton izquierdo del mouse durante el raycasting");
                isPositioning = false;
                GameObject.Instantiate(building, outline.transform.position, outline.transform.rotation);
                building = null;
                Destroy(outline);
                outlineCreated = false;
            }       
        }
        else{
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
}
