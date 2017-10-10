using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Interactable, IEnemy {

    public float currentHealth, power, toughness;
    public float maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }	
	// Update is called once per frame
	void Update () {
		
	}

    public void PerformAttack()
    {

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
