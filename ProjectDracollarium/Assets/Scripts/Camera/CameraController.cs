using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region FIELDS
    private PlayerManager playerManager;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject followTarget;
    [SerializeField] private GameObject rotationTarget;
    [SerializeField] private float cameraSensibility = 0.25f;
    [SerializeField] private float yMinClamp = -25f;
    [SerializeField] private float yMaxClamp = 25f;
    [SerializeField] private float xMinClamp = -360f;
    [SerializeField] private float xMaxClamp = 360f;
    [SerializeField] private float positionLerp = 0.05f;
    [SerializeField] private float rotationLerp = 0.05f;
    [SerializeField] private bool disableMouse = true;
    private Vector2 mouseRotation;
    #endregion

    #region PROPERTIES
    public Camera PlayerCamera { get { return playerCamera; } }
    public float CameraSensibility { get { return cameraSensibility; } set { cameraSensibility = value; } }
    #endregion


    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    void Update()
    {
        ApplyMouseRotation();
        ClampMouseY(mouseRotation.y);
        ClampMouseX(mouseRotation.x);
        RotateCamera();
        LerpPosition();
    }
    public Vector2 MouseToCameraInput()
    {
        return new Vector2(playerManager.InputsController.MouseDelta.ReadValue<Vector2>().x * cameraSensibility, playerManager.InputsController.MouseDelta.ReadValue<Vector2>().y * cameraSensibility);
    }
    public float ClampMouseY(float mouseY)
    {
        return Mathf.Clamp(mouseY, yMinClamp, yMaxClamp);
    }
    public float ClampMouseX(float mousex)
    {
        return Mathf.Clamp(mousex, xMinClamp, xMaxClamp);
    }
    public void LerpPosition()
    {
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, followTarget.transform.position, positionLerp);
        playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, rotationTarget.transform.rotation, rotationLerp);
    }
    public void RotateCamera()
    {
        rotationTarget.transform.localRotation = Quaternion.Euler(-mouseRotation.y, mouseRotation.x + 90f, 0);
    }
    public void ApplyMouseRotation()
    {
        mouseRotation += new Vector2(playerManager.InputsController.MouseDelta.ReadValue<Vector2>().x * cameraSensibility, playerManager.InputsController.MouseDelta.ReadValue<Vector2>().y * cameraSensibility);
    }

}
