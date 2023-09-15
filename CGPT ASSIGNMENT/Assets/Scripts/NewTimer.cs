using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NewTimer : MonoBehaviour
{
	public AudioSource fiveminutes;
	public AudioSource oneminutes;
	public AudioSource countdown;

    [SerializeField] private float TotalTime = 420f;
    [SerializeField] private TextMeshProUGUI TimerText;

    private float CurrentTime;
    private bool isRunning = false;
	private bool playedFiveMinutesAudio = false;
	private bool playedOneMinuteAudio = false;
	private bool playedThirtySecondsAudio = false;


    private void Start()
    {
        CurrentTime = TotalTime;
        StartTimer();
        UpdateTimer();
		playedFiveMinutesAudio = false;
		playedOneMinuteAudio = false;
		playedThirtySecondsAudio = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(isRunning)
        {
            CurrentTime -= Time.deltaTime;
            UpdateTimer();
			CheckTime();

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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
	
		private void CheckTime()
	{
		if (CurrentTime <= 300f && !playedFiveMinutesAudio)
		{
			fiveminutes.Play();
			playedFiveMinutesAudio = true;
		}

		if (CurrentTime <= 60f && !playedOneMinuteAudio)
		{
			oneminutes.Play();
			playedOneMinuteAudio = true;
		}

		if (CurrentTime <= 30f && !playedThirtySecondsAudio)
		{
			countdown.Play();
			playedThirtySecondsAudio = true;
		}
	}
}
