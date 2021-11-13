using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Material", menuName = "Game Database/Material")]
public class MaterialData : ItemData{
    [Header("MATERIAL DATA:"), Space(10)]
    [SerializeField] materialType materialType;
    [SerializeField] float cost;
    [SerializeField] float quality;
    [SerializeField] float size;
}
enum materialType{
    Raw,
    DEVELOPMENT
}
