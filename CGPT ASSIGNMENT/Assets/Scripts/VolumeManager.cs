using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider; // Reference to the UI Slider

    private void Start()
    {
        LoadVolumeValue(); // Load the volume value when the scene starts
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        SaveVolumeValue(volume); // Save the volume value when adjusted
    }

    private void LoadVolumeValue()
    {
        if (PlayerPrefs.HasKey("VolumeValue"))
        {
            float savedValue = PlayerPrefs.GetFloat("VolumeValue");
            volumeSlider.value = savedValue;
            SetVolume(savedValue);
        }
        else
        {
            volumeSlider.value = 0.5f; // Set default value if not found
            SetVolume(0.5f);
        }
    }

    private void SaveVolumeValue(float volume)
    {
        PlayerPrefs.SetFloat("VolumeValue", volume);
    }
}
