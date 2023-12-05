using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private GameObject settingsMenu;

    private AudioManager am;
    private Resolution[] resolutions;


    void Start()
    {
        am = AudioManager.GetInstance();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currResolutionIndex = 0;
        int count = 0;

        foreach ( Resolution resolutionOption in resolutions )
        {
            string option = resolutionOption.width + " x " + resolutionOption.height;
            options.Add(option);

            if (resolutionOption.width == Screen.currentResolution.width
                && resolutionOption.height == Screen.currentResolution.height)
            {
                currResolutionIndex = count;
            }
            count++;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetMusicVolume(float volume)
    {
        am.setMusicVolume(volume);
    }
    public void SetSFXVolume(float volume)
    {
        am.setSFXVolume(volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void closeSettings()
    {
        GameManager.GetInstance().isPaused = false;
        settingsMenu.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
