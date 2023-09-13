using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheck : MonoBehaviour
{
    private string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        SaveLastScene();
    }

	private void SaveLastScene()
    {
        PlayerPrefs.SetString("LastScene", currentSceneName);
    }
}
