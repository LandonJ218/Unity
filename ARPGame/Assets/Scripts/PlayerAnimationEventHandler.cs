using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour {

	public delegate void PlayerAnimationHandler(string animationName);

    public delegate void PlayerAnimationArgsHandler(ICollection<AnimationTransistionArg> animationsArgs);
    public static event PlayerAnimationHandler OnHandleAnimation;

    public static event PlayerAnimationArgsHandler OnHandleAnimationArgs;

    public static void HandleAnimation(string animationName)
    {
        OnHandleAnimation(animationName);
    }

    public static void HandleAnimation(ICollection<AnimationTransistionArg> animationArgs)
    {
        OnHandleAnimationArgs(animationArgs);
    }
}
