using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Dracollarium.Player;

namespace Dracollarium
{
    public class EnableOnKeyStarted : MonoBehaviour
    {
        public event EventHandler OnMenuEnabled; //escuchado desde ICamera para activar/desactivar mouse
        private void Start()
        {
            OnMenuEnabled += GetComponentInParent<PlayerManager>().DisableMouseRotation;
        }
        public void EnableMenu(InputAction.CallbackContext value)
        {    //invocado cada vez que se presiona tecla de construir desde InputSystem"
            if (value.started)
            {
                this.gameObject.SetActive(true);
                OnMenuEnabled?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}