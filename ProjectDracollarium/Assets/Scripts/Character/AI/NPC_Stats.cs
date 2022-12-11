using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character
{
    public class NPC_Stats : MonoBehaviour
    {

        private NPC_Controller controller;
        [Header("CHARACTER HEALTH STATS:"), Space(10)]
        [SerializeField] private float maxHealth;
        [SerializeField] private float currentHealth;
        [SerializeField] private bool isDead;

        [SerializeField] private GameObject triggeredObject;
        [SerializeField] private float stunDuration = 0.1f;
        [SerializeField] private bool isStunned;


        public event EventHandler OnNPCDeath, OnHitLightAttack;

        private void Start()
        {
            controller = GetComponent<NPC_Controller>();
            OnNPCDeath += controller.Behaviour.DieListener;
            OnHitLightAttack += controller.AnimationController.HitLightAttack_01;
        }
        private void FixedUpdate()
        {
            if (isStunned)
            {
                controller.Rigidbody.MovePosition(controller.Rigidbody.position += ((this.transform.position - triggeredObject.transform.position).normalized));
            }
        }
        public void TakeDamage(float damage, GameObject triggerer)
        {
            currentHealth -= damage;
            isStunned = true;
            StartCoroutine(StunDuration());
            OnHitLightAttack?.Invoke(this, EventArgs.Empty);
            triggeredObject = triggerer;
            //controller.Rigidbody.position += ((this.transform.position - triggerer.transform.position).normalized * 2);
            if (currentHealth <= 0)
            {
                isDead = true;
                OnNPCDeath?.Invoke(this, EventArgs.Empty);
            }
        }
        public void RecoverHealth(float heal)
        {
            currentHealth += heal;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        IEnumerator StunDuration()
        {
            yield return new WaitForSeconds(stunDuration);
            isStunned = false;
        }
    }
}