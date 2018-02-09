using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int gameDifficulty;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}

    //handles button onClick() and loads scene based on its selected index number found in build settings
    public void StartGame(int difficulty)
    {
        gameDifficulty = difficulty;
        SceneManager.LoadScene(1);
    }

}
