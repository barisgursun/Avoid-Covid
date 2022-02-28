using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer Mix;
    private bool isFullScreen = true;
    public void SetResoulation(int index)
    {
        if(index == 0)
        {
            Screen.SetResolution(1920, 1080,isFullScreen);
        }
        else if(index ==1)
        {
            Screen.SetResolution(800, 600, isFullScreen);

        }
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen( bool fullscreen_enable)
    {
        Screen.fullScreen = fullscreen_enable;
        isFullScreen = fullscreen_enable;
    }
    public void SetMouseSensivity(float  value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);

        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MouseSensitivity = value;
        }
    }
    public void SetMasterVolume(float value)
    {
        Mix.SetFloat("MasterVolume", value);
    }   
    public void SetMusicVolume(float value)
    {
        Mix.SetFloat("MusicVolume", value);
    }
}
