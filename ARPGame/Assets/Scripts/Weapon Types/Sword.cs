using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Equippable, IWeapon {

    void Start()
    {
        // For testing, these will be set in the procedural/random generation of equipment
        BaseStat baseStat = new BaseStat("STR", 5);
        Stats.Add(baseStat);
        ItemName = name;
        Slot = "MainHand"; 
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.root != transform.root)   // Stop hitting yourself!
        {
            if (col.tag == "Enemy")
            {
                col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
            }
            Debug.Log("Hit: " + col.name);
        }
    }

    public void PerformAttack()
    {
        PlayerAnimationEventHandler.HandleAnimation("PlayerAttack");
        Debug.Log("Attacking with " + this.name + "!");
    }

    public void PerformAttack2()    // sample of another attack and how it would need to reference it's own trigger (part of the animator object)
    {
        PlayerAnimationEventHandler.HandleAnimation("PlayerAttack");
        Debug.Log("Attacking with " + this.name + "!");
    }

}
