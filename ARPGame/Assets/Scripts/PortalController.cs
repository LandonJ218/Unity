using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour {

    GameController gameController;

    private float portalSpawnTimer;


    void Awake () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}

    private void Start()
    {
        portalSpawnTimer = Time.time + 5.0f;
    }

    private void Update()
    {
        if (Time.time > portalSpawnTimer)
        {
            EnemySpawner enemySpawner = Resources.Load<EnemySpawner>("SpawnerPortal");
            for (int i = 0; i <= GameController.gameDifficulty; i++)
            {
                EnemySpawner newPortal = Instantiate(enemySpawner);
                newPortal.transform.SetParent(gameObject.transform, false);
                newPortal.transform.Translate(Random.Range(-100, 100), 0, Random.Range(-100, 100));
                GameController.PortalSpawned();
            }
            gameObject.GetComponent<PortalController>().enabled = false;
        }
    }

}
