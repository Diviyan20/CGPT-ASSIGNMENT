using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent the GameObject from being destroyed when a new scene is loaded.
        }
        else
        {
            // If an instance already exists, destroy this GameObject.
            Destroy(gameObject);
        }
    }
}
