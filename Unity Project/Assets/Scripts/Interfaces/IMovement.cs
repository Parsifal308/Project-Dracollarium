using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void Move(float speed);
    void Rotate();
    public void Enable();
    public void Disable();
}
