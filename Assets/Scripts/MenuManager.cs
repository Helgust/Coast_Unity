using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public GameObject LoadingDialog;
    public GameObject ChoosingMapDialog;
    public GameObject SettingsDialog;
    public GameObject MainMenu;
    public Button StartButton;
    public Toggle Map1Toggle;
    public Toggle Map2Toggle;
    public Toggle Map3Toggle;

    private string stat_parametr;
    private bool pauseBool;
    private bool saveWindowBool = false;
    public bool isSaveItemDeSelected = false;
    public string saveName = String.Empty;

    void Awake() // here was Awake
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (Basket.instance.mapType == String.Empty)
        {
            StartButton.interactable = false;
        }
        else
        {
            StartButton.interactable = true;
        }
    }

    public void MMPressContinue()
    {
        DateTime last_modif_time = DateTime.MinValue;
        String filename =String.Empty;
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
        string path = Application.dataPath +"/Save/" + filename;

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
    
    public void ChoosedMap1()
    {
        if (Map1Toggle.isOn)
        {
            Basket.instance.mapType = "map1";
            Map2Toggle.SetIsOnWithoutNotify(false);
            Map3Toggle.SetIsOnWithoutNotify(false);
        }
        else
        {
            Basket.instance.mapType = String.Empty;
        }
        
    }
    public void ChoosedMap2()
    {
        if (Map2Toggle.isOn)
        {
            Basket.instance.mapType = "map2";
            Map1Toggle.SetIsOnWithoutNotify(false);
            Map3Toggle.SetIsOnWithoutNotify(false);
        }
        else
        {
            Basket.instance.mapType = String.Empty;
        }
        
    }
    public void ChoosedMap3()
    {
        if (Map3Toggle.isOn)
        {
            Basket.instance.mapType = "map3";
            Map1Toggle.SetIsOnWithoutNotify(false);
            Map2Toggle.SetIsOnWithoutNotify(false);
        }
        else
        {
            Basket.instance.mapType = String.Empty;
        }
        
    }
    
    
    
    public void MapDialogPressCancel()
    {
        Basket.instance.mapType = String.Empty;
        ChoosingMapDialog.SetActive(false);
    }
    public void MapDialogPressStart()
    {
        Basket.instance.modeType = "NEW";
        SceneManager.LoadScene("Scenes/SampleScene");
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
}
