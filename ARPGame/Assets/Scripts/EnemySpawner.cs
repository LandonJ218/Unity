using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    Slime slime { get; set; }
    Slider healtBar { get; set; }
    GameObject enemyContainer { get; set; }
    int enemyCount = 0;
    public Text enemyCountText;

    float spawnInterval = 2.0f;
    float nextSpawnTime = 0.0f;

    void Start () {
        slime = Resources.Load<Slime>("NPC/Enemies/Slime3");
        healtBar = Resources.Load<Slider>("UI/EnemyHealthBar");
        enemyContainer = GameObject.Find("Enemies");
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
        newSlime.transform.SetParent(enemyContainer.transform, false);
        newSlime.transform.position = transform.position;
        Slider newHealthBar = Instantiate(healtBar);
        newHealthBar.transform.SetParent(enemyContainer.transform.Find("Canvas"), false);
        newSlime.GetComponent<EnemyHealth>().healthBar = newHealthBar;
        newSlime.player = GameObject.Find("Player");
        enemyCountText.text = (enemyCount++).ToString();
    }
}
