using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Character
{
    public class NPC_Sense : MonoBehaviour
    {
        [SerializeField] protected NPC_Controller controller;
        [SerializeField] protected GameObject objectiveObject;
        [SerializeField] protected List<GameObject> sensedObjects;
        public NPC_Controller Controller { get { return controller; } }
        public GameObject ObjectiveObject { get { return objectiveObject; } }
        public List<GameObject> SensedObjects { get { return sensedObjects; } }
        private void Awake()
        {
            controller = GetComponentInParent<NPC_Controller>();
        }
    }
}