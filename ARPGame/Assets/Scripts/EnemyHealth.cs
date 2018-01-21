using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public Slider healthBar;

    int maxHealth = 100;
    int currentHealth;

    private void Start()
    {
        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBar.value = currentHealth;
        // TODO: need something here maybe to help healthbar track associated enemy
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetMaxHealth(int healthBonus)
    {
        maxHealth += healthBonus;
        currentHealth += healthBonus;
        healthBar.maxValue = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " is dead!");
    }
}
