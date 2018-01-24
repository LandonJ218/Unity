using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : BaseAnimationController {

	// Use this for initialization
	void Start () {
		this.anim = GetComponent<Animator>();
		this.animationTransistions = new List<AnimationTransistion>();
		LoadAnimationTransitions();
	}
	
}
