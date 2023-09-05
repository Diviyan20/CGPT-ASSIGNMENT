using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NewTimer : MonoBehaviour
{
    [SerializeField] private float TotalTime = 420f;
    [SerializeField] private TextMeshProUGUI TimerText;

    private float CurrentTime;
    private bool isRunning = false;


    private void Start()
    {
        CurrentTime = TotalTime;
        StartTimer();
        UpdateTimer();
    }

    // Update is called once per frame
    private void Update()
    {
        if(isRunning)
        {
            CurrentTime -= Time.deltaTime;
            UpdateTimer();

            if(CurrentTime <= 0f)
            {
                EndTimer();
            }
        }

    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(CurrentTime / 60f);
        int seconds = Mathf.FloorToInt(CurrentTime % 60f);
        TimerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    private void EndTimer()
    {
        isRunning = false;
        TimerText.text = "00:00";
        Debug.Log("Timer has Ended");
        SceneManager.LoadScene("gameOverScene");
    }
}
