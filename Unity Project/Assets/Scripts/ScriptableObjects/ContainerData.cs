using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Container", menuName = "Game Database/Container")]
public class ContainerData : ScriptableObject{
    [SerializeField] public int containerId;
    [Space(10)]
    [SerializeField] containerType containerType;
    [SerializeField] string itemName;
    [TextArea(5, 10)]
    [SerializeField] string description;
    [SerializeField] float cost;
    [SerializeField] float quality;
    [SerializeField] float size;

    public float Size { get { return size; } }
}
enum containerType{
    Bag,
    Box,
    DEVELOPMENT
}