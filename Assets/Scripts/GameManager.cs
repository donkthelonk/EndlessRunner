using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool paused;
    [SerializeField] GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
