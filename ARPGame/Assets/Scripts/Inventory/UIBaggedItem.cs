﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBaggedItem : MonoBehaviour {

    public InventoryItem item;

    public void SetItem(InventoryItem item)
    {
        this.item = item;
        SetupUIItemValues();
    }

    void SetupUIItemValues()
    {
        transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
        transform.Find("ItemIcon").GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
    }

    public void OnSelectItemButton()
    {
        // Right now clicking an item in inventory will equip it. I will probably change this to work exclusively with right click
        item.transform.parent.GetComponent<InventoryController>().EquipItem((Equippable)item);
    }
}