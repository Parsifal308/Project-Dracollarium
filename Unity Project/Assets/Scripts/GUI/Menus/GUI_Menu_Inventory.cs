using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
/*  =============================================================
 *  Clase que implementa el GUI de las bolsas equipadas,
 *  contiene metodos que limpian y muestran los items
 *  almacenados en cada bolsa.
 *  =============================================================
 */
public class GUI_Menu_Inventory : GUI_Menu
{

    private Transform[] content;
    [Header("GRAPHIC USER INTERFACE: "), Space(10)]
    [SerializeField] Button backBagButton;
    [SerializeField] Button rightShoulderButton;
    [SerializeField] Button leftShoulderButton;
    [SerializeField] Button rightHipButton;
    [SerializeField] Button leftHipButton;

    [Header("GUI Prefabs:"), Space(10)]
    [SerializeField] GameObject GUI_bagItemPrefab;

    public void LoadInventory()
    {
        if (CheckForBags()){
            Debug.Log("HAY UNO QUE NO ES NULO");
            SetBagsButtonsInteract();
            if (this.gameObject.activeSelf == false)
            {
                EnableDisableMenu();
            }
        }
        else
        {
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] No bag equipped");
        }
    }
    public void CleanInventoryContent()
    {
        Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Cleaning Inventory GUI Content...");
        try
        {
            content = ControllerPlayerManager.MenuEquipmentContent.transform.GetComponentsInChildren<Transform>();
            for (int i = 1; i < content.Length; i++)
            {
                Destroy(content[i].gameObject);
            }
            Debug.LogFormat("<color=#00ff00> {0} </color>", "-->[LOG] Inventory GUI Content CLEANED.");
        }
        catch(Exception ex)
        {
            Debug.LogError("----->[ERROR] A [" + ex.GetType() + "] ocurred while trying to clean inventory GUI content.");
        } 
    }
    public void LoadBackItems()
    {
        CleanInventoryContent();
        SetBagButtonsDefaultColor();
        backBagButton.GetComponent<Image>().color = Color.green;
        try
        {
            content = ControllerPlayerManager.MenuEquipmentContent.transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < ControllerPlayerManager.PlayerEquipment.Back.ItemsContainedData.Count; i++)
            {
                Debug.Log(ControllerPlayerManager.PlayerEquipment.Back.ItemsContainedData[i].data.name);
                GameObject item = Instantiate(GUI_bagItemPrefab);
                item.transform.parent = content[0];
                item.transform.GetComponentInChildren<TextMeshProUGUI>().text = ControllerPlayerManager.PlayerEquipment.Back.ItemsContainedData[i].data.name;
                item.GetComponent<GUI_Button_ItemActions>().ItemStoredPosition = i;
            }
        }catch (Exception ex)
        {
            Debug.LogError("----->[ERROR] A [" + ex.GetType() + "] ocurred while trying to load back bag inventory GUI content.");
        }
    }
    public void LoadLeftShoulderItems()
    {
        CleanInventoryContent();
        SetBagButtonsDefaultColor();
        leftShoulderButton.GetComponent<Image>().color = Color.green;
            try
            {
                foreach (var itemContained in ControllerPlayerManager.PlayerEquipment.LeftShoulder.ItemsContainedData)
                {
                    Debug.Log(itemContained.data.name);
                    GameObject item = Instantiate(GUI_bagItemPrefab);
                    item.transform.parent = content[0];
                    item.transform.GetComponentInChildren<TextMeshProUGUI>().text = itemContained.data.name;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("----->[ERROR] A [" + ex.GetType() + "] ocurred while trying to load left shoulder bag inventory GUI content.");
            }
    }
    public void LoadRightShoulderItems()
    {
        CleanInventoryContent();
        SetBagButtonsDefaultColor();
        rightShoulderButton.GetComponent<Image>().color = Color.green;
        try
        {
            foreach (var itemContained in ControllerPlayerManager.PlayerEquipment.RightShoulder.ItemsContainedData)
            {
                Debug.Log(itemContained.data.name);
                GameObject item = Instantiate(GUI_bagItemPrefab);
                item.transform.parent = content[0];
                item.transform.GetComponentInChildren<TextMeshProUGUI>().text = itemContained.data.name;
            }
        }catch(Exception ex)
        {
            Debug.LogError("----->[ERROR] A [" + ex.GetType() + "] ocurred while trying to load right shoulder bag inventory GUI content.");
        }
    }
    public void LoadLeftHipItems()
    {
        CleanInventoryContent();
        SetBagButtonsDefaultColor();
        leftHipButton.GetComponent<Image>().color = Color.green;
        try
        {

            foreach (var itemContained in ControllerPlayerManager.PlayerEquipment.LeftHip.ItemsContainedData)
            {
                Debug.Log(itemContained.data.name);
                GameObject item = Instantiate(GUI_bagItemPrefab);
                item.transform.parent = content[0];
                item.transform.GetComponentInChildren<TextMeshProUGUI>().text = itemContained.data.name;
            }
        }catch(Exception ex)
        {
            Debug.LogError("----->[ERROR] A [" + ex.GetType() + "] ocurred while trying to load left hip bag inventory GUI content.");
        }
    }
    public void LoadRightHipItems()
    {
        CleanInventoryContent();
        SetBagButtonsDefaultColor();
        rightHipButton.GetComponent<Image>().color = Color.green;
        try
        {
            foreach (var itemContained in ControllerPlayerManager.PlayerEquipment.RightHip.ItemsContainedData)
            {
                Debug.Log(itemContained.data.name);
                GameObject item = Instantiate(GUI_bagItemPrefab);
                item.transform.parent = content[0];
                item.transform.GetComponentInChildren<TextMeshProUGUI>().text = itemContained.data.name;
            }
        }catch(Exception ex)
        {
            Debug.LogError("----->[ERROR] A [" + ex.GetType() + "] ocurred while trying to load right hip bag inventory GUI content.");
        }
    }
    public void SetBagButtonsDefaultColor()
    {
        backBagButton.GetComponent<Image>().color = Color.white;
        leftShoulderButton.GetComponent<Image>().color = Color.white;
        rightShoulderButton.GetComponent<Image>().color = Color.white;
        leftHipButton.GetComponent<Image>().color = Color.white;
        rightHipButton.GetComponent<Image>().color = Color.white;
    }
    public void SetBagsButtonsInteract()
    {
        if (ControllerPlayerManager.PlayerEquipment.Back == null){
            backBagButton.interactable = false;
        }else{backBagButton.interactable = true;}

        if (ControllerPlayerManager.PlayerEquipment.LeftHip == null){
            leftHipButton.interactable = false;
        }else{leftHipButton.interactable = true;}

        if (ControllerPlayerManager.PlayerEquipment.RightHip == null){
            rightHipButton.interactable = false;
        }else{rightHipButton.interactable = true;}

        if (ControllerPlayerManager.PlayerEquipment.RightShoulder == null){
            rightShoulderButton.interactable = false;
        }else{rightShoulderButton.interactable = true;}

        if (ControllerPlayerManager.PlayerEquipment.LeftShoulder == null){
            leftShoulderButton.interactable = false;
        }else{leftShoulderButton.interactable = true;}
    }
    public bool CheckForBags()
    {
        if (ControllerPlayerManager.PlayerEquipment.Back != null ||
            ControllerPlayerManager.PlayerEquipment.RightShoulder != null ||
            ControllerPlayerManager.PlayerEquipment.LeftShoulder != null ||
            ControllerPlayerManager.PlayerEquipment.RightHip != null ||
            ControllerPlayerManager.PlayerEquipment.LeftHip != null)
        {return true;}
        else { return false; } }
        
        
}
