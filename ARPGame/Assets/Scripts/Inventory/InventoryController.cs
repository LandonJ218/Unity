using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {


    public UIInspectionDetails itemDetailsPanel;
    public UIInventoryItem uiInventoryItem;

    public List<InventoryItem> baggedItems = new List<InventoryItem>();
    public List<Equippable> equippedItems = new List<Equippable>();

    CharacterStats characterStats;
    PlayerWeaponController playerWeaponController { get; set; }

    void Start()
    {
        characterStats = gameObject.GetComponent<CharacterStats>();
        playerWeaponController = gameObject.GetComponent<PlayerWeaponController>();

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (GetComponent<InventoryController>().baggedItems.Count > 0)
            {
                EquipItem((Equippable)baggedItems[0]);
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (GetComponent<InventoryController>().baggedItems.Count > 0)
            {
                DropItem((Equippable)baggedItems[0]);
            }
        }
    }

    public void TakeItem(InventoryItem targetItem)
    {
        baggedItems.Add(targetItem);
        targetItem.GetComponent<MeshRenderer>().enabled = false;
        targetItem.GetComponent<Collider>().enabled = false;
        UIEventHandler.ItemAddedToInventory(targetItem);
        Debug.Log("Picked up " + targetItem + ". " + baggedItems.Count + " items in inventory.");
    }

    public void DropItem(InventoryItem itemToDrop)                    // Currently can only drop items from non-equipped inventory (must be in bag)
    {
        if (baggedItems.Remove(itemToDrop))
        {
            itemToDrop.GetComponentInParent<Transform>().position = gameObject.transform.position;
            itemToDrop.transform.SetParent(null);
            itemToDrop.GetComponent<MeshRenderer>().enabled = true;
            itemToDrop.GetComponent<Collider>().enabled = true;
            UIEventHandler.ItemRemovedFromInventory(itemToDrop);
        }
        
        Debug.Log("Dropped " + itemToDrop + ". " + baggedItems.Count + " items in inventory.");
    }

    public void EquipItem(Equippable itemToEquip)
    {
        GameObject targetSlot = gameObject.transform.Find("PlayerModel").Find(itemToEquip.Slot).gameObject;
        Debug.Log("Checking " + targetSlot + " for existing equipment...");
        if (targetSlot.transform.childCount > 0)
        {
            Equippable previouslyEquipped = equippedItems.Find(x => x.Slot == itemToEquip.Slot);
            Debug.Log("Found item in slot already.");
            UnEquipItem(previouslyEquipped);
        }
        Debug.Log("Equipping new item...");
        itemToEquip.transform.SetParent(targetSlot.transform, false);
        itemToEquip.GetComponent<MeshRenderer>().enabled = true;
        equippedItems.Add(itemToEquip);
        UIEventHandler.ItemEquipped(itemToEquip);
        characterStats.AddStatBonuses(itemToEquip.Stats);
        if (itemToEquip.gameObject.GetComponent<IWeapon>() != null)
        {
            playerWeaponController.equippedIWeapon = itemToEquip.gameObject.GetComponent<IWeapon>();
            if (itemToEquip.gameObject.GetComponent<IProjectileWeapon>() != null)
            {
                itemToEquip.gameObject.GetComponent<IProjectileWeapon>().ProjectileSpawn = playerWeaponController.projectileSpawn;
            }
        }

        Debug.Log("Equipped: " + itemToEquip);
    }

    public void UnEquipItem(Equippable itemToUnequip)
    {
        characterStats.RemoveStatBonuses(itemToUnequip.Stats);
        baggedItems.Add(itemToUnequip);
        UIEventHandler.ItemAddedToInventory(itemToUnequip);
        equippedItems.Remove(itemToUnequip);
        Debug.Log("Unequipped: " + itemToUnequip);
    }

    public void SetItemDetails(InventoryItem item, Button selectedButton)
    {
        itemDetailsPanel.SetItem(item, selectedButton);
    }

}
