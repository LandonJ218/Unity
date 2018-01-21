using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : NPC {

    // Reference to playerObject for testing
    public GameObject player;

    float attackInterval = 2.0f;
    float nextAttackTime = 0.0f;

    void Start()
    {
        currentHealth = maxHealth;

        // Reference to playerObject can be provided in inspector for testing
        if (player != null)
        {
            currentTarget = player;
            MoveToInteraction();
        }
        
    }

    void Update()
    {
        if (nav != null && !(nav.pathPending))
        {
            if (!hasInteracted)
            {
                targetLastPosition = currentTarget.transform.position;
                if (nav.destination != targetLastPosition)
                {
                    MoveToInteraction();
                }
                // Key to this check is that stoppingDistance is set to 0 when current destination in not interactable; hence those "clicks" won't call Interact()
                if (nav.remainingDistance <= nav.stoppingDistance)
                {
                    if(Time.time > nextAttackTime)
                    {
                        PerformAttack();
                        nextAttackTime = Time.time + attackInterval;
                        //hasInteracted = true; 
                    }
                }
                else
                {
                    nextAttackTime = Time.time + attackInterval;
                }
            }
            
        }
    }

    public void PerformAttack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(5);
    }

}
