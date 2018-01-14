using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour {

	public delegate void PlayerAnimationHandler(string animationName);
    public static event PlayerAnimationHandler OnHandleAnimation;
    public static void HandleAnimation(string animationName)
    {
        OnHandleAnimation(animationName);
    }
}
