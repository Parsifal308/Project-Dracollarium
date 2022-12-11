using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularBuilidingAxis : MonoBehaviour
{
    [SerializeField] private Axis axis;
    public Axis Axis { get { return axis; } }
}
public enum Axis{
    LeftAxis,
    RightAxis,
    UpperAxis,
    LowerAxis,
    CenterAxis,
    None
}