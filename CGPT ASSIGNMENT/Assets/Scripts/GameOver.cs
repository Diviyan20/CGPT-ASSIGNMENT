using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
	private string previousScene;
	
    // Use this for initialization
    void Start () 
	{
		previousScene = PlayerPrefs.GetString("PreviousScene");
    }
    // Update is called once per frame
    void Update () 
	{
    }

    public void Restart()
	{
		SceneManager.LoadScene (previousScene);
    }

    public void Exit()
	{
        SceneManager.LoadScene ("LoadScene");
    }
} 

