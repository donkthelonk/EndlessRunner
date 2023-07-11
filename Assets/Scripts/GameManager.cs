using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool paused;
    [SerializeField] GameObject pauseScreen;

    // Update is called once per frame
    void Update()
    {
        // Check for user input for pause and pause as long as scene is not MainMenu (not sure if good idea or better way)
        if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetActiveScene().name != "MainMenu")
        {
            ChangePaused();
        }
    }

    // Method to flip paused state and show/hide the Pause Screen
    void ChangePaused()
    {
        // change paused state and show canvas
        if (!paused)
        {
            // Flip bool
            paused = true;

            // Display pause panel
            pauseScreen.SetActive(true);

            // Stop time
            Time.timeScale = 0;
        }
        // change paused state and hide canvas
        else
        {
            // Flip bool
            paused = false;

            // Hide pause panel
            pauseScreen.SetActive(false);

            // Start time
            Time.timeScale = 1;
        }
    }
}
