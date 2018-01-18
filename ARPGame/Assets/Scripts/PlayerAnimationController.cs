using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerAnimationController : BaseAnimationController {

	void Start () {
		anim = GetComponent<Animator>();
		animationTransistions = new List<AnimationTransistion>();

		LoadAnimationTransitions();
		PlayerAnimationEventHandler.OnHandleAnimation += HandleAnimation;
		PlayerAnimationEventHandler.OnHandleAnimationArgs += HandleAnimation;
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
}
