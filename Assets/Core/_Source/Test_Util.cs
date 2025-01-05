//PRESS R to RESET


using UnityEngine;  // Import UnityEngine for core functionality like MonoBehaviour, Input, Debug, etc.
using UnityEngine.SceneManagement;  // Import the SceneManagement namespace to handle scene loading and reloading.

public class Test_Util : MonoBehaviour  // Define a class named Test_Util that inherits from MonoBehaviour (Unity's base class for scripts).
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Output a message in the console to instruct the user to press 'R' to reset the level.
        Debug.Log("Press 'R' to reset the current level.");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'R' key is pressed (Input.GetKeyDown checks for a key press at the current frame).
        if (Input.GetKeyDown(KeyCode.R))
        {
            // If 'R' is pressed, call the ResetCurrentLevel method.
            ResetCurrentLevel();
        }
    }

    // Function to get and reset the current level
    void ResetCurrentLevel()
    {
        // Get the build index (unique identifier) of the currently active scene.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the scene using the current scene's build index to reset the level.
        SceneManager.LoadScene(currentSceneIndex);
    }
}
