using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");    // Loads Scene Called StartMenu
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main"); // Loads game scene
    }

    public void Facts()
    {
        SceneManager.LoadScene("SpacePics"); // Loads fact of the day scene
    }

    public void QuitGame()
    {
        Application.Quit(); // Closes game
    }
}
