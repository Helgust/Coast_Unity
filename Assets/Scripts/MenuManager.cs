using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.SimpleLocalization;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public GameObject LoadingDialog;
    public GameObject ChoosingMapDialog;
    public GameObject SettingsDialog;
    public GameObject MainMenu;
    public Text Description;
    public Button StartButton;
    public Button CountinueButton;
    public Toggle Map1Toggle;
    public Toggle Map2Toggle;
    public Toggle Map3Toggle;
    public GameObject DescriptionGO;
    private string stat_parametr;
    private bool pauseBool;
    private bool saveWindowBool = false;
    public bool isSaveItemDeSelected = false;
    public string saveName = String.Empty;

    void Awake() // here was Awake
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DirectoryInfo mapDir = new DirectoryInfo(Application.dataPath + "/Maps/");
        if (!mapDir.Exists)
        {
            Directory.CreateDirectory(Application.dataPath + "/Maps/");
            CopyMapsFromResourses();
        }
        else
        {
            CopyMapsFromResourses();
        }

        DirectoryInfo d = new DirectoryInfo(Application.dataPath + "/Save/");
        if (!d.Exists)
        {
            CountinueButton.interactable = false;
            Directory.CreateDirectory(Application.dataPath + "/Save/");
        }
        else
        {
            FileInfo[] files = d.GetFiles("*.data");
            if (files.Length == 0)
            {
                CountinueButton.interactable = false;
            }
            else
            {
                CountinueButton.interactable = true;
            }
        }


        LocalizationManager.Read();
        //SettingsDialog.GetComponent<SettingsMenu>().Start();

        switch (Application.systemLanguage)
        {
            case SystemLanguage.Russian:
                LocalizationManager.Language = "Russian";
                break;
            default:
                LocalizationManager.Language = "English";
                break;
        }
        
    }


    public void MMPressContinue()
    {
        DateTime last_modif_time = DateTime.MinValue;
        String filename = String.Empty;
        DirectoryInfo d = new DirectoryInfo(Application.dataPath + "/Save/");
        FileInfo[] files = d.GetFiles("*.data");

        foreach (var file in files)
        {
            if (file.CreationTimeUtc > last_modif_time)
            {
                last_modif_time = file.CreationTimeUtc;
                filename = file.Name;
            }
        }

        Debug.Log("Name " + filename);
        string path = Application.dataPath + "/Save/" + filename;

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Save data = bf.Deserialize(fileStream) as Save;
            Basket.instance.modeType = "LOAD";
            Basket.instance.saveData = data;
            //GameManager.instance.LoadFromSave(data);
            SceneManager.LoadScene("Scenes/SampleScene");
            fileStream.Close();
            UIManager.instance.curUIState = UIManager.UIState.Game;
        }
    }

    private void Update()
    {
        if (instance.isSaveItemDeSelected == true)
        {
            StartButton.interactable = false;
        }
    }

    public void MMPressNewGame()
    {
        ChoosingMapDialog.SetActive(true);
    }

    public void MMPressLoadGame()
    {
        LoadingDialog.SetActive(true);
    }

    public void MMPressSettings()
    {
        SettingsDialog.SetActive(true);
    }

    public void MMPressExit()
    {
        Application.Quit();
    }

    public void MapDialogPressCancel()
    {
        Basket.instance.mapData.name = String.Empty;
        ChoosingMapDialog.SetActive(false);
    }

    public void MapDialogPressStart()
    {
        Basket.instance.modeType = "NEW";
        SceneManager.LoadScene("Scenes/SampleScene");
        UIManager.instance.curUIState = UIManager.UIState.Game;
    }

    public void setPauseBool(bool new_bool)
    {
        pauseBool = new_bool;
    }

    public void setSaveWinBool(bool new_bool)
    {
        saveWindowBool = new_bool;
    }

    public bool getPauseBool()
    {
        return pauseBool;
    }

    public void SettingsPressClose()
    {
        SettingsDialog.SetActive(false);
    }

    public void OnDisable()
    {
        LoadingDialog.SetActive(false);
        ChoosingMapDialog.SetActive(false);
        SettingsDialog.SetActive(false);
    }
    public void OnEnable()
    {
        //SettingsDialog.GetComponent<SettingsMenu>().ReadLocalOnEnable();
        SettingsDialog.SetActive(true);
        SettingsDialog.SetActive(false);
        DirectoryInfo d = new DirectoryInfo(Application.dataPath + "/Save/");
        if (!d.Exists)
        {
            CountinueButton.interactable = false;
            Directory.CreateDirectory(Application.dataPath + "/Save/");
        }
        else
        {
            FileInfo[] files = d.GetFiles("*.data");
            if (files.Length == 0)
            {
                CountinueButton.interactable = false;
            }
            else
            {
                CountinueButton.interactable = true;
            }
        }
    }

    public void CopyMapsFromResourses()
    {
        DirectoryInfo mapDir = new DirectoryInfo(Application.dataPath + "/Maps/");
        if (mapDir.GetFiles().Length == 0)
        {
            CopyMapFiles("map1");
            CopyMapFiles("map2");
            CopyMapFiles("map3");
        }
    }

    public void CopyMapFiles(string predicat)
    {
        string path = Application.dataPath + "/Maps/" + predicat;
        Directory.CreateDirectory(path);
        TextAsset mapConfig = Resources.Load<TextAsset>("Configs/Maps/" + predicat + "/" + predicat + "Config");
        TextAsset mapElements = Resources.Load<TextAsset>("Configs/Maps/" + predicat + "/" + predicat + "Elements");
        TextAsset mapUnder = Resources.Load<TextAsset>("Configs/Maps/" + predicat + "/" + predicat + "Under");
        TextAsset mapInfo = Resources.Load<TextAsset>("Configs/Maps/" + predicat + "/" + predicat + "Info");
        CreateConfigFile(path + "/" + predicat + "Config", mapConfig);
        CreateConfigFile(path + "/" + predicat + "Elements", mapElements);
        CreateConfigFile(path + "/" + predicat + "Under", mapUnder);
        CreateConfigFile(Application.dataPath + "/Maps/" + predicat + "Info", mapInfo);
    }

    public void CreateConfigFile(string filename, TextAsset text)
    {
        File.WriteAllText(filename + ".json", text.ToString());
    }
}