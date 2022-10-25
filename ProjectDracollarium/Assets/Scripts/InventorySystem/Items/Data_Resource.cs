using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Resource : MonoBehaviour{
    [Header("RESOURCE INFORMATION:"), Space(10)]
    [SerializeField] private Database_Resource resourceData;

    public Database_Resource GetData { get { return resourceData; } }

}
