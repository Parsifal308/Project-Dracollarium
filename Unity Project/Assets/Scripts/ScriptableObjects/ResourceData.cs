using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "Game Database/Resource")]
public class ResourceData : ScriptableObject{
    [Header("RESOURCE  DATA:"), Space(10)]

    [SerializeField] ArrayList itemsDropped;
    [Space(10)]
    [SerializeField] resourceType resourceType;
    [TextArea(5, 10)]
    [SerializeField] float quality;
    [Space(30)]
    [SerializeField] float maxResistance;
    [SerializeField] float slashDmgDef;
    [SerializeField] float bluntDmgDef;
    [SerializeField] float piercingDmgDef;
    [SerializeField] float scorchingDmgDef;
}
enum resourceType{
    Wood,
    Mining,
    Plants,
    Hunt,
    DEVELOPMENT
}
