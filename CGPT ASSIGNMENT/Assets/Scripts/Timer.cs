using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 600;
    public TextMeshProUGUI timerText;
	
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>(); // Assign the TextMeshProUGUI component
    }

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
			SceneManager.LoadScene("gameOverScene");
        }

        if (timeValue < 0)
        {
            timeValue = 0;
        }
        float minutes = Mathf.FloorToInt(timeValue / 60);
        float seconds = Mathf.FloorToInt(timeValue % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
