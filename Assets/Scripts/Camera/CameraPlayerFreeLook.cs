using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFreeLook : MonoBehaviour{
    #region FIELDS
    private PlayerInput input;
    private Camera camera;
    private GameObject followTarget;
    private GameObject rotationTarget;
    private float x;
    private float y;
    [SerializeField] private float cameraSensibility = 0.25f;
    [SerializeField] private float positionLerp = 0.05f;
    [SerializeField] private float rotationLerp = 0.05f;
    [SerializeField] private bool focusedMove;
    #endregion
    #region PROPERTIES
    public GameObject RotationTarget { get { return rotationTarget; } }
    public GameObject FollowTarget { get { return followTarget; } }
    #endregion
    #region METHODS
    public void LerpCamera(){
        camera.transform.position = Vector3.Slerp(camera.transform.position, followTarget.transform.position, positionLerp);
        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, rotationTarget.transform.rotation, rotationLerp);
    }
    public void CalculateMouseInput(PlayerInput input)
    {
        x += input.MouseDelta.x * cameraSensibility;
        y += input.MouseDelta.y * cameraSensibility;
    }
    #endregion
    private void Start(){
        camera = Camera.main;
        input = GetComponent<PlayerInput>();
        rotationTarget = new GameObject("[Axis] Camera Rotator");
        rotationTarget.transform.SetParent(transform.GetComponentInChildren<CharacterController>().transform);
        followTarget = new GameObject("[Axis] Camera Follow Target");
        followTarget.transform.SetParent(rotationTarget.transform);
        rotationTarget.transform.position = transform.position + new Vector3(-2.5f, 2f, -0.5f);
        rotationTarget.transform.localRotation = Quaternion.Euler(0, 90, 0);
        camera.transform.LookAt(rotationTarget.transform);
    }
    private void Update(){
        CalculateMouseInput(input);
        rotationTarget.transform.localRotation = Quaternion.Euler(-y, x, 0);
        
    }
    private void LateUpdate(){
        LerpCamera();    
    }
}
