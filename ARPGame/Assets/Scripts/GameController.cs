using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static int gameDifficulty;
    public static bool gameWon;

    private static int portalCount = 0;
    private static int enemyCount = 0;


    // Use this for initialization
    void Awake ()
    {
        DontDestroyOnLoad(gameObject);
	}

    //handles button onClick() and loads scene based on its selected index number found in build settings
    public static void StartGame(int difficulty)
    {
        gameDifficulty = difficulty;
        SceneManager.LoadScene(1);
    }

    public static void PortalSpawned()
    {
        portalCount++;
        UIEventHandler.PortalSpawned();
    }

    public static void EnemySpawned()
    {
        enemyCount++;
    }

    public static void PlayerDied()
    {
        EndGame(false);
    }

    public static void PortalDestroyed()
    {
        portalCount--;
        if(portalCount < 1)
        {
            if(enemyCount > 0)
            {
                UIEventHandler.AllPortalsDestroyed();
            }
            else
            {
                EndGame(true);
            }
        }
        else
        {
            UIEventHandler.PortalDestroyed();
        }
    }

    public static void EnemyKilled()
    {
        enemyCount--;
        if (portalCount < 1)
        {
            if (enemyCount < 1)
            {
                EndGame(true);
            }
            else
            {
                UIEventHandler.EnemyKilled();
            }
        }
    }

    public static void EndGame(bool gameWon)
    {
        GameController.gameWon = gameWon;
        SceneManager.LoadScene(2);
    }

    public static int GetPortalCount()
    {
        return portalCount;
    }

    public static int GetEnemyCount()
    {
        return enemyCount;
    }
}
