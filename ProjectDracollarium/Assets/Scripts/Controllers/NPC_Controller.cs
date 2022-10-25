using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ======================================================================
 *  Clase controladora del NPC, contiene referencias al resto de scripts
 *  y provee propiedades para acceder a ellos.
 *  ====================================================================== */
[RequireComponent(typeof(NPC_Animation_Dracollarium))]
[RequireComponent(typeof(NPC_BaseBehaviour_AI))]
public class NPC_Controller : MonoBehaviour
{
    NPC_Animation_Dracollarium animation_Controller;
    NPC_BaseBehaviour_AI behaviourController;
    NPC_lineOfSight lineOfSight;
    NPC_ChaseRadius chaseRadius;
    NPC_Equipment equipment;
    Rigidbody rigidBody;
    [SerializeField] GameObject panelSeen;
    
    [SerializeField] Database_NPC npc_Data;

    public Rigidbody Rigidbody { get { return rigidBody; } }
    public NPC_Equipment Equipment { get { return equipment; } }
    public NPC_Animation_Dracollarium AnimationController { get { return animation_Controller; } }
    public NPC_BaseBehaviour_AI Behaviour { get { return behaviourController; } }
    public NPC_lineOfSight LineOfSightController { get { return lineOfSight; } }
    public NPC_ChaseRadius ChaseRadius { get { return chaseRadius; } }
    public GameObject PanelSeen { get { return panelSeen; } }
    private void Awake(){
        animation_Controller = GetComponent<NPC_Animation_Dracollarium>();
        behaviourController = GetComponent<NPC_BaseBehaviour_AI>(); 
        lineOfSight = GetComponentInChildren<NPC_lineOfSight>();
        chaseRadius = GetComponentInChildren<NPC_ChaseRadius>();
        equipment = GetComponent<NPC_Equipment>();
        rigidBody = GetComponent<Rigidbody>();
    }
}
