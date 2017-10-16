using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : NPC {

    // Reference to playerObject for testing
    public GameObject player;

    void Start()
    {
        currentHealth = maxHealth;

        // Reference to playerObject is currently provided in inspector for testing
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
                    // ToDo: some kind of interaction here
                    hasInteracted = true;             // For right now these NPCs will track the player until in close proximity
                }
            }
            
        }
    }

    public void PerformAttack()
    {

    }

}
