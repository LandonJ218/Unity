using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public List<InventoryItem> baggedItems = new List<InventoryItem>();
    public List<Equippable> equippedItems = new List<Equippable>();

    CharacterStats characterStats;
    PlayerWeaponController playerWeaponController { get; set; }

    void Start()
    {
        characterStats = transform.parent.gameObject.GetComponent<CharacterStats>();
        playerWeaponController = transform.parent.gameObject.GetComponent<PlayerWeaponController>();

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
        targetItem.gameObject.transform.SetParent(gameObject.transform, false);
        UIEventHandler.ItemAddedToInventory(targetItem);
        Debug.Log(targetItem + " is now in inventory. " + baggedItems.Count + " items in inventory.");
    }

    public void DropItem(InventoryItem itemToDrop)                    // Currently can only drop items from non-equipped inventory (must be in bag)
    {
        if (baggedItems.Remove(itemToDrop))
        {
            UIEventHandler.ItemRemovedFromInventory(itemToDrop);
            itemToDrop.transform.SetParent(null, true);
            itemToDrop.GetComponent<MeshRenderer>().enabled = true;
            itemToDrop.GetComponent<Collider>().enabled = true;
        }
        
        Debug.Log("Dropped " + itemToDrop + ". " + baggedItems.Count + " items in inventory.");
    }

    public void EquipItem(Equippable itemToEquip)
    {
        GameObject targetSlot = transform.root.Find("PlayerModel").Find(itemToEquip.Slot).gameObject;
        Debug.Log("Checking " + targetSlot + " for existing equipment...");
        if (targetSlot.transform.childCount > 0)
        {
            Equippable previouslyEquipped = equippedItems.Find(x => x.Slot == itemToEquip.Slot);
            Debug.Log("Removing " + previouslyEquipped.name + " from " + targetSlot.name + "... ");
            UnEquipItem(previouslyEquipped);
        }
        Debug.Log("Equipping " + itemToEquip.name + "... ");
        if(baggedItems.Remove(itemToEquip)) //is the item coming from the player's own inventory?
        {
            UIEventHandler.ItemRemovedFromInventory(itemToEquip);
        }
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
        UIEventHandler.ItemUnequipped(itemToUnequip);
        characterStats.RemoveStatBonuses(itemToUnequip.Stats);
        equippedItems.Remove(itemToUnequip);
        Debug.Log("Unequipped: " + itemToUnequip);
        TakeItem(itemToUnequip);              // unequipped items automatically go to the inventory for now
    }

}
