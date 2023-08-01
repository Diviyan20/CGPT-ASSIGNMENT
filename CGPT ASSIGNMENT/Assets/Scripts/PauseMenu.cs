using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;
	public GameObject ToH;
    public GameObject ToS;
	public PlayerLook playerLook;
	
	private bool isGamePaused = false;

    void Start()
    {
        pauseCanvas.SetActive(false); // Set the canvas to be initially hidden
		ToS.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isGamePaused = !isGamePaused;

        Time.timeScale = isGamePaused ? 0f : 1f;
        Cursor.lockState = isGamePaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isGamePaused;

        pauseCanvas.SetActive(isGamePaused);

        // Enable or disable camera movement based on the pause state
        playerLook.SetCameraMovement(!isGamePaused);
    }

    // Update is called once per frame
    public void Continue()
    {
        TogglePause();
    }

    public void PauseSetting()
    {
        ToS.SetActive(true);
        ToH.SetActive(false);
    }

    public void PauseBack()
    {
        ToH.SetActive(true);
        ToS.SetActive(false);
    }

    public void Exittomainmenu()
    {
        SceneManager.LoadScene("LoadScene");
		Time.timeScale = 1f;
    }
}
