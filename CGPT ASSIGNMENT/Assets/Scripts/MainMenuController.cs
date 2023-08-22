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
	
    // Use this for initialization
    void Start ()
	{
		// Check if a checkpoint has been reached in any scene
        bool hasCheckpoint = PlayerPrefs.HasKey("CheckpointReached");

        // Activate the "Continue" button if a checkpoint has been reached
        continueButton.gameObject.SetActive(hasCheckpoint);
		
		ToShow.SetActive(false);
    }
    // Update is called once per frame
    void Update ()
	{
    }
	
	public void ContinueGame()
    {
        // Load the scene where the player left off
        string lastScene = PlayerPrefs.GetString("LastScene");
        SceneManager.LoadScene(lastScene);
    }
	
	public void StartNewGame()
    {
        // Set the checkpoint key to indicate a checkpoint has been reached
        PlayerPrefs.SetString("CheckpointReached", "true");

        // Load the first level or your starting scene
        SceneManager.LoadScene("ROOM 1");
    }
	
    public void Settings(){
        //restart the level named gameScene
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
        //quit the game
        Application.Quit();
    }
} 

