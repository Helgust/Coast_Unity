using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using  TMPro;
using Newtonsoft.Json;

public class SettingsMenu : MonoBehaviour
{
    private TMP_Dropdown resolitionsDropdown;
    private TMP_Dropdown qualityDropdown;
    private TMP_Dropdown languageDropdown;
    private Toggle fullscreen;
    private Resolution[] _resolutions;
    private TextAsset _gameSettingsJSON;
    // Start is called before the first frame update
    void Awake()
    {
        GetSettingItems();
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
        if (!File.Exists(Application.dataPath + "/gameSettings.json"))
        {
            SaveGameSettings();
        }
        
    }
    
    private void OnEnable()
    {
        GetSettingItems();
        readGameSettings();
    }
    
    private void GetSettingItems()
    {
        resolitionsDropdown = transform.Find("DialogWindow/Resolution").gameObject.GetComponent<TMP_Dropdown>();
        qualityDropdown = transform.Find("DialogWindow/Quality").gameObject.GetComponent<TMP_Dropdown>();
        languageDropdown = transform.Find("DialogWindow/Language").gameObject.GetComponent<TMP_Dropdown>();
        fullscreen = transform.Find("DialogWindow/FullScreenToggle").gameObject.GetComponent<Toggle>();
    }
    private void readGameSettings()
    {
        if (File.Exists(Application.dataPath + "/gameSettings.json"))
        {
            Debug.Log("Exists");
            string _settingText = File.ReadAllText(Application.dataPath + "/gameSettings.json");
            GameSettings _settings = JsonConvert.DeserializeObject<GameSettings>(_settingText);
            SetFullscreen(_settings.fullScreenflag);
            SetResolution(_settings.currentResolutionIndex);
            SetQuality(_settings.currentQualityIndex);
        }
        else
        {
            Debug.Log("Not Exists");
            GameSettings _settings = new GameSettings();
            Debug.Log("FullDef="+_settings.fullScreenflag);
            SetFullscreen(_settings.fullScreenflag);
            SetResolution(_settings.currentResolutionIndex);
            SetQuality(_settings.currentQualityIndex);
        }
    }
    public void SaveGameSettings()
    {
        
        //_gameSettingsJSON = Resources.Load <TextAsset> ("Configs/gameSettings");
         GameSettings _settings = new GameSettings();
        _settings.fullScreenflag = fullscreen.isOn;
        _settings.currentLanguage = languageDropdown.value;
        _settings.currentQualityIndex = qualityDropdown.value;
        _settings.currentResolutionIndex = resolitionsDropdown.value;
        
        
        string settingText = JsonUtility.ToJson(_settings);
        Debug.Log("SettingText"+settingText);
        File.WriteAllText(Application.dataPath + "/gameSettings.json", settingText);
        SetFullscreen(_settings.fullScreenflag);
        SetResolution(_settings.currentResolutionIndex);
        SetQuality(_settings.currentQualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        //_settings.fullScreenflag = isFullScreen;
        fullscreen.SetIsOnWithoutNotify(isFullScreen);
        Screen.fullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        qualityDropdown.SetValueWithoutNotify(qualityIndex);
        //_settings.currentQualityIndex = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex) ;
    }

    public void SetResolution(int resolutionIndex)
    {
        resolitionsDropdown.SetValueWithoutNotify(resolutionIndex);
        //_settings.currentResolutionIndex = resolutionIndex;
        Resolution resolution = _resolutions[resolutionIndex]; 
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }
    
    public void SetLanguage(int languageIndex)
    {
        languageDropdown.SetValueWithoutNotify(languageIndex);
        //_settings.currentResolutionIndex = resolutionIndex;
        //ToDo Localization
    }
    

}