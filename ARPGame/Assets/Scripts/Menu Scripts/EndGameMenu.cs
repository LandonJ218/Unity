using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    //quit game on click, has a check for if the game is running within editor

    TextMeshProUGUI text;

    private void Start()
    {
        if(GameObject.Find("EndGameText").GetComponent<TextMeshProUGUI>() != null)
        {
            text = GameObject.Find("EndGameText").GetComponent<TextMeshProUGUI>();
        }
        
        if (GameController.gameWon)
        {
            text.text = "You Won!";
        }
        else
        {
            text.text = "You Died.";
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}