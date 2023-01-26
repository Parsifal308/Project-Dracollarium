using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character
{
    /*  ======================================================================
     *  Clase que implementa el sistema de vision del NPC, debe ser adjuntado
     *  a un game object que corresponda a la linea de vision.
     *  
     *  Detecta cuando un jugador entra en el trigger y luego intenta castear
     *  una linea hacia el personaje detectado, si nada se interpone, settea
     *  el objetivo y luego dispara un evento que sera escuchado por el metodo
     *  Seen del controlador de comportamiento
     *  ====================================================================== */
    [RequireComponent(typeof(LineRenderer))]
    public class NPC_lineOfSight : NPC_Sense
    {
        public event EventHandler OnPlayerTriggerEnter;
        private Ray sightRay;
        private RaycastHit objectHit;
        private LineRenderer sightRayLine;
        [SerializeField] private LayerMask raycastIgnore;
        [SerializeField] private float sightRange = 20f;

        private void Start()
        {
            sightRayLine = GetComponent<LineRenderer>();
            OnPlayerTriggerEnter += controller.Behaviour.Seen;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                SetRaysToPoint(other.gameObject);
                Debug.Log(other.transform.parent.gameObject.name);
                if (Physics.Raycast(sightRay, out objectHit, sightRange, ~raycastIgnore))
                {
                    if (objectHit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
                    {
                        Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] " + objectHit.transform.gameObject.name + " DETECTED BY: " + controller.transform.gameObject.name);
                        objectiveObject = objectHit.transform.gameObject;
                        sensedObjects.Add(other.gameObject);
                        controller.PanelSeen.SetActive(true);
                        OnPlayerTriggerEnter?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }
        private void SetRaysToPoint(GameObject gameObject)
        {
            sightRay.origin = controller.transform.position + new Vector3(0, 1, 0);
            sightRay.direction = (gameObject.transform.position - controller.transform.position).normalized;
            sightRayLine.SetPosition(0, controller.transform.position);
            sightRayLine.SetPosition(1, sightRay.origin + sightRay.direction * sightRange);

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("XXXXXXX SALIO DE LINEA DE VISION XXXXXXXX");
                sensedObjects.Remove(other.gameObject);
                controller.PanelSeen.SetActive(false);
            }
        }

    }
}