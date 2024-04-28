using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    float currentBrightness;
    float currentVolume;

    float MaxBrightness = 1.0f;
    float MinBrightness = 0.0f;
    float ChangeSpeed = 0.1f;

    public TMP_Text Volume;
    public TMP_Text Brightness;

    void Start()
    {
        currentBrightness = RenderSettings.ambientIntensity;
        currentVolume = AudioListener.volume;
    }
    void Update()
    {
        Brightness.text = (currentBrightness * 100).ToString() + " %";
        Volume.text = (currentVolume * 100).ToString() + " %";
    }

    public void Back()
    {
       transform.gameObject.SetActive(false);
    }
    public void VolumeUp()
    {
        if(currentVolume < 1.0f)
        {
            currentVolume += 0.1f;
            AudioListener.volume = currentVolume;
        }
    }
    public void VolumeDown()
    {
        if (currentVolume > 0.11f)
        {
            currentVolume -= 0.1f;
            AudioListener.volume = currentVolume;
        }
        else
        {
            currentVolume = 0.0f;
            AudioListener.volume = currentVolume;
        }
    }
    public void BrigthnessUp()
    {
        currentBrightness += ChangeSpeed;
        currentBrightness = Mathf.Clamp(currentBrightness, MinBrightness, MaxBrightness);
        RenderSettings.ambientIntensity = currentBrightness;
    }
    public void BrigthnessDown()
    {
        currentBrightness -= ChangeSpeed;
        currentBrightness = Mathf.Clamp(currentBrightness, MinBrightness, MaxBrightness);
        RenderSettings.ambientIntensity = currentBrightness;
    }
   
}
