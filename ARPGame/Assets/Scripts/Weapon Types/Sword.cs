using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Equippable {

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
                col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue()); // just trying to use the STR stat on this item as weapon damage
            }
            Debug.Log("Hit: " + col.name);
        }
    }

    //public void PerformAttack()
    //{
    //    animator.SetTrigger("Base_Attack");
    //    Debug.Log("Attacking with " + this.name + "!");
    //}

    //public void PerformAttack2()    // sample of another attack and how it would need to reference it's own trigger (part of the animator object)
    //{
    //    animator.SetTrigger("Base_Attack2");
    //    Debug.Log("Attacking with " + this.name + "!");
    //}


}
