using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordModel : EquippableModel {


    void OnTriggerEnter(Collider col)
    {
        if (col.transform.root != transform.root)   // Stop hitting yourself!
        {
            if (col.tag == "Enemy")
            {
                // just trying to use the STR stat on this item as weapon damage;  Work needs to be done on the stat system to store current values instead of recalculating them
                col.GetComponent<IEnemy>().TakeDamage(transform.root.GetComponent<CharacterStats>().stats.Find(x => x.StatName == "STR").GetCalculatedStatValue());
            }
            Debug.Log("Hit: " + col.name);
        }
    }

}
