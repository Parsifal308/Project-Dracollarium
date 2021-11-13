using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Container", menuName = "Game Database/Container")]
public class ContainerData : ItemData{
    [Header("CONTAINER DATA:"), Space(10)]
    [SerializeField] containerType containerType;
    [TextArea(5, 10)]
    [SerializeField] float cost;
    [SerializeField] float quality;
    [SerializeField] float size;

    public float Size { get { return size; } }
    public string ItemName { get { return name; } }
}
enum containerType{
    Bag,
    Box,
    DEVELOPMENT
}