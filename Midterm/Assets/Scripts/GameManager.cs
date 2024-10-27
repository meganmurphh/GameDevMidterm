using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Timer timer;
    private Player player;
    public GameObject endScreenCanvas;
    public Text finalScoreText;
    public Text highScoreText;

    private void Start()
    {
        timer = GetComponent<Timer>();
        player = GetComponent<Player>();

        endScreenCanvas.SetActive(false);
    }

    private void Update()
    {
        if (timer.totalTime <= 0 || (player.bulletsOf1 <= 0 && player.bulletsOf2 <= 0 && player.bulletsOf3 <= 0))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        endScreenCanvas.SetActive(true);
        finalScoreText.text = "Final Score: " + player.points;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (player.points > highScore)
        {
            highScore = player.points;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        highScoreText.text = "High Score: " + highScore;

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        PlayerPrefs.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
