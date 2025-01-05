using UnityEngine;

public class PipeScoring___MK1 : MonoBehaviour
{
    private Score___MK2 scoreManager;

    private void Start()
    {
        // Attempt to find the Score___MK2 instance in the scene
        scoreManager = FindObjectOfType<Score___MK2>();

        if (scoreManager == null)
        {
            Debug.LogError("Score___MK2 not found! Ensure it's attached to a GameObject in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreManager.AddScore(1); // Use the instance to call AddScore
        }
    }
}