using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl: MonoBehaviour {

    public GameController gameController;

    public void StartGameEasy()
    {
        gameController.StartGame(0);
    }

    public void StartGameHard()
    {
        gameController.StartGame(1);
    }

    //quit game on click, has a check for if the game is running within editor
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}