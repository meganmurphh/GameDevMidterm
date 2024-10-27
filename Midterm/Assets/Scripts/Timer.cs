using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;
    public float totalTime = 120f;

    public float remainingTime;

    void Start()
    {
        remainingTime = totalTime;
        timerSlider.maxValue = totalTime;
        timerSlider.value = totalTime;
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerSlider.value = remainingTime;

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (remainingTime <= 0)
            {
                remainingTime = 0;
            }
        }
    }
}
