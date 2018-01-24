using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl: MonoBehaviour {

    //just some arbitrary variable that could be passed to the next scene for choosing a weapon
    //int would probably work better than string array
    private string[] weaponOptions = new string[] {"sword", "staff" };
   
    //handles button onClick() and loads scene based on its selected index number found in build settings
    public void StartGameSword(int sceneIndex)
    {
        //Set through inspector of button
        //0 == MainMenu
        //1 == Area01
        SceneManager.LoadScene(sceneIndex);
    }

    public void StartGameStaff(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
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