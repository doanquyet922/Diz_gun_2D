using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    //Resolution[] resolutions;

    //public Dropdown resolutionsDropdown;
    public Dropdown graphicsDropdown;
    //public Toggle fullscreenToggle;
    public Slider volumeSlider;
    
    private void Start()
    {
        //resolutions = Screen.resolutions;
        //resolutionsDropdown.ClearOptions();
        //List<string> options = new List<string>();
        //int currentResolutionIndex = 0;
        //for (int i = 0; i < resolutions.Length; i++)
        //{
        //    string option = resolutions[i].width + " x " + resolutions[i].height;
        //    options.Add(option);
        //    if(resolutions[i].width==Screen.currentResolution.width &&
        //        resolutions[i].height == Screen.currentResolution.height)
        //    {
        //        currentResolutionIndex = i;
        //    }
        //}
        //resolutionsDropdown.AddOptions(options);
        //resolutionsDropdown.value = currentResolutionIndex;
        //resolutionsDropdown.RefreshShownValue();

        //fullscreenToggle.isOn = Screen.fullScreen;
        
        graphicsDropdown.value = QualitySettings.GetQualityLevel();
        graphicsDropdown.RefreshShownValue();
        float volume = 0; ;
        audioMixer.GetFloat("volume",out volume);
        volumeSlider.value = volume;
        
    }
    //public void SetResolution(int resolutionIndex)
    //{
    //    Resolution resolution = resolutions[resolutionIndex];
    //    Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    //}
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
        
    }
    public void OnSound()
    {
        volumeSlider.value = 0;
        audioMixer.SetFloat("volume", 0);

    }
    public void Mute()
    {
        audioMixer.SetFloat("volume", -80f);
        volumeSlider.value = -80f;

    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
