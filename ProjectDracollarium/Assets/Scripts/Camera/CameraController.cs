using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region FIELDS
    private PlayerManager playerManager;
    [Tooltip("Player's main camera")]
    [SerializeField] private Camera playerCamera;
    [Tooltip("empty object which the camera will follow by linear interpolation")]
    [SerializeField] private GameObject followTarget;
    [Tooltip("empty object from which the camera will take the rotation value")]
    [SerializeField] private GameObject rotationTarget;
    [Tooltip("camera sensitivity value")]
    [SerializeField] private float cameraSensibility = 0.25f;
    [Tooltip("Minimum Y value for camera rotation")]
    [SerializeField] private float yMinClamp = -25f;
    [Tooltip("Maximum Y value for camera rotation")]
    [SerializeField] private float yMaxClamp = 25f;
    [Tooltip("Minimum X value for camera rotation")]
    [SerializeField] private float xMinClamp = -360f;
    [Tooltip("Maximum X value for camera rotation")]
    [SerializeField] private float xMaxClamp = 360f;
    [Tooltip("Linear interpolation ratio value for positioning")]
    [SerializeField] private float positionLerp = 0.05f;
    [Tooltip("Linear interpolation ratio value for rotation")]
    [SerializeField] private float rotationLerp = 0.05f;
    [Space(10)]
    [Header("CONTROL VARIABLES:")]
    [Tooltip("Control flag for mouse enabled")]
    [ShowOnly][SerializeField] private bool isMouseEnabled = true;
    private Vector2 mouseRotation;
    #endregion

    #region PROPERTIES
    public Camera PlayerCamera { get { return playerCamera; } }
    public float CameraSensibility { get { return cameraSensibility; } set { cameraSensibility = value; } }
    public bool IsMouseEnabled { get { return isMouseEnabled; } set { isMouseEnabled = value; } }
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
