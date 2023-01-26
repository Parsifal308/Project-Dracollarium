using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Material", menuName = "Dracollarium/Item/Material")]
public class Database_Material : Database_Item{
    [Header("MATERIAL DATA:"), Space(10)]
    [SerializeField] private materialType materialType;
    [SerializeField] private float cost;
    [SerializeField] private float quality;
    [SerializeField] private float size;
}
enum materialType{
    Raw,
    DEVELOPMENT
}
