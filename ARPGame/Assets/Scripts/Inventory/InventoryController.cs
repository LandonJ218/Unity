using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    public static InventoryController Instance { get; set; }
    public PlayerWeaponController playerWeaponController { get; set; }
    public List<InventoryItem> playerItems = new List<InventoryItem>();

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        playerWeaponController = gameObject.GetComponent<PlayerWeaponController>();

    }

    public void TakeItem(InventoryItem targetItem)
    {
        playerItems.Add(targetItem);
        Debug.Log("Picked up " + targetItem + ". " + playerItems.Count + " items in inventory.");
    }

    public void EquipItem(GameObject itemToEquip)
    {
        
    }

}
