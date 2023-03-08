using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text distanceTraveled;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            ShowGameOverScreen();
        }
    }

    void ShowGameOverScreen()
    {
        // sets the game over screen to active
        gameOverScreen.SetActive(true);

        // remove decimal places from player.distanceTraveled
        float roundedDistance = Mathf.Ceil(player.distanceTraveled);

        // display roundedDistance in text field
        distanceTraveled.text = roundedDistance.ToString();
    }

    public void GameRestart()
    {
        Debug.Log("GameRestart");
    }
}
