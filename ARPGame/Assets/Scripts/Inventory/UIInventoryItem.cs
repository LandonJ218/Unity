using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour {

    public InventoryItem item;

    public void SetItem(InventoryItem item)
    {
        this.item = item;
        SetupItemValues();
    }

    void SetupItemValues()
    {
        transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
    }

    public void OnSelectItemButton()
    {
        // This Find() method is super expensive and is only done this way because it will for sure be changed 
        // in the multiplayer version there will be multiple players (multiple InventoryControllers)
        GameObject.Find("Player").GetComponent<InventoryController>().SetItemDetails(item, GetComponent<Button>());
    }
}
