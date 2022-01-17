using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*  ===========================================================
 *  Clase utilizada para controlar la logica de los botones
 *  "Inspect", "Drop", "Use" y "Equip" del menu de acciones
 *  de items del inventario
 *  
 *  Notas:
 *      Implementado momentaneamente solo para slot de
 *      bolsa de espalda (back)
 *  ===========================================================
 */
public class GUI_Button_ItemActions : GUI_Menu{
    [SerializeField] private int itemStoredPosition;
    private event EventHandler OnItemDrop, OnItemDelete;
    //private Controller_PlayerManager controller_PlayerManager;
    public int ItemStoredPosition { get { return itemStoredPosition; } set { itemStoredPosition = value; } }

    private void Start()
    {
        controller_PlayerManager = GetComponentInParent<Controller_PlayerManager>();
        Debug.Log("INTENTADO SUSBSCRIBIR UN METODO A EVENTO");
        OnItemDrop += controller_PlayerManager.PlayerEquipment.Back.DropItemByIndex;
        OnItemDelete += controller_PlayerManager.PlayerEquipment.Back.DeleteItemByIndex;

    }
    public void InspectItem()
    {
        
    }
    public void DropItem()
    {
        OnItemDrop?.Invoke(this, EventArgs.Empty);//instanciar item
        OnItemDelete?.Invoke(this, EventArgs.Empty); //borrar item de inventario
        transform.GetComponentInParent<GUI_Menu_Inventory>().LoadBackItems(); //mostrar inventario actualizado
    }
    public void EquipItem()
    {

    }
    public void UseItem()
    {

    }
}
