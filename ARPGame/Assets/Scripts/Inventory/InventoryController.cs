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
        targetItem.gameObject.transform.SetParent(gameObject.transform, false);
        Debug.Log("Collider enabled: " + targetItem.GetComponent<Collider>().enabled);
        targetItem.GetComponent<Collider>().enabled = false;
        Debug.Log("Collider enabled: " + targetItem.GetComponent<Collider>().enabled);
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
        GameObject targetSlot;
        Debug.Log("Checking " + itemToEquip.Slot + " for existing equipment...");
        
        if (equippedItems.Exists(x => x.Slot == itemToEquip.Slot))      
        {
            Equippable previouslyEquipped = equippedItems.Find(x => x.Slot == itemToEquip.Slot);
            targetSlot = previouslyEquipped.transform.parent.gameObject;
            Debug.Log("Removing " + previouslyEquipped.name + " from " + targetSlot.name + "... ");
            UnEquipItem(previouslyEquipped);
        }
        else
        {
            targetSlot = FindEquipmentSlot(transform.root.Find("PlayerModel").gameObject, itemToEquip.Slot); // May change the initial object to send in later
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

    public GameObject FindEquipmentSlot(GameObject currentObject, string targetSlot)      // NOT TESTED
    {
        GameObject targetObject = null;
        int childCount = currentObject.transform.childCount;

        if (currentObject.tag.Equals("Slot" + targetSlot))
        {
            targetObject = currentObject;
        }
        else
        {
            for (int i = 0; i < childCount; i++)
            {
                targetObject = FindEquipmentSlot(currentObject.transform.GetChild(i).gameObject, targetSlot);
                if(targetObject != null)
                {
                    break;
                }
            }
        }

        return targetObject;
    }
    
    public bool SlotEmpty(string slot)
    {
        bool itemFound = equippedItems.Exists(x => x.Slot == slot);

        return itemFound;
    }
}
