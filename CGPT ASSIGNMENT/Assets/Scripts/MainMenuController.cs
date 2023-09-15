using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour 
{
	public Button continueButton;
	public GameObject ToHide;
	public GameObject ToShow;
	
    void Start ()
	{
        bool hasCheckpoint = PlayerPrefs.HasKey("CheckpointReached");

        continueButton.gameObject.SetActive(hasCheckpoint);
		
		ToShow.SetActive(false);
        Cursor.visible = true;
    }
	
    void Update ()
	{
    }
	
	public void ContinueGame()
    {
        string lastScene = PlayerPrefs.GetString("LastScene");
        SceneManager.LoadScene(lastScene);
        Cursor.visible = true;
    }
	
	public void StartNewGame()
    {
        PlayerPrefs.SetString("CheckpointReached", "true");

        SceneManager.LoadScene("ROOM 1");
    }
	
    public void Settings(){
        ToShow.SetActive(true);
        ToHide.SetActive(false);
    }
	
	public void Back()
	{
		ToHide.SetActive(true);
		ToShow.SetActive(false);
	}

    public void Exit()
	{
        Application.Quit();
    }
} 

