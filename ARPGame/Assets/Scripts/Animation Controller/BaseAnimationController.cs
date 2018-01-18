using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimationController : MonoBehaviour {
	protected Animator anim;

	public void HandleAnimatorTransistions(ICollection<AnimationTransistionArg> args)
	{
		foreach (var arg in args)
		{
			switch (arg.ArgumentType)
			{
				case "Integer":
					anim.SetInteger(arg.ArgumentName, int.Parse(arg.ArgumentValue));
					break;
				case "Float":
					anim.SetFloat(arg.ArgumentName, float.Parse(arg.ArgumentValue));
					break;
				case "Bool":
					anim.SetBool(arg.ArgumentName, bool.Parse(arg.ArgumentValue));
					break;
				case "Trigger":
					anim.SetTrigger(arg.ArgumentName);
					break;
				default:
					Debug.LogError("Missing transition arguments");
					break;
			}
		}
	}
}
