using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void StartGame() 
    {
        //Start game.
        SceneManager.LoadScene(0);
    }
    public void ExitGame() 
    {
        // Quit game.
        Application.Quit();
    }
    public void OptionsGame() 
    {
        //j
    }
}
