using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquippedItem : MonoBehaviour {

    public InventoryItem item;

    public void SetItem(InventoryItem item)
    {
        this.item = item;
        SetupUIItemValues();
    }

    void SetupUIItemValues()
    {
        gameObject.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
        //transform.SetParent();
    }

    public void OnSelectItemButton()
    {
        // Right now clicking an equipped item will unequip it. I will probably change this to work exclusively with right click
        item.transform.root.Find("Inventory").GetComponent<InventoryController>().UnEquipItem((Equippable)item);
    }
}
