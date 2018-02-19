using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public RectTransform inventoryPanel;
    public RectTransform equippedPanel;
    public RectTransform itemInspectionPanel;
    public RectTransform scrollViewContent;
    public List<UIBaggedItem> UIBaggedItems { get; set; }
    UIBaggedItem uiBaggedItem { get; set; }
    public List<UIEquippedItem> UIEquippedItems { get; set; }
    UIEquippedItem uiEquippedItem { get; set; }
    UIInspectionDetails itemDetailsPanel { get; set; }
    bool InventoryIsOpen { get; set; }


	void Start () {
        UIBaggedItems = new List<UIBaggedItem>();
        uiBaggedItem = Resources.Load<UIBaggedItem>("UI/UIBaggedItem");
        UIEquippedItems = new List<UIEquippedItem>();
        uiEquippedItem = Resources.Load<UIEquippedItem>("UI/UIEquippedItem");

        UIEventHandler.OnItemAddedToInventory += ItemAddedToInventory;
        UIEventHandler.OnItemRemovedFromInventory += ItemRemovedFromInventory;
        UIEventHandler.OnItemEquipped += ItemEquipped;
        UIEventHandler.OnItemUnequipped += ItemUnequipped;

        RectTransform inventoryObject = Resources.Load<RectTransform>("UI/InventoryPanel");
        inventoryPanel = Instantiate(inventoryObject);
        inventoryPanel.SetParent(GameObject.Find("UICanvas").transform, false);
        equippedPanel = inventoryPanel.Find("EquippedPanel").GetComponent<RectTransform>();
        itemInspectionPanel = inventoryPanel.Find("InventoryInspectionPanel").GetComponent<RectTransform>();
        scrollViewContent = inventoryPanel.Find("Scroll View").Find("Viewport").Find("Content").GetComponent<RectTransform>();

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

    public void ItemAddedToInventory(InventoryItem item)
    {
        UIBaggedItem uiItem = Instantiate(uiBaggedItem);
        uiItem.SetItem(item);
        uiItem.transform.SetParent(scrollViewContent, false);
        UIBaggedItems.Add(uiItem);
    }

    public void ItemRemovedFromInventory(InventoryItem item)
    {
        UIBaggedItem uiItem = UIBaggedItems.Find(x => x.item == item);
        UIBaggedItems.Remove(uiItem);
        Destroy(uiItem.gameObject);
    }

    public void ItemEquipped(InventoryItem item)
    {
        UIEquippedItem uiItem = Instantiate(uiEquippedItem);
        uiItem.SetItem(item);
        uiItem.transform.SetParent(equippedPanel.Find("Equipped" + ((Equippable)item).Slot), false);
        UIEquippedItems.Add(uiItem);
    }

    public void ItemUnequipped(InventoryItem item)
    {
        UIEquippedItem uiItem = UIEquippedItems.Find(x => x.item == item);
        UIEquippedItems.Remove(uiItem);
        Destroy(uiItem.gameObject);

        Debug.Log("Changing UI panel: Unequipped" + ((Equippable)item).Slot);

    }

    public void SetItemDetails(InventoryItem item)
    {
        itemDetailsPanel.SetItem(item);
    }

    void AddListeners()
    {

    }
}
