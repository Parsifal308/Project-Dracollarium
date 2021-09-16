using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularBuilding : MonoBehaviour, IFabricate
{
    [Header("RAYCASTING SETTINGS:"), Space(10)]
    [SerializeField] float buildRange = 8f;
    [SerializeField] string[] masksNames;

    int buildTerrainMask;
    int modularBuildingMask;
    Ray buildRay;
    RaycastHit terrainHit;
    LineRenderer buildRayLine;


    [SerializeField] bool isPositioning;
    [SerializeField] bool isRotating;
    [SerializeField] bool outlineCreated;
    [SerializeField] GameObject outline;

    private void Start()
    {
        buildRayLine = GetComponent<LineRenderer>();
        buildTerrainMask= LayerMask.GetMask("BuildTerrain");

    }
    private void Update()
    {
        if (isPositioning)
        {
            if (!outlineCreated)
            {
                outline = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                outlineCreated = true;
            }
            Create();
        }

    }
    public void Create()
    {
        buildRayLine.SetPosition(0, Camera.main.transform.position);
        buildRayLine.SetPosition(1, buildRay.origin + buildRay.direction * buildRange);
        buildRay.origin = Camera.main.transform.position;
        buildRay.direction = Camera.main.transform.forward;
        if (Physics.Raycast(buildRay, out terrainHit, buildRange, buildTerrainMask))
        {
            outline.transform.position = terrainHit.point;
            outline.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
        else
        {
            if (outline != null)
            {
                Destroy(outline);
                outline = null;
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
}
