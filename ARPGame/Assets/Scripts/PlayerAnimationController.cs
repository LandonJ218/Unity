using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

	Animator anim;
	void Start () {
		anim = GetComponent<Animator>();
		PlayerAnimationEventHandler.OnPlayerAttack += PlayerAttack;
		PlayerAnimationEventHandler.OnPlayerRunning += PlayerRunning;
		PlayerAnimationEventHandler.OnPlayerIdle += PlayerIdle;
	}
	public void PlayerAttack()
	{
		anim.SetTrigger("Attack");
		anim.SetBool("IsRunning", false);
	}
	public void PlayerRunning()
	{
		anim.SetBool("IsRunning", true);
	}
	public void PlayerIdle()
	{
		anim.SetBool("IsRunning", false);
	}

}
