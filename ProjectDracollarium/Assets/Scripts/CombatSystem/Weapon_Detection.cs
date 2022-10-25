using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Detection : MonoBehaviour
{
    [SerializeField] private GameObject owner;
    [SerializeField] private bool isDoingDamage = false;

    public bool IsDoingDamage { get { return isDoingDamage; }set { isDoingDamage = value; } }
    public void Blocked()
    {
        Debug.Log(this.gameObject.name + " attack has been blocked");
    }
    public void Block()
    {
        Debug.Log(this.gameObject.name + " has blocked han attack");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (owner != null){
            if (owner.layer == LayerMask.NameToLayer("Player") && isDoingDamage){
                if (other.gameObject.layer == LayerMask.NameToLayer("NPC")){
                    Debug.Log(this.gameObject.name + " has reached" + other.transform.gameObject.name);
                    other.GetComponent<NPC_Stats>().TakeDamage(25, GetComponentInParent<CharacterController>().gameObject);
                    isDoingDamage = false;
                }
                else if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Weapon"))){
                    Debug.Log(this.gameObject.name + " has reached a Weapon");
                }
            }
            if (owner.layer == LayerMask.NameToLayer("NPC") && isDoingDamage){
                if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
                    Debug.Log(this.gameObject.name + " has reached" + other.transform.gameObject.name);
                    other.GetComponentInParent<Player_Stats>().TakeDamage(25);
                    isDoingDamage = false;
                }
            }
        }
    }
}
