using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheck : MonoBehaviour
{
    public Transform respawnPoint;
    private string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        LoadPlayerPosition();
        SaveLastScene();
    }

    public void SetRespawnPoint(Transform point)
    {
        respawnPoint = point;
        SavePlayerPosition();
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
    }

    private void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat(currentSceneName + "_PosX", respawnPoint.position.x);
        PlayerPrefs.SetFloat(currentSceneName + "_PosY", respawnPoint.position.y);
        PlayerPrefs.SetFloat(currentSceneName + "_PosZ", respawnPoint.position.z);
        PlayerPrefs.SetFloat(currentSceneName + "_RotX", respawnPoint.rotation.x);
        PlayerPrefs.SetFloat(currentSceneName + "_RotY", respawnPoint.rotation.y);
        PlayerPrefs.SetFloat(currentSceneName + "_RotZ", respawnPoint.rotation.z);
        PlayerPrefs.SetFloat(currentSceneName + "_RotW", respawnPoint.rotation.w);
    }

    private void LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey(currentSceneName + "_PosX"))
        {
            float posX = PlayerPrefs.GetFloat(currentSceneName + "_PosX");
            float posY = PlayerPrefs.GetFloat(currentSceneName + "_PosY");
            float posZ = PlayerPrefs.GetFloat(currentSceneName + "_PosZ");
            float rotX = PlayerPrefs.GetFloat(currentSceneName + "_RotX");
            float rotY = PlayerPrefs.GetFloat(currentSceneName + "_RotY");
            float rotZ = PlayerPrefs.GetFloat(currentSceneName + "_RotZ");
            float rotW = PlayerPrefs.GetFloat(currentSceneName + "_RotW");
            respawnPoint.position = new Vector3(posX, posY, posZ);
            respawnPoint.rotation = new Quaternion(rotX, rotY, rotZ, rotW);
        }
    }
	
	private void SaveLastScene()
    {
        PlayerPrefs.SetString("LastScene", currentSceneName);
    }
}
