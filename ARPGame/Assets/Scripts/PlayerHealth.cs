using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerHealth : MonoBehaviour 
{
    
    private Slider healthBar;
    private int maxHealth = 100;
    private int currentHealth;

    //Instance variable
    private static PlayerHealth instance = null;
    public static PlayerHealth Instance()
    {
        if (instance == null)
            instance = new PlayerHealth();
        return instance;
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        CurrentHealth = maxHealth;
        Update();
    }

    private void Update()
    {
        healthBar.value = CurrentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetMaxHealth(int healthBonus)
    {
        maxHealth += healthBonus;
        CurrentHealth += healthBonus;
        healthBar.maxValue = maxHealth;
    }
    
    public void ChangeHealth(int delta)
    {
        CurrentHealth += delta;
        
        if(CurrentHealth < 1)
            Die();

        Update();
    }

    private void Die()
    {
        gameObject.GetComponent<PlayerController>().enabled = false;
        GameController.PlayerDied();
    }

}