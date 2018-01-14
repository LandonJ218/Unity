using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour {

	public delegate void PlayerAnimationHandler();
    public static event PlayerAnimationHandler OnPlayerAttack;
    public static event PlayerAnimationHandler OnPlayerRunning;
    public static event PlayerAnimationHandler OnPlayerIdle;

    public static void PlayerAttack()
    {
        OnPlayerAttack();
    }

    public static void PlayerRunning( )
    {
        OnPlayerRunning();
    }

    public static void PlayerIdle( )
    {
        OnPlayerIdle();
    }
}
