using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.UI
{
    public class UIController : MonoBehaviour
    {
        #region FIELDS
        [Header("GRAPHIC USER INTERFACE: "), Space(10)]
        [Tooltip("")]
        [SerializeField] private Canvas pauseMenu;
        #endregion

        #region PROPERTIES
        public Canvas PauseMenu { get { return pauseMenu; } }
        #endregion

        #region UNITY METHODS
        void Start()
        {

        }
        #endregion

        #region PUBLIC METHODS
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region EVENTS METHODS
        #endregion


    }
}