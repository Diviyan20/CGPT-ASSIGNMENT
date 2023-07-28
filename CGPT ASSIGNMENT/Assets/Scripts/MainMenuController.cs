using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour 
{
	public GameObject ToHide;
	public GameObject ToShow;
	
    // Use this for initialization
    void Start () {
		ToShow.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
    }

    public void Settings(){
        //restart the level named gameScene
        ToShow.SetActive(true);
        ToHide.SetActive(false);
    }
	
	public void Back(){
		ToHide.SetActive(true);
		ToShow.SetActive(false);
	}

    public void Exit(){
        //quit the game
        Application.Quit();
    }
} 

