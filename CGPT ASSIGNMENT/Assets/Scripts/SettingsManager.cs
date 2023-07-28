using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightnessSlider;

    private void Start()
    {
        // Load the saved settings when the settings menu is opened
        LoadSettings();
    }

    // Call this method when the volume slider value changes
    public void OnVolumeSliderChanged()
    {
        // Set the volume value based on the slider's value
        float volumeValue = volumeSlider.value;
        SetVolume(volumeValue);
    }

    // Call this method when the brightness slider value changes
    public void OnBrightnessSliderChanged()
    {
        // Set the brightness value based on the slider's value
        float brightnessValue = brightnessSlider.value;
        SetBrightness(brightnessValue);
    }

    private void SetVolume(float volume)
    {
        // Save the volume setting using PlayerPrefs
        PlayerPrefs.SetFloat("Volume", volume);

        // Apply the volume setting to the AudioListener or AudioMixer (optional)
        AudioListener.volume = volume;
    }

    private void SetBrightness(float brightness)
    {
        // Save the brightness setting using PlayerPrefs
        PlayerPrefs.SetFloat("Brightness", brightness);

        // Apply the brightness setting to your game's visuals or shaders (optional)
        RenderSettings.ambientIntensity = brightness;
    }

    private void LoadSettings()
    {
        // Load the saved volume and brightness settings from PlayerPrefs
        float volumeValue = PlayerPrefs.GetFloat("Volume", 1f); // 1f is the default value if not found
        float brightnessValue = PlayerPrefs.GetFloat("Brightness", 1f); // 1f is the default value if not found

        // Set the slider values based on the loaded settings
        volumeSlider.value = volumeValue;
        brightnessSlider.value = brightnessValue;

        // Apply the loaded settings to your game (e.g., AudioListener.volume and RenderSettings.ambientIntensity)
        AudioListener.volume = volumeValue;
        RenderSettings.ambientIntensity = brightnessValue;
    }
}
