using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerAnimationController : BaseAnimationController {
	
	void Start () {
		this.anim = GetComponent<Animator>();
		this.animationTransistions = new List<AnimationTransistion>();
		LoadAnimationTransitions();
	}

	public void EnableWeapon()
    {
		Transform[] children = GetComponentsInChildren<Transform>();
		foreach(Transform child in children) {
			if(child.CompareTag("Weapon")) {
				child.GetComponent<MeshCollider>().enabled = true;
			}
		}
    }

    public void DisableWeapon()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
		foreach(Transform child in children) {
			if(child.CompareTag("Weapon")) {
				child.GetComponent<MeshCollider>().enabled = false;
			}
		}
    }

	public void FireProjectile()
	{
		//Ideally this is where the projectile will instantiate.
	}
}
