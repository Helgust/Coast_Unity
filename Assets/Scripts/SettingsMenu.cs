using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using  TMPro;
using Newtonsoft.Json;
using Assets.SimpleLocalization;

public class SettingsMenu : MonoBehaviour
{
    private Dropdown resolitionsDropdown;
    private Dropdown qualityDropdown;
    private Dropdown languageDropdown;
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
        else
        {
            readGameSettings();
        }
        
    }

    public void Start()
    {
        GetSettingItems();
        FirstReadGameSetting();
    }
    private void OnEnable()
    {
        GetSettingItems();
        readGameSettings();
    }
    public void ReadLocalOnEnable()
    {
        GetSettingItems();
        readGameSettings();
    }
    
    private void GetSettingItems()
    {
        resolitionsDropdown = transform.Find("DialogWindow/Resolution").gameObject.GetComponent<Dropdown>();
        qualityDropdown = transform.Find("DialogWindow/Quality").gameObject.GetComponent<Dropdown>();
        languageDropdown = transform.Find("DialogWindow/Language").gameObject.GetComponent<Dropdown>();
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
            SetLanguage(_settings.currentLanguage);
        }
        else
        {
            Debug.Log("Not Exists");
            GameSettings _settings = new GameSettings();
            Debug.Log("FullDef="+_settings.fullScreenflag);
            SetFullscreen(_settings.fullScreenflag);
            SetResolution(_settings.currentResolutionIndex);
            SetQuality(_settings.currentQualityIndex);
            for (int i=0; i < languageDropdown.options.Count;i++)
            {
                if (languageDropdown.options[i].text == LocalizationManager.Language)
                {
                    _settings.currentLanguage = i;
                }
            }
            SetLanguage(_settings.currentLanguage);
        }
    }
    public void SaveGameSettings()
    {
        
        //_gameSettingsJSON = Resources.Load <TextAsset> ("Configs/gameSettings");
         GameSettings _settings = new GameSettings();
        _settings.fullScreenflag = fullscreen.isOn;
        _settings.currentLanguage = languageDropdown.value;
        _settings.currentLanguageName = languageDropdown.options[languageDropdown.value].text;
        _settings.currentQualityIndex = qualityDropdown.value;
        _settings.currentResolutionIndex = resolitionsDropdown.value;
        
        
        string settingText = JsonUtility.ToJson(_settings);
        Debug.Log("SettingText"+settingText);
        File.WriteAllText(Application.dataPath + "/gameSettings.json", settingText);
        SetFullscreen(_settings.fullScreenflag);
        SetResolution(_settings.currentResolutionIndex);
        SetQuality(_settings.currentQualityIndex);
        SetLanguage(_settings.currentLanguage);
        
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
        string localization = languageDropdown.options[languageIndex].text;
        SetLocalization(localization);
        //_settings.currentResolutionIndex = resolutionIndex;
        //ToDo Localization
    }
    public void SetLocalization(string localization)
    {
        Debug.Log("CurrLoc="+localization );
        LocalizationManager.Language = localization;
    }
    public void FirstReadGameSetting()
    {
        if (File.Exists(Application.dataPath + "/gameSettings.json"))
        {
            Debug.Log("Exists");
            string _settingText = File.ReadAllText(Application.dataPath + "/gameSettings.json");
            GameSettings _settings = JsonConvert.DeserializeObject<GameSettings>(_settingText);
            SetLocalization(_settings.currentLanguageName);
        }
        else
        {
            Debug.Log("Not Exists");
            GameSettings _settings = new GameSettings();
            Debug.Log("FullDef="+_settings.fullScreenflag);
            SetLocalization(_settings.currentLanguageName);
        }
    }

    public void CloseSettings()
    {
        GameUIManager.instance.SettingsDialog.SetActive(false);
    }
}