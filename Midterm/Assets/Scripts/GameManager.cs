using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public Player player;
    public GameObject endScreenCanvas;
    public Text finalScoreText;
    public Text highScoreText;

    private bool gameEnded = false;

    void Start()
    {
        endScreenCanvas.SetActive(false);
    }

    void Update()
    {
        if (!gameEnded && (timer.remainingTime <= 0 || (player.bulletsOf1 <= 0 && player.bulletsOf2 <= 0 && player.bulletsOf3 <= 0)))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        gameEnded = true;
        endScreenCanvas.SetActive(true);
        Time.timeScale = 0f;
        finalScoreText.text = "Final Score: " + player.points;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (player.points > highScore)
        {
            highScore = player.points;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        highScoreText.text = "High Score: " + highScore;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
