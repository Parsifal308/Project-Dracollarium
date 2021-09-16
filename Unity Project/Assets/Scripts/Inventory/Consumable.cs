using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour, I_Item{
    [SerializeField] ConsumableData consumableData;
    [SerializeField] float effectIntensity;

}
