using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    [HideInInspector]
    public NavMeshAgent interactingAgent;
    private bool hasInteracted;
    bool isEnemy;

    void Update()
    {
        if (interactingAgent != null && !(interactingAgent.pathPending))
        {
            // Key to this check is that stoppingDistance is set to 0 when current destination in not interactable; hence those "clicks" won't call Interact()
            if (!hasInteracted && interactingAgent.remainingDistance <= interactingAgent.stoppingDistance) 
            {
                if (!isEnemy)    // NPC's and interactable items mostly
                {
                    Interact();
                }
                EnsureLookDirection();
                hasInteracted = true;
            }
        }
    }

    public virtual void MoveToInteraction(NavMeshAgent interactingAgent)
    {
        isEnemy = gameObject.GetComponent<IEnemy>() != null;
        hasInteracted = false;
        this.interactingAgent = interactingAgent;
        interactingAgent.stoppingDistance = 10f;
        interactingAgent.destination = this.transform.position;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base Interactable class.");
    }

    void EnsureLookDirection()
    {
        interactingAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, interactingAgent.transform.position.y, transform.position.z);
        interactingAgent.transform.LookAt(lookDirection);
        interactingAgent.updateRotation = true;
    }
}
