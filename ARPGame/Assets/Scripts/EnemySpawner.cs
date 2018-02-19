using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : Enemy {

    Slime slime { get; set; }
    Slider healthBar { get; set; }
    GameObject enemyContainer { get; set; }

    float spawnInterval = 5.0f;
    float nextSpawnTime = 0.0f;

    void Start () {
        slime = Resources.Load<Slime>("NPC/Enemies/Slime3");
        healthBar = Resources.Load<Slider>("UI/EnemyHealthBar");
        enemyContainer = GameObject.Find("Enemies");

        Slider newHealthBar = Instantiate(healthBar);
        newHealthBar.transform.SetParent(enemyContainer.transform.Find("Canvas"), false);
        newHealthBar.transform.Translate(0, 4, 2);
        Vector3 upScale = new Vector3(0.2f, 0.2f, 0.2f);
        newHealthBar.transform.localScale = upScale;
        transform.GetComponent<EnemyHealth>().healthBar = newHealthBar;
        transform.GetComponent<EnemyHealth>().SetMaxHealth(400);
    }
	
	void Update () {
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    public void SpawnEnemy()
    {       
        Slime newSlime = Instantiate(slime);
        newSlime.transform.position = transform.position;
        newSlime.transform.SetParent(enemyContainer.transform, true);
        GameController.EnemySpawned();
        Slider newHealthBar = Instantiate(healthBar);
        newHealthBar.transform.SetParent(enemyContainer.transform.Find("Canvas"), false);
        newSlime.GetComponent<EnemyHealth>().healthBar = newHealthBar;
        newSlime.player = GameObject.Find("Player");
    }
}
