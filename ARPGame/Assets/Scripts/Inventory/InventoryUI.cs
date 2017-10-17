using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    UIInventoryItem itemContainer { get; set; }
    bool InventoryIsOpen { get; set; }


	// Use this for initialization
	void Start () {
        itemContainer = Resources.Load<UIInventoryItem>("UI/ItemContainer");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        InventoryIsOpen = false;
        inventoryPanel.gameObject.SetActive(InventoryIsOpen);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Inventory toggled.");
            InventoryIsOpen = !InventoryIsOpen;
            inventoryPanel.gameObject.SetActive(InventoryIsOpen);
        }
    }

    public void ItemAdded(InventoryItem item)
    {
        UIInventoryItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent, false);
    }
}
