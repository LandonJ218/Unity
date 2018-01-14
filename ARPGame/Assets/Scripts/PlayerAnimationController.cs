using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerAnimationController : BaseAnimationController {
	public TextAsset playerAnimationFile;

	private List<AnimationTransistion> playerAnimations = new List<AnimationTransistion>();
	void Start () {
		anim = GetComponent<Animator>();
		playerAnimations = new List<AnimationTransistion>();

		LoadAnimationTransitions();
		PlayerAnimationEventHandler.OnHandleAnimation += HandleAnimation;
	}

	void LoadAnimationTransitions()
	{
		if(playerAnimationFile != null)
		{
 			playerAnimations = JsonUtility.FromJson<AnimationTransistionWrapper>(playerAnimationFile.text).AnimationTransistions;
		}
	}

	public void HandleAnimation(string animationName)
	{
		var  animatorTransistions = playerAnimations.Find(a => a.AnimationName.Equals(animationName));
		HandleAnimatorTransistions(animatorTransistions.AnimationTransistionArgs);
	}
}
