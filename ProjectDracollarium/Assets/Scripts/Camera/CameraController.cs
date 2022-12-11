using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Player
{
    public class CameraController : MonoBehaviour
    {
        #region FIELDS
        private PlayerManager playerManager;
        [Tooltip("Player's main camera")]
        [SerializeField] private Camera playerCamera;
        [Tooltip("empty object which the camera will follow by linear interpolation")]
        [SerializeField] private GameObject cameraPosition;
        [Tooltip("empty object from which the camera will take the rotation value")]
        [SerializeField] private GameObject cameraRotation;
        [Tooltip("camera sensitivity value")]
        [SerializeField] private float cameraSensibility = 0.25f;
        [Tooltip("Minimum Y value for camera rotation. if it is zero then there will be no clamp")]
        [SerializeField] private float yMinClamp = 0f;
        [Tooltip("Maximum Y value for camera rotation, if it is zero then there will be no clamp")]
        [SerializeField] private float yMaxClamp = 0f;
        [Tooltip("Minimum X value for camera rotation, if it is zero then there will be no clamp")]
        [SerializeField] private float xMinClamp = 0f;
        [Tooltip("Maximum X value for camera rotation, if it is zero then there will be no clamp")]
        [SerializeField] private float xMaxClamp = 0f;
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

        #region UNITY METHODS
        void Start()
        {
            playerManager = GetComponent<PlayerManager>();
        }
        void Update()
        {
            ApplyMouseRotation();
            mouseRotation.y = ClampMouse(mouseRotation.y, yMinClamp, yMaxClamp);
            mouseRotation.x = ClampMouse(mouseRotation.x, xMinClamp, xMaxClamp);
            RotateCamera();
            LerpPosition();
        }
        #endregion

        #region METHODS
        /// <summary>Returns mouse inputs multiplied by the configured sensitivity.</summary>
        public Vector2 MouseToCameraInput()
        {
            return new Vector2(playerManager.InputsController.MouseDelta.ReadValue<Vector2>().x * cameraSensibility, playerManager.InputsController.MouseDelta.ReadValue<Vector2>().y * cameraSensibility);
        }

        /// <summary>Clamps the input between two given values.</summary>
        /// <returns>The clamped value if the min and max are different than zero</returns>
        public float ClampMouse(float mouseInput, float minClamp, float maxClmap)
        {
            if (minClamp != 0f && maxClmap != 0f)
            {
                return Mathf.Clamp(mouseInput, minClamp, maxClmap);
            }
            else
            {
                return mouseInput;
            }
        }

        /// <summary>Moves and rotates the camera according to the position of the cameraPosition and cameraRotation object respectively.</summary>
        public void LerpPosition()
        {
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, cameraPosition.transform.position, positionLerp);
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, cameraRotation.transform.rotation, rotationLerp);
        }

        /// <summary>Rotates the camera according to the values stored in the local variable mouseRotation.</summary>
        public void RotateCamera()
        {
            cameraRotation.transform.localRotation = Quaternion.Euler(-mouseRotation.y, mouseRotation.x + 90f, 0);
        }

        /// <summary>Saves mouse input in the local variable mouseRotation.</summary>
        public void ApplyMouseRotation()
        {
            mouseRotation += new Vector2(playerManager.InputsController.MouseDelta.ReadValue<Vector2>().x * cameraSensibility, playerManager.InputsController.MouseDelta.ReadValue<Vector2>().y * cameraSensibility);
        }
        #endregion
    }
}