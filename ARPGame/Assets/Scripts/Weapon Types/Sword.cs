using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : EquippableModel, IWeapon
{

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.root != transform.root)   // Stop hitting yourself!
        {
            if (col.tag == "Enemy")
            {
                if (col.transform.childCount > 0 && col.transform.GetChild(0).GetComponent<EnemyAnimationController>() != null)
                {
                    col.transform.GetChild(0).GetComponent<EnemyAnimationController>().HandleAnimation("EnemyHit");
                }
                col.GetComponent<EnemyHealth>().TakeDamage(25);
                Debug.Log("Hit: " + col.name);
                col.GetComponent<EnemyHealth>().TakeDamage(50);
            }
        }
    }

    public void PerformAttack()
    {
       
    }

    public void PerformAttack2()
    {
        
    }

}
