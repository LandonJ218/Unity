using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    public Transform projectileSpawn;
    public IWeapon equippedIWeapon;

    void Start()
    {
        projectileSpawn = transform.Find("ProjectileSpawn");
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
        Debug.Log("WOOP");
        PlayerAnimationEventHandler.PlayerAttack();
         //equippedIWeapon.PerformAttack();
    }

    public void PerformWeaponAttack2()
    {
        PlayerAnimationEventHandler.PlayerAttack();
    }
}
