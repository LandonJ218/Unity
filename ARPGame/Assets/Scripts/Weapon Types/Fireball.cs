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
        Damage = 50;
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

                col.transform.GetChild(0).GetComponent<EnemyAnimationController>().HandleAnimation("EnemyHit");
                Debug.Log("Hit: " + col.name);
                col.GetComponent<EnemyHealth>().TakeDamage(Damage);
            }
            Extinguish();
        }
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }

}
