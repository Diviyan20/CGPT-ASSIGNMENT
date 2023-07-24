using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCondition : MonoBehaviour
{
    // Reference to the "GameOver" script or GameObject with the "GameOver" script
    public GameOver gameOver;

    // ...

    public void TriggerGameOver()
    {
        // Save the current scene name to PlayerPrefs as the previous scene
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);

        // Load the game over scene
        SceneManager.LoadScene("gameOverScene");
    }

    // ...
}
