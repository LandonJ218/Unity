using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    protected PlayerAnimationController playerAnimationController;
    public Transform projectileSpawn;
    public IWeapon equippedIWeapon;

    void Start()
    {
        playerAnimationController = transform.GetChild(0).GetComponent<PlayerAnimationController>();
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

    private void PerformWeaponAttack()
    {
        if(playerAnimationController != null)
        {
            playerAnimationController.HandleAnimation("PlayerAttack");
        }
    }

    private void PerformWeaponAttack2()
    {
        if(playerAnimationController != null)
        {
            playerAnimationController.HandleAnimation("PlayerAttack");
        }
    }
}
