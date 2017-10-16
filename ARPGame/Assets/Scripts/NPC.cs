using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {

    public NavMeshAgent nav;
    public GameObject currentTarget = null;
    public Vector3 targetLastPosition;
    public bool hasInteracted = true;

    public string npcName;
    public string[] dialogue;
    public float currentHealth;
    public float maxHealth;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

    }

    public void MoveToInteraction()
    {
        EnsureLookDirection();
        hasInteracted = false;
        nav.stoppingDistance = 7f;
        nav.destination = targetLastPosition;
    }

    void EnsureLookDirection()
    {
        nav.updateRotation = false;
        nav.transform.LookAt(currentTarget.transform.position);
        nav.updateRotation = true;
    }

    public  void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);   // if an NPC object has not had dialogue set up, this will cause an error. (passing empty array)
        Debug.Log("Interacting with NPC.");
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
