using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    private GameObject currentlyEquipped;
    public GameObject rightHand;
    Transform projectileSpawn;
    IWeapon equippedIWeapon;

    CharacterStats characterStats;

    void Start()
    {
        projectileSpawn = transform.Find("ProjectileSpawn");
        characterStats = gameObject.GetComponent<CharacterStats>();
    }

    public void EquipWeapon(GameObject itemToEquip)
    {
        Debug.Log("In EquipWeapon() ");
        if (rightHand.transform.childCount > 0)
        {
            Debug.Log("Found weapon in hand already.");
            characterStats.RemoveStatBonuses(currentlyEquipped.GetComponent<IWeapon>().Stats);
            Destroy(currentlyEquipped);   // will just be dropped or removed from slot in future
            Debug.Log("Weapon removed from hand.");
        }
        currentlyEquipped = itemToEquip;
        Debug.Log("Equipping new weapon...");
        currentlyEquipped.transform.SetParent(rightHand.transform, false);
        Debug.Log("New weapon \"In hand\".");
        if (currentlyEquipped.GetComponent<IProjectileWeapon>() != null)
        {
            currentlyEquipped.GetComponent<IProjectileWeapon>().ProjectileSpawn = projectileSpawn;
        }
        equippedIWeapon = currentlyEquipped.GetComponent<IWeapon>();
        //characterStats.AddStatBonuses(equippedIWeapon.Stats);
        Debug.Log("Equipped: " + itemToEquip);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PerformWeaponAttack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformWeaponAttack2();
        }
    }

    public void PerformWeaponAttack()
    {
        if (equippedIWeapon != null)
        {
            equippedIWeapon.PerformAttack();
        }
    }

    public void PerformWeaponAttack2()
    {
        if (equippedIWeapon != null)
        {
            equippedIWeapon.PerformAttack2();
        }
    }
}
