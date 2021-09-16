using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Material", menuName = "Game Database/Material")]
public class MaterialData : ScriptableObject{
    [SerializeField] public int materialId;
    [SerializeField] materialType materialType;
    [TextArea(5, 10)]
    [SerializeField] string itemName;
    [TextArea(5, 10)]
    [SerializeField] string description;
    [SerializeField] float cost;
    [SerializeField] float quality;
    [SerializeField] float size;
}
enum materialType{
    Raw,
    DEV
}
