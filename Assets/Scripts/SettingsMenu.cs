using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolitionsDropdown;
    private Resolution[] _resolutions;
    // Start is called before the first frame update
    void Start()
    {
        _resolutions = Screen.resolutions;

        int currentResolutionIndex = 0;
        
        resolitionsDropdown.ClearOptions();
        List<string> rOptions = new List<string>();

        for (int i = 0; i < _resolutions.Length; i++)
        {
            string rOption = _resolutions[i].width + " x " + _resolutions[i].width;
            rOptions.Add(rOption);

            if (_resolutions[i].width == Screen.currentResolution.width &&
               _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolitionsDropdown.AddOptions(rOptions) ;
        resolitionsDropdown.value = currentResolutionIndex;
        resolitionsDropdown.RefreshShownValue();
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex) ;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex]; 
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }
    

}
