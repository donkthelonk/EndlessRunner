using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject tutorialMenu;

    // Method for the Start Button
    public void StartGame()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

    // Hides Tutorial Menu and displays the Start Menu
    public void BackButton()
    {
        // Disable Tutorial Menu
        tutorialMenu.SetActive(false);

        // Enable Start Menu
        startMenu.SetActive(true);
    }

    // Hides the Start Menu and displays the Tutorial Menu 
    public void HowToPlayButton()
    {
        // Enable Tutorial Menu
        tutorialMenu.SetActive(true);

        // Disable Start Menu
        startMenu.SetActive(false);
    }

    // Exit Application
    public void ExitButton()
    {
        Application.Quit();
    }
}
