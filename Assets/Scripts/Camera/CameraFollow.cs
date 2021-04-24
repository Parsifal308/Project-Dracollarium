using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{
    [SerializeField] private PlayerInput input;
    [SerializeField] private Camera camera;


    [SerializeField] private GameObject followTarget;
    [SerializeField] private GameObject rotationTarget;
    [SerializeField] private float cameraSensibility = 0.25f;
    [SerializeField] private float positionLerp = 0.05f;
    [SerializeField] private float rotationLerp = 0.05f;
    private float x;
    private float y;

    public void LerpCamera(){
        rotationTarget.transform.localRotation = Quaternion.Euler(-y, x, 0);
        camera.transform.position = Vector3.Slerp(camera.transform.position, followTarget.transform.position, positionLerp);
        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, rotationTarget.transform.rotation, rotationLerp);
    }
    public void CalculateMouseInput(PlayerInput input)
    {
        x += input.MouseDelta.x * cameraSensibility;
        y += input.MouseDelta.y * cameraSensibility;
    }
    private void Start(){
        camera = Camera.main;
        input = GetComponent<PlayerInput>();
        rotationTarget = new GameObject("[Axis] Camera Rotator");
        rotationTarget.transform.SetParent(transform.GetChild(0));
        followTarget = new GameObject("[Axis] Camera Follow Target");
        followTarget.transform.SetParent(rotationTarget.transform);
        rotationTarget.transform.position = transform.position + new Vector3(-1.5f, 2f, -0.5f);
        camera.transform.LookAt(rotationTarget.transform);
    }
    private void Update(){
        CalculateMouseInput(input);
    }
    private void LateUpdate(){
        LerpCamera();
    }
}
