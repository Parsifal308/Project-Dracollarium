using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.UI
{
    public class UIController : MonoBehaviour
    {
        [Header("GRAPHIC USER INTERFACE: "), Space(10)]
        [Tooltip("")]
        [SerializeField] private GUI_Menu menuBuilding;
        [Tooltip("")]
        [SerializeField] private GUI_Menu menuBuildingCategory;
        [Tooltip("")]
        [SerializeField] private GUI_Menu menuBuildingModule;
        [Tooltip("")]
        [SerializeField] private GUI_Menu menuEquipment;
        [Tooltip("")]
        [SerializeField] private GameObject menuEquipmentContent;
        [Tooltip("")]
        [SerializeField] private PauseMenu menuPause;
        [Tooltip("")]
        [SerializeField] private GUI_Menu menuInventory;

        #region PROPERTIES
        public GameObject MenuEquipmentContent { get { return menuEquipmentContent; } }
        public GUI_Menu BuildingMenu { get { return menuBuilding; } set { menuBuilding = value; } }
        public GUI_Menu EquipmentMenu { get { return menuEquipment; } set { menuEquipment = value; } }
        public PauseMenu PauseMenu { get { return menuPause; } set { menuPause = value; } }
        #endregion

        public void DisableAllMenus(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            menuBuilding.DisableMenu();
            menuBuildingCategory.DisableMenu();
            menuBuildingModule.DisableMenu();
            menuEquipment.DisableMenu();
            menuInventory.DisableMenu();
        }
    }
}