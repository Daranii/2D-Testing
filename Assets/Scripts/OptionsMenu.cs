using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //public AudioMixer audioMixer;
    [SerializeField]
    private Dropdown resolutionDropdown = null;

    private Resolution[] resolutions;

    void Start ()
    {
        resolutions = Screen.resolutions;

        List<string> options = new List<string>() ;

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string value = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "FPS";
            options.Add(value);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRate);
    }

    public void SetVolume(float volume)
    {
        //audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullScreen(int index)
    {
        if (index == 0)
            Screen.fullScreenMode = FullScreenMode.Windowed;
        else if (index == 1)
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        else if (index == 2)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

    }
}
