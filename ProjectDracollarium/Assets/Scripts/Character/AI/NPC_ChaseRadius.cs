using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dracollarium.Character
{

    /*  ======================================================================
     *  Clase destinada a ir adjunta como componente en un game object que
     *  funcione como area de persecucion del npc.
     *  
     *  Si el objetivo sale del trigger, dispara un evento que el controlador
     *  de comportamiento escucha, desactiva este objeto y cambia el 
     *  comportamiento del npc para que deje de perseguir al objetivo
     *  ====================================================================== */
    public class NPC_ChaseRadius : NPC_Sense
    {
        public event EventHandler OnPlayerTriggerExit;
        private void Start()
        {
            OnPlayerTriggerExit += controller.Behaviour.OutOfChaseArea;
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == controller.Behaviour.Objective)
            {
                OnPlayerTriggerExit?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}