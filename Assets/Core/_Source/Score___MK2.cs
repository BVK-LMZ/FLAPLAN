using UnityEngine;
using TMPro;

public class Score___MK2 : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI element for score display
    public TextMeshProUGUI highScoreText; // UI element for high score display
    private int score = 0;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();

        if (score > GetHighScore())
        {
            SaveHighScore(score);
            
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = $"High Score: {GetHighScore()}";
    }

    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    private void SaveHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt("HighScore", newHighScore);
        PlayerPrefs.Save();
    }
}