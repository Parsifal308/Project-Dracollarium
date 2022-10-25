using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*  ======================================================================
 *  clase base de la que heredan los comportamientos de los distintos
 *  tipo de NPC. Contiene comportamientos basicos como perseguir, morir,
 *  consumir un objeto, etc.
 *  
 *  Contiene un selector, utilizando un enum, para el comportamiento que
 *  se esta llevando en el momento
 *  ====================================================================== */

public class NPC_BaseBehaviour_AI : MonoBehaviour, I_NPC_AI
{
    NPC_Controller controller;

    [Space(10), Header("SETTINGS:")]
    [SerializeField] NPC_Behaviour behaviour;
    [SerializeField] Current_Behaviour currentBehaviour;
    [Space(10), Header("TRIGGERS:")]
    [SerializeField] GameObject senseRadius;
    [SerializeField] GameObject lineOfSight;
    [SerializeField] GameObject chaseRadius;
    [Space(15), Header("OBJECTIVES")]
    [SerializeField] GameObject sensedObject;
    [SerializeField] GameObject objective;
    [SerializeField] List<GameObject> patrolDestinations;
    [Space(15), Header("CONTROL VARIABLE")]
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] bool isDestinationReached = false;
    [SerializeField] bool isDead;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] int patrolDestinationIndex;
    [SerializeField] bool patrolDirection;


    public event EventHandler onWalking, onRunning, onSprinting, onIdle, OnCombatMode, OnLightAttackD1, OnLightAttackD3, OnLightAttack, OnOutOfCombat;

    public GameObject Objective { get { return objective; } }

    internal void Seen(object sender, EventArgs e)
    {
        objective = (sender as NPC_lineOfSight).ObjectiveObject;
    }

    internal void OutOfChaseArea(object sender, EventArgs e)
    {
        objective = null;
        currentBehaviour = Current_Behaviour.None;
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        controller = GetComponent<NPC_Controller>();

        onWalking += controller.AnimationController.Walk;
        onSprinting += controller.AnimationController.Sprint;
        onRunning += controller.AnimationController.Run;
        onIdle += controller.AnimationController.Idle;
        OnCombatMode += controller.AnimationController.CombatMode;
        OnLightAttackD1 += controller.AnimationController.LightAttackD1;
        OnLightAttackD3 += controller.AnimationController.LightAttackD3;
        OnLightAttack += controller.AnimationController.LightAttack;
        OnOutOfCombat += controller.AnimationController.OutOfCombat;

    }
    private void LateUpdate()
    {
        controller.AnimationController.SetMovementZ(navMeshAgent.velocity.normalized.magnitude);
        if (currentBehaviour == Current_Behaviour.RoundPatrollling)
        {
            PatrolRound();
        }
        if (currentBehaviour == Current_Behaviour.CyclicRoundPatrolling)
        {
            PatrolCyclicRound();
        }
        if (currentBehaviour != Current_Behaviour.ChasingObjective)
        {
            controller.ChaseRadius.transform.gameObject.SetActive(false);
        }
        if (currentBehaviour == Current_Behaviour.ChasingObjective && objective != null)
        {
            ChaseObjective(objective, MoveSpeed.Run);
        }
        if (currentBehaviour == Current_Behaviour.RandomPatrolling)
        {

        }
        if (currentBehaviour == Current_Behaviour.LookingObjective && objective != null)
        {
            transform.LookAt(objective.transform);
        }
        if (currentBehaviour == Current_Behaviour.Dead)
        {
            Die();
        }
        if (currentBehaviour == Current_Behaviour.AttackingObjective && objective != null)
        {
            ChaseObjective(objective, MoveSpeed.Run);
            DestinationReached();
            if (isDestinationReached)
            {
                OnCombatMode?.Invoke(this, EventArgs.Empty);
                OnLightAttack?.Invoke(this, EventArgs.Empty);
                OnLightAttackD3?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                OnOutOfCombat?.Invoke(this, EventArgs.Empty);
            }
        }
        if (currentBehaviour == Current_Behaviour.Idle)
        {

        }
    }

    internal void ChaseObjective(GameObject objective, MoveSpeed moveSpeed)
    {
        if (!controller.ChaseRadius.transform.gameObject.activeSelf)
        {
            controller.ChaseRadius.transform.gameObject.SetActive(true);
        }
        if (sensedObject == null)
        {
            this.sensedObject = objective;

        }
        navMeshAgent.SetDestination(objective.transform.position);
        switch (moveSpeed)
        {
            case MoveSpeed.Walk:
                Walk();
                break;
            case MoveSpeed.Run:
                Run();
                break;
            case MoveSpeed.Sprint:
                Sprint();
                break;
        }
    }

    public void DestinationReached()
    {
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    isDestinationReached = true;
                }

            }
            else
            {
                isDestinationReached = false;
            }
        }
    }
    public void ConsumeItem()
    {
        throw new System.NotImplementedException();
    }
    public void DeleteItem()
    {
        throw new System.NotImplementedException();
    }
    public void DetectActor()
    {
        throw new System.NotImplementedException();
    }
    public void DetectActorInFront()
    {
        throw new System.NotImplementedException();
    }
    public void Die()
    {
        if (!isDead)
        {
            controller.AnimationController.Animator.enabled = false;
            isDead = true;
        }
    }
    public void DieListener(object sender, EventArgs e)
    {
        currentBehaviour = Current_Behaviour.Dead;
    }
    public void EquipItem()
    {
        throw new System.NotImplementedException();
    }

    public void Walk()
    {
        navMeshAgent.speed = walkSpeed;
        onWalking?.Invoke(this, EventArgs.Empty);
    }

    public void Run()
    {
        navMeshAgent.speed = runSpeed;
        onRunning?.Invoke(this, EventArgs.Empty);
    }

    public void Sprint()
    {
        navMeshAgent.speed = sprintSpeed;
        onSprinting?.Invoke(this, EventArgs.Empty);
    }

    public void Idle()
    {
        navMeshAgent.isStopped = true; ;
        onIdle?.Invoke(this, EventArgs.Empty);
    }
    public void PatrolRound()
    {
        navMeshAgent.SetDestination(patrolDestinations[patrolDestinationIndex].transform.position);
        DestinationReached();
        if (isDestinationReached)
        {
            if (patrolDestinationIndex == 0)
            {
                patrolDestinationIndex++;
                patrolDirection = true;
            }
            else if (patrolDestinationIndex == patrolDestinations.Count - 1)
            {
                patrolDestinationIndex--;
                patrolDirection = false;
            }
            else if (patrolDirection)
            {
                patrolDestinationIndex++;
            }
            else
            {
                patrolDestinationIndex--;
            }

            isDestinationReached = false;
        }
    }
    public void PatrolCyclicRound()
    {
    }
}
enum NPC_Behaviour
{
    Neutral,
    Hostile,
    Friendly,
    Nature
}
enum Current_Behaviour
{
    Idle,
    RandomPatrolling,
    RoundPatrollling,
    CyclicRoundPatrolling,
    ChasingObjective,
    LookingObjective,
    AttackingObjective,
    Dead,
    None
}
enum MoveSpeed
{
    Walk,
    Run,
    Sprint
}
