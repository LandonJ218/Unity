using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationTransistion{
	public string AnimationName;
	public List<AnimationTransistionArg> AnimationTransistionArgs;
	public AnimationTransistion()
	{
		AnimationTransistionArgs = new List<AnimationTransistionArg>();
	}
}
