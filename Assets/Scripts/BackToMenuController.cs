using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuController : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        // OR
        // SceneManager.LoadScene(0);   // 0 is the index of the Menu scene in the build settings
        // OR
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);    // Loads the previous scene in the build settings
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            BackToMenu();
        }
    }
}
