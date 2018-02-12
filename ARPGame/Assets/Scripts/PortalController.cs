using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour {

    GameController gameController;

	void Awake () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}

    private void Start()
    {
        EnemySpawner enemySpawner = Resources.Load<EnemySpawner>("SpawnerPortal");
        for(int i = 0; i <= gameController.gameDifficulty; i++)
        {
            EnemySpawner newPortal = Instantiate(enemySpawner);
            newPortal.transform.SetParent(gameObject.transform, false);
            newPortal.transform.Translate(Random.Range(-100, 100), 0, Random.Range(-100, 100));
        }
        
    }

}
