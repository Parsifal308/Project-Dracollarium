using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularBuildingAxisReferences : MonoBehaviour{
    #region FIELDS
    [SerializeField] private GameObject centerAxis;
    [SerializeField] private GameObject leftAxis;
    [SerializeField] private GameObject rightAxis;
    [SerializeField] private GameObject upperAxis;
    [SerializeField] private GameObject lowerAxis;
    #endregion
    #region PROPERTIES
    public GameObject LeftAxis { get { return leftAxis; } }
    public GameObject CenterAxis { get { return centerAxis; } }
    public GameObject RightAxis { get { return rightAxis; } }
    public GameObject UpperAxis { get { return upperAxis; } }
    public GameObject LowerAxis { get { return lowerAxis; } }
    #endregion
}
