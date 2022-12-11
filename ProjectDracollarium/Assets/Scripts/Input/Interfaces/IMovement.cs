using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IMovement
{
    Vector2 MoveInput { get; }
    bool IsMoving { get; }
    bool IsSprinting { get; }
    bool IsWalking { get; }
    bool IsRunning { get; }
    void Jump(InputAction.CallbackContext obj);
    void Run(InputAction.CallbackContext obj);
    void Sprint(InputAction.CallbackContext obj);
    void Walk(InputAction.CallbackContext obj);

}
