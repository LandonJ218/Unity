using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerAnimationController : BaseAnimationController {

    GameObject mainHand;

	void Start () {
		this.anim = GetComponent<Animator>();
		this.animationTransistions = new List<AnimationTransistion>();
		LoadAnimationTransitions();

        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.CompareTag("SlotMainHand"))
            {
                mainHand = child.gameObject;
            }
        }
    }

	public void EnableWeapon()
    {
		Transform[] children = mainHand.GetComponentsInChildren<Transform>();
		foreach(Transform child in children) {
			if(child.CompareTag("Weapon")) {
				child.GetComponent<MeshCollider>().enabled = true;
			}
		}
    }

    public void DisableWeapon()
    {
        Transform[] children = mainHand.GetComponentsInChildren<Transform>();
		foreach(Transform child in children) {
			if(child.CompareTag("Weapon")) {
				child.GetComponent<MeshCollider>().enabled = false;
			}
		}
    }

	public void FireProjectile()
	{
        //Ideally this is where the projectile will instantiate.
        Transform[] children = mainHand.GetComponentsInChildren<Transform>();
        
        foreach (Transform child in children)
        {
            if (child.GetComponent<IProjectileWeapon>() != null)
            {
                child.GetComponent<IProjectileWeapon>().FireProjectile();
            }
        }
    }
}
