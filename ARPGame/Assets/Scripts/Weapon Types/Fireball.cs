using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public float Speed { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPosition;

    void Start()
    {
        Range = 20f;
        Damage = 5;
        Speed = 250f;
        spawnPosition = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction * Speed);
    }

    void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Extinguish();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.root != transform.root)   // Stop hitting yourself!
        {
            if (col.tag == "Enemy")
            {
                col.GetComponent<EnemyHealth>().TakeDamage(25);
                Debug.Log("Hit: " + col.name);
            }
            Extinguish();
        }
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }

}
