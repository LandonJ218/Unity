using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmorController : MonoBehaviour {

    private GameObject armorSlot;
    private GameObject currentlyEquipped;

    CharacterStats characterStats;

    void Start()
    {
        characterStats = gameObject.GetComponent<CharacterStats>();
    }

    public void EquipArmor(GameObject itemToEquip)
    {
        armorSlot = gameObject.transform.Find("PlayerModel").transform.Find(itemToEquip.GetComponent<IArmor>().ArmorSlot).gameObject;
        currentlyEquipped = armorSlot.transform.Find(itemToEquip.GetComponent<IArmor>().ArmorSlot).gameObject;
        if (currentlyEquipped != null)
        {
            characterStats.RemoveStatBonuses(currentlyEquipped.GetComponent<IArmor>().Stats);
            Destroy(currentlyEquipped);  // will just be dropped or removed from slot in future
        }

        itemToEquip.transform.SetParent(armorSlot.transform, false);
        characterStats.AddStatBonuses(itemToEquip.GetComponent<IArmor>().Stats);
        Debug.Log("Equipped: " + itemToEquip);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
        }
    }

}
