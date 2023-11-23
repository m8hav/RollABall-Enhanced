using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    private int escapeCount = 0;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        // OR
        // SceneManager.LoadScene(1);   // 1 is the index of the Game scene in the build settings
        // OR
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    // Loads the next scene in the build settings
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game!");
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Close game when Escape Key is pressed twice
            if (++escapeCount == 2)
            {
                Debug.Log("Escape key pressed twice!");
                QuitGame();
            }
        }
    }
}
