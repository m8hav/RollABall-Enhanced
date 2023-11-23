using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Switch to Main Menu when Escape Key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            SceneManager.LoadScene("Menu");
        }
    }
}
