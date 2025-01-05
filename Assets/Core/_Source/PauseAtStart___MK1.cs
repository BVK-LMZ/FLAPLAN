using System.Collections;
using UnityEngine;

public class PauseAtStart : MonoBehaviour
{
    // Public GameObject variable for the canvas or UI element to hide
    public GameObject targetGameObject;
    public float timeARG = .4f; // Time to wait before unpausing the game
    private void Awake()
    {
        // Pause the game as soon as possible
        PauseGame();
        
        // Start the coroutine to handle the delay and unpause
        StartCoroutine(HandlePauseAndUnpause());
    }

    private void PauseGame()
    {
        // Set time scale to 0 to pause the game
        Time.timeScale = 0;
    }

    private void UnpauseGame()
    {
        // Set time scale back to 1 to unpause the game
        Time.timeScale = 1;
    }

    private IEnumerator HandlePauseAndUnpause()
    {
        // Wait for 2 real-time seconds
        yield return new WaitForSecondsRealtime(timeARG);

        // Hide the target GameObject
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }

        // Unpause the game
        UnpauseGame();
    }
}