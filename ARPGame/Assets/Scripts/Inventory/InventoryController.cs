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
        Debug.Log("PlayerWeaponController set to " + playerWeaponController);
    }

    public void Update()
    {
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
        PrepItemForBag(targetItem);
        baggedItems.Add(targetItem);
        UIEventHandler.ItemAddedToInventory(targetItem);
        Debug.Log(targetItem + " is now in inventory. " + baggedItems.Count + " items in inventory.");
    }

    public void DropItem(InventoryItem itemToDrop)                    // Currently can only drop items from non-equipped inventory (must be in bag)
    {
        if (baggedItems.Remove(itemToDrop))                           // needs to be updated to handle new equippable item structure (equippable / equippableModel)
        {
            if (itemToDrop.GetComponent("Halo") != null)
            {
                Behaviour halo = (Behaviour)itemToDrop.GetComponent("Halo");
                halo.enabled = true;
            }
            if (itemToDrop.GetComponent<Equippable>() != null)
            {
                foreach (EquippableModel x in itemToDrop.GetComponent<Equippable>().Models)
                {
                    x.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {
                itemToDrop.GetComponent<MeshRenderer>().enabled = true;
            }
            UIEventHandler.ItemRemovedFromInventory(itemToDrop);
            itemToDrop.transform.SetParent(null, true);
            itemToDrop.GetComponent<Collider>().enabled = true;
        }
        
        Debug.Log("Dropped " + itemToDrop + ". " + baggedItems.Count + " items in inventory.");
    }

    public void EquipItem(Equippable itemToEquip)
    {
        Debug.Log("Checking " + itemToEquip.Slot + " for existing equipment...");

        if (equippedItems.Exists(x => x.Slot == itemToEquip.Slot))
        {
            Equippable previouslyEquipped = equippedItems.Find(x => x.Slot == itemToEquip.Slot);
            UnEquipItem(previouslyEquipped);
        }

        Debug.Log("Equipping " + itemToEquip.name + "... ");
        if (baggedItems.Remove(itemToEquip))            //is the item coming from the player's own inventory?
        {
            UIEventHandler.ItemRemovedFromInventory(itemToEquip);
        }

        foreach (EquippableModel x in itemToEquip.Models)
        {
            GameObject modelAnchor = FindEquipmentSlot(transform.root.Find("PlayerModel").gameObject, (itemToEquip.Slot + x.Side));
            x.transform.SetParent(modelAnchor.transform, false);
            x.OrientForSlot();
            x.GetComponent<MeshRenderer>().enabled = true;

            // Check if model is projectile weapon
            if (x.gameObject.GetComponent<IWeapon>() != null)
            {
                playerWeaponController.equippedIWeapon = x.gameObject.GetComponent<IWeapon>();
                if (x.gameObject.GetComponent<IProjectileWeapon>() != null)
                {
                    Debug.Log(x.gameObject + " is a projectile weapon.");
                    x.gameObject.GetComponent<IProjectileWeapon>().ProjectileSpawn = playerWeaponController.projectileSpawn;
                    Debug.Log(x + "'s ProjectileSpawn is set to " + playerWeaponController.projectileSpawn + ".");
                }
            }
        }

        equippedItems.Add(itemToEquip);
        UIEventHandler.ItemEquipped(itemToEquip);
        characterStats.AddStatBonuses(itemToEquip.Stats);

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

    public void PrepItemForBag(InventoryItem itemToPrep)                    
    {
        if(itemToPrep.GetComponent("Halo") != null)
        {
            Behaviour halo = (Behaviour)itemToPrep.GetComponent("Halo");
            halo.enabled = false;
        }
        itemToPrep.gameObject.transform.SetParent(gameObject.transform, false);
        itemToPrep.gameObject.transform.localPosition = Vector3.zero;
        if (itemToPrep.GetComponent<Equippable>() != null)
        {
            Debug.Log(itemToPrep.name + " is equippable...");
            foreach(EquippableModel x in itemToPrep.GetComponent<Equippable>().Models)
            {
                x.transform.SetParent(itemToPrep.transform, false);
                x.OrientForBag();
                x.GetComponent<MeshRenderer>().enabled = false;
                Debug.Log(x.name + " should now be invisible...");
            }
        }
        else
        {
            itemToPrep.GetComponent<MeshRenderer>().enabled = false; 
        }
        itemToPrep.GetComponent<Collider>().enabled = false;
    }

    public GameObject FindEquipmentSlot(GameObject currentObject, string targetSlot)     
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
