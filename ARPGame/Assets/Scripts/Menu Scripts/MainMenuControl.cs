using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl: MonoBehaviour {

    private bool controllerActive = false;

    private void Start()
    {
        if(GameObject.Find("GameController") != null)
        {
            Destroy(GameObject.Find("GameController"));
        }
        Destroy(GameObject.Find("GameController"));
        if (GameObject.Find("GameController(Clone)") == null && !controllerActive)
        {
            Instantiate(Resources.Load<GameController>("GameController"));
            controllerActive = true;
        }
    }

    public void StartGameEasy()
    {
        GameObject.Find("GameController(Clone)").name = "GameController";
        GameController.StartGame(0);
    }

    public void StartGameHard()
    {
        GameObject.Find("GameController(Clone)").name = "GameController";
        GameController.StartGame(1);
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