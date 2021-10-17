using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsControls : MonoBehaviour
{
    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;
    private bool _isFullScreen = false;

    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width +"x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }
    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, _isFullScreen);
    }
    public AudioMixer am;
    // Start is called before the first frame update
    public void FullSCreenToggle()
    {
        _isFullScreen = !_isFullScreen;
        Screen.fullScreen = _isFullScreen;
    }
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("MasterVolume", sliderValue);
        
    }
    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }
}
