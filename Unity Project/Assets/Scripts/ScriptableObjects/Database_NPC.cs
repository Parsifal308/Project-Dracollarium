using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "Game Database/Non Playable Character")]
public class Database_NPC : ScriptableObject
{
    [Space(10), Header("NPC BASIC INFORMATION:")]
    [SerializeField] private int id;
    [SerializeField] private string _name;
    [SerializeField] private string description;

    [Space(10)]
    [SerializeField] private NPC_Type type;

    [Space(10)]
    [SerializeField] private Sprite icon;

    [Space(10)]
    [SerializeField] private GameObject prefab;

    [Space(20), Header("RESISTANCE:")]
    [SerializeField] private float slashDmgDef;
    [SerializeField] private float bluntDmgDef;
    [SerializeField] private float piercingDmgDef;
    [SerializeField] private float scorchingDmgDef;

    [Space(20)]
    [Header("STATISTICS:")]
    [SerializeField] private float strength;
    [SerializeField] private float volition;
    [SerializeField] private float dextery;
    [SerializeField] private float endurance;
    [SerializeField] private float concentration;

}
enum NPC_Type{
    Humanoid,
    Creature
}
