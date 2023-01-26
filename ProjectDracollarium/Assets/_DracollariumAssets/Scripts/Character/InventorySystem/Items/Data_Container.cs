using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Dracollarium.UI;

namespace Dracollarium.Items
{

    /*  ===============================================================
     *  Clase padre para items como bolsas y cajas, contiene una lista
     *  de registros para almacenar la informacion unica de los items.
     *  
     *  Contiene los metodos necesarios para agregar un item, eliminarlo
     *  soltarlo(reinstanciarlo)
     *  ===============================================================
     */
    public abstract class Data_Container : MonoBehaviour, I_ItemData
    {
        #region FIELDS
        [Header("CONTAINER INFORMATION:"), Space(10)]
        [SerializeField] protected float usedSpace;
        [SerializeField] protected float currentDurability;
        [SerializeField, SerializeReference] List<ItemStateStats> itemsContainedData = new List<ItemStateStats>();
        #endregion

        #region PROPERTIES
        public float CurrentDurability { get { return currentDurability; } set { currentDurability = value; } }
        public float UsedSpace { get { return usedSpace; } set { usedSpace = value; } }
        abstract public float EffectIntensity { get; set; }
        abstract public float Quality { get; set; }
        abstract public Database_Item GetData { get; }
        public List<ItemStateStats> ItemsContainedData { get { return itemsContainedData; } }
        #endregion

        #region METHODS
        public void AddItem(I_ItemData itemData)
        {
            itemsContainedData.Add(new ItemStateStats(itemData.CurrentDurability, itemData.UsedSpace, itemData.EffectIntensity, itemData.Quality, itemData.ItemsContainedData, itemData.GetData));
        }
        public void DeleteItemByIndex(int itemIndex)
        {
            try
            {
                itemsContainedData.RemoveAt(itemIndex);
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] An error (" + ex.GetType() + ") has ocurred!");
            }
        }
        public void DeleteItemByIndex(object sender, EventArgs e)
        {
            DeleteItemByIndex((sender as GUI_Button_ItemActions).ItemStoredPosition);
        }

        public void DropItemByIndex(int itemIndex, GameObject axis)
        {
            try
            {
                GameObject item = Instantiate(itemsContainedData[itemIndex].data.Prefab);
                item.transform.position = axis.transform.position;
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] An error (" + ex.GetType() + ") has ocurred!");
            }
        }
        public void DropItemByIndex(object sender, EventArgs e)
        {
            DropItemByIndex((sender as GUI_Button_ItemActions).ItemStoredPosition, (sender as GUI_Button_ItemActions).PlayerManager.PlayerItemPickup.DropPosition);
        }
        #endregion
    }
}