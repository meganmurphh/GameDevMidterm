using UnityEngine;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startScreenCanvas; // Reference to the Start Screen Canvas

    void Start()
    {
        startScreenCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        startScreenCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
