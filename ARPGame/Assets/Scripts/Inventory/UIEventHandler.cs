using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {

    public delegate void ItemEventHandler(InventoryItem item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemRemovedFromInventory;
    public static event ItemEventHandler OnItemEquipped;

    public static void ItemAddedToInventory(InventoryItem item)
    {
        OnItemAddedToInventory(item);
    }

    public static void ItemRemovedFromInventory(InventoryItem item)
    {
        OnItemRemovedFromInventory(item);
    }

    public static void ItemEquipped(InventoryItem item)
    {
        OnItemEquipped(item);
    }

}
