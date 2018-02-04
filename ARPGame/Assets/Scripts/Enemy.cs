using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public NavMeshAgent nav;
    public GameObject currentTarget = null;
    public Vector3 targetLastPosition;
    public bool hasInteracted = true;

    public string enemyName;

    void Start()
    {

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

}
