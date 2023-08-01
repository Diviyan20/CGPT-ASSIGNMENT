using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    public Slider brightnessSlider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    AutoExposure exposure;

    private void Start()
    {
        brightness.TryGetSettings(out exposure);
        LoadBrightnessValue(); // Load the brightness value when the scene starts
    }

    public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
        }
        else
        {
            exposure.keyValue.value = .05f;
        }

        SaveBrightnessValue(); // Save the brightness value when adjusted
    }

    private void LoadBrightnessValue()
    {
        if (PlayerPrefs.HasKey("BrightnessValue"))
        {
            float savedValue = PlayerPrefs.GetFloat("BrightnessValue");
            brightnessSlider.value = savedValue;
            AdjustBrightness(savedValue);
        }
        else
        {
            brightnessSlider.value = 0.5f; // Set default value if not found
            AdjustBrightness(0.5f);
        }
    }

    private void SaveBrightnessValue()
    {
        PlayerPrefs.SetFloat("BrightnessValue", brightnessSlider.value);
    }
}
