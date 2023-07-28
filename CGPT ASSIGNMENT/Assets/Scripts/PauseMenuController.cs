using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
	public GameObject ToH;
	public GameObject ToS;
	
    // Use this for initialization
    void Start () {
		ToS.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
    }
	
	public void Continue(){
		ToH.SetActive(false);
	}

    public void PauseSetting(){
        //restart the level named gameScene
        ToS.SetActive(true);
        ToH.SetActive(false);
    }
	
	public void PauseBack(){
		ToH.SetActive(true);
		ToS.SetActive(false);
	}

    public void Exittomainmenu(){
        SceneManager.LoadScene ("LoadScene");
    }
} 

