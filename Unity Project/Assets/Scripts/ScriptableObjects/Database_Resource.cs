using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "Game Database/Resource")]
public class Database_Resource : ScriptableObject{
    [Header("RESOURCE  DATA:"), Space(10)]

    [SerializeField] private ArrayList itemsDropped;
    [Space(10)]
    [SerializeField] private resourceType resourceType;
    [TextArea(5, 10)]
    [SerializeField] private float quality;
    [Space(30)]
    [SerializeField] private float maxResistance;
    [SerializeField] private float slashDmgDef;
    [SerializeField] private float bluntDmgDef;
    [SerializeField] private float piercingDmgDef;
    [SerializeField] private float scorchingDmgDef;
}
enum resourceType{
    Wood,
    Mining,
    Plants,
    Hunt,
    DEVELOPMENT
}
