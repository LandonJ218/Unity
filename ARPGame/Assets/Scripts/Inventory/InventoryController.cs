using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    public static InventoryController Instance { get; set; }
    public PlayerWeaponController playerWeaponController { get; set; }
    public PlayerArmorController playerArmorController { get; set; }
    public List<Item> playerItems = new List<Item>();

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
        playerArmorController = gameObject.GetComponent<PlayerArmorController>();

    }

    public void TakeItem(string itemSlug)
    {
        playerItems.Add(ItemDatabase.Instance.GetItem(itemSlug));
        Debug.Log("Picked up " + itemSlug + ". " + playerItems.Count + " items in inventory.");
    }

    public void EquipItem(GameObject itemToEquip)
    {
        if(itemToEquip.GetComponent<IArmor>() != null)
        {
            playerArmorController.EquipArmor(itemToEquip);
        }
        else if(itemToEquip.GetComponent<IWeapon>() != null)
        {
            playerWeaponController.EquipWeapon(itemToEquip);
        }
    }

}
