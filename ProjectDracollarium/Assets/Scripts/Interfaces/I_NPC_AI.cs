using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_NPC_AI
{
    public void Walk();
    public void Run();
    public void Sprint();
    public void DetectActor();
    public void DetectActorInFront();
    public void EquipItem();
    public void ConsumeItem();
    public void DeleteItem();
    public void Die();
    public void Idle();

}
public enum NPCType
{
    friendly,
    enemy,
    neutral
}
