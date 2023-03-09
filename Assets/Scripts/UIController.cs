using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text distanceTraveled;
    [SerializeField] Text collectedCoins;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject sky;

    public void ShowGameOverScreen()
    {
        // sets the game over screen to active
        gameOverScreen.SetActive(true);

        // turn off game music
        gameMusic.SetActive(false);

        // turn off sky and sky sound
        sky.SetActive(false);

        // remove decimal places from player.distanceTraveled
        float roundedDistance = Mathf.Ceil(player.distanceTraveled);

        // display meters traveled using roundedDistance
        distanceTraveled.text = "Meters Traveled: " + roundedDistance;

        // display number of coins collected in text field
        collectedCoins.text = "Coins Collected: " + player.GetCollectedCoins();


    }

    public void GameRestart()
    {
        //Debug.Log("GameRestart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // restart time
        Time.timeScale = 1;
    }
}
