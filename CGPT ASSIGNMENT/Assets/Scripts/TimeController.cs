using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeController : MonoBehaviour
{
    public float totalTimeInSeconds = 420f; // 10 minutes in seconds
    public TextMeshProUGUI timerText; // Reference to the UI Text that will display the timer
	public AudioSource fiveminutes;
	public AudioSource oneminutes;
	public AudioSource countdown;

    private float currentTime; // Current time left in seconds
    private bool isTimerRunning = false; // Flag to check if the timer is running
    private CanvasGroup timerUI;
	private bool playedFiveMinutesAudio = false;
	private bool playedOneMinuteAudio = false;
	private bool playedThirtySecondsAudio = false;

    private void Start()
    {
        ResetTimer();
        timerUI = GetComponent<CanvasGroup>();
        HideTimer();
		playedFiveMinutesAudio = false;
		playedOneMinuteAudio = false;
		playedThirtySecondsAudio = false;

    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
			CheckTime();

            if (currentTime <= 0f)
            {
                TimerFinished();
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        ShowTimer();
    }

    private void ShowTimer()
    {
        timerUI.alpha = 1f;
        timerUI.interactable = true;
        timerUI.blocksRaycasts = true;
    }

    private void HideTimer()
    {
        timerUI.alpha = 0f;
        timerUI.interactable = false;
        timerUI.blocksRaycasts = false;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = totalTimeInSeconds;
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TimerFinished()
    {
        // Add any actions you want to happen when the timer reaches 0 (e.g., game over)
        isTimerRunning = false;
        timerText.text = "00:00";
        Debug.Log("Timer Finished!");
        SceneManager.LoadScene("gameOverScene");
    }
	
	private void CheckTime()
	{
		if (currentTime <= 300f && !playedFiveMinutesAudio)
		{
			fiveminutes.Play();
			playedFiveMinutesAudio = true;
		}

		if (currentTime <= 60f && !playedOneMinuteAudio)
		{
			oneminutes.Play();
			playedOneMinuteAudio = true;
		}

		if (currentTime <= 30f && !playedThirtySecondsAudio)
		{
			countdown.Play();
			playedThirtySecondsAudio = true;
		}
	}
}
