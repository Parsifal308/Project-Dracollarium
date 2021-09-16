using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour, I_Item {
    [SerializeField] ContainerData bagData;
    float usedSpace;
    List<I_Item> itemsContained;

}
