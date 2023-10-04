using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Missing code for calling menu after player death
public class DeathMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menus");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
