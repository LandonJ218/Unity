using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {

    public delegate void ItemEventHandler(InventoryItem item);
    public static event ItemEventHandler OnItemAddedToInventory;

	public static void ItemAddedToInventory(InventoryItem item)
    {
        OnItemAddedToInventory(item);
    }

}
