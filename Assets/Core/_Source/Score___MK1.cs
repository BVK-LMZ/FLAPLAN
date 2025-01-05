using UnityEngine; // Import UnityEngine namespace for debugging and logging.
using TMPro; // Import TextMesh Pro namespace for UI text handling.

/// <summary>
/// Static class for managing the game score.
/// </summary>
public static class Score___MK1 
{
    /// <summary>
    /// Variables and Components
    /// </summary>

    private static int score = 0; // Static integer variable to keep track of the score.

    private static TextMeshProUGUI scoreText; // Static reference to a TextMesh Pro text component for displaying the score.

    /// <summary>
    /// Class Functions
    /// </summary>

    /// <summary>
    /// Initializes the score system with a TextMeshProUGUI reference.
    /// This method needs to be called to set up the UI.
    /// </summary>
    /// <param name="textComponent">The TextMeshProUGUI component to display the score.</param>
    public static void Initialize(TextMeshProUGUI textComponent)
    {
        scoreText = textComponent; // Assign the passed TextMeshProUGUI to the static reference.
        UpdateScore(0); // Initialize the score to 0 and update the display.
    }

    /// <summary>
    /// Gets the current score.
    /// </summary>
    /// <returns>The current score value as an integer.</returns>
    public static int GetScore()
    {
        return score; // Return the current score.
    }

    /// <summary>
    /// Updates the score by a specified value and updates the UI.
    /// </summary>
    /// <param name="value">The value to add to the current score.</param>
    public static void UpdateScore(int value)
    {
        score += value; // Add the value to the score.
        Debug.Log($"Score updated: {score}"); // Log the updated score for debugging.
        UpdateScoreText(); // Call the method to update the TextMeshPro text.
    }

    /// <summary>
    /// Updates the score display on the UI.
    /// </summary>
    private static void UpdateScoreText()
    {
        if (scoreText != null) // Check if the TextMeshPro reference is assigned.
        {
            scoreText.text = $"Score: {score}"; // Update the displayed text with the current score.
        }
        else
        {
            Debug.LogWarning("Score TextMesh Pro reference is missing!"); // Log a warning if the reference is missing.
        }
    }
}
