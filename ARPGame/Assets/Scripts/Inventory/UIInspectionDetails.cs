using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInspectionDetails : MonoBehaviour {

    InventoryItem item;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractButtonText;

    public void SetItem(InventoryItem item, Button selectedButton)
    {
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
        itemInteractButtonText.text = item.ActionName;
        itemInteractButton.onClick.AddListener(OnItemInteract);
    }

    public void OnItemInteract()
    {
        if (item.ActionName == "Equip")
        {

        }
    }
}
