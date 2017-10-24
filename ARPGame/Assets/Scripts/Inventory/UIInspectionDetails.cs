using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInspectionDetails : MonoBehaviour {

    InventoryItem item;
    Text itemNameText, itemDescriptionText;

    public void SetItem(InventoryItem item)
    {
        this.item = item;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
    }
    
}
