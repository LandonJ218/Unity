using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {

    public delegate void ItemEventHandler(InventoryItem item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemRemovedFromInventory;
    public static event ItemEventHandler OnItemEquipped;
    public static event ItemEventHandler OnItemUnequipped;
    public delegate void CombatEventHandler();
    public static event CombatEventHandler OnPortalSpawned;
    public static event CombatEventHandler OnPortalDestroyed;
    public static event CombatEventHandler OnAllPortalsDestroyed;
    public static event CombatEventHandler OnEnemyKilled;

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

    public static void ItemUnequipped(InventoryItem item)
    {
        OnItemUnequipped(item);
    }

    public static void PortalSpawned()
    {
        OnPortalSpawned();
    }

    public static void PortalDestroyed()
    {
        OnPortalDestroyed();
    }

    public static void AllPortalsDestroyed()
    {
        OnAllPortalsDestroyed();
    }

    public static void EnemyKilled()
    {
        OnEnemyKilled();
    }
}
