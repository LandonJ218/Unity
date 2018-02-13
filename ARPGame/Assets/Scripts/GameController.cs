using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int gameDifficulty;

    private int portalCount;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}

    //handles button onClick() and loads scene based on its selected index number found in build settings
    public void StartGame(int difficulty)
    {
        gameDifficulty = difficulty;
        SceneManager.LoadScene(1);
        UIEventHandler.OnPortalsSpawned += PortalsSpawned;
        UIEventHandler.OnPortalDestroyed += PortalDestroyed;
    }

    private void PortalsSpawned()
    {
        portalCount = GameObject.Find("Portals").transform.childCount;
        //UIPortalCount.text = portalCount.ToString();
    }
    
    private void PortalDestroyed()
    {
        portalCount--;
        if(portalCount < 1)
        {
            // Player Wins   still need an in game window to pop up
        }
    }
}
