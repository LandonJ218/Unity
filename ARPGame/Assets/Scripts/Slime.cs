using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{

    // Reference to playerObject for testing
    public GameObject player;

    protected EnemyAnimationController enemyAnimationController;

    float attackInterval = 0.5f;
    float nextAttackTime = 0.0f;

    void Start()
    {
        enemyAnimationController = transform.GetChild(0).GetComponent<EnemyAnimationController>();
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
            if (!(Vector3.Distance(nav.destination, nav.transform.position) <= nav.stoppingDistance))
            {
                enemyAnimationController.HandleAnimation("EnemyForward");
            }
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
                    if (Time.time > nextAttackTime)
                    {
                        PerformAttack();
                        nextAttackTime = Time.time + attackInterval;
                        //hasInteracted = true; 
                    }
                    if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
                    {
                        enemyAnimationController.HandleAnimation("EnemyIdle");
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
        enemyAnimationController.HandleAnimation("EnemyAttack");
        player.GetComponent<PlayerHealth>().ChangeHealth(-5);
    }

}
