using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject DBObject;
    public GameObject WGObject;
    public GameObject ResUIObject;
    public GameObject EconomUIObject;
    public GameObject SocUIObject;
    public GameObject EcologUIObject;
    public Button NextMoveButtons;
    public GameObject PauseMenu;
    public GameObject SavingDialog;
    public GameObject LoadingDialog;
    public GameObject ExportDialog;
    public GameObject SettingsDialog;
    public GameObject FinalDialog;
    public InputField CreatingSave;

    private string stat_parametr;
    private bool pauseBool;
    private bool statWindowBool = false;
    private bool saveWindowBool = false;
    private bool loadWindowBool = false;
    private bool exportWindowBool = false;
    public bool isSaveItemDeSelected = false;
    public string choosedSave = String.Empty;
    public string saveName = String.Empty;
    public Dictionary<string, Color> paramDict = new Dictionary<string, Color>();
    public Dictionary<string, List<bool>> finDict = new Dictionary<string, List<bool>>();


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

        FillFinDict();
        //DontDestroyOnLoad(gameObject);
    }


    public void FillFinDict()
    {
        finDict.Add("toBudget", new List<bool> {false, false, false, false, false, false, false});
        finDict.Add("numJobs", new List<bool> {false, false, false, false, false, false, false});
        finDict.Add("income", new List<bool> {false, false, false, false, false, false, false});
        finDict.Add("profit", new List<bool> {false, false, false, false, false, false, false});
        finDict.Add("production", new List<bool> {false, false, false, false, false, false, false});
        finDict.Add("amortization", new List<bool> {false, false, false, false, false, false, false});
        finDict.Add("invest", new List<bool> {false, false, false, false, false, false, false});
        finDict.Add("capital", new List<bool> {false, false, false, false, false, false, false});
    }

    public void ShowStatView()
    {
        //List<int> valueList = new List<int>() {23,5,1,76,2,4,43,68,23,4,15,25};
        
        HideAllStatButtons();
        WGObject.SetActive(true);
        setStatWinBool(true);
        ResPressButton();
        //PressFishRes();
        // paramDict["fishAmount"] = Color.green;
        ShowGraph(paramDict);
    }

    public void CloseGraph()
    {
        WGObject.SetActive(false);
        setStatWinBool(false);
        //valueList[0]+=10;
    }

    public void EcologPressButton()
    {
        HideAllStatButtons();
        EcologUIObject.SetActive(true);
    }

    public void EconomPressButton()
    {
        HideAllStatButtons();
        EconomUIObject.SetActive(true);
    }

    public void ResPressButton()
    {
        HideAllStatButtons();
        ResUIObject.SetActive(true);
    }

    public void SocPressButton()
    {
        HideAllStatButtons();
        SocUIObject.SetActive(true);
    }

    public void HideAllStatButtons()
    {
        ResUIObject.SetActive(false);
        EcologUIObject.SetActive(false);
        EconomUIObject.SetActive(false);
        SocUIObject.SetActive(false);
    }

    public void ShowGraph(Dictionary<string, Color> paramDict)
    {
        //TODO fucntion which will be cath all checkbox from UI and color
        //paramDict["population"] = Color.green;
        //paramDict["fishAmount"] = Color.magenta;
        Window_graph script = WGObject.transform.Find("pfWindow_graph").GetComponent<Window_graph>();
        script.ShowGraph(paramDict);
    }

    public void PauseMenuCheck()
    {
        if (pauseBool == false && saveWindowBool == false)
        {
            PauseMenu.SetActive(true);
            pauseBool = true;
        }
        else
        {
            pauseBool = false;
            PauseMenu.SetActive(false);
        }
    }

    public void pressExportData()
    {
        if (getStatWinBool() && !getExportWinBool())
        {
            ExportDialog.SetActive(true);
            setExportWinBool(true);
            setPauseBool(false);
        }
        else
        {
            if (getStatWinBool() && getExportWinBool())
            {
                ExportDialog.SetActive(false);
                setExportWinBool(false);
            }
        }
    }

    public void MenuPressCountinueButton()
    {
        pauseBool = false;
        PauseMenu.SetActive(false);
    }

    public void MenuPressSaveButton()
    {
        pauseBool = false;
        saveWindowBool = true;
        PauseMenu.SetActive(false);
        SavingDialog.SetActive(true);
    }

    public void MenuPressLoadButton()
    {
        pauseBool = false;
        loadWindowBool = true;
        PauseMenu.SetActive(false);
        LoadingDialog.SetActive(true);
    }

    public void MenuPressSettingButton()
    {
        pauseBool = false;
        PauseMenu.SetActive(false);
        SettingsDialog.SetActive(true);
    }

    public void MenuPressExitMenuButton()
    {
        GameManager.instance.gameStartFlag = false;
        if (Basket.instance.modeType == "NEW")
        {
            Basket.instance.mapType = String.Empty;
            Basket.instance.modeType = String.Empty;
        }
        else
        {
            Basket.instance.mapType = String.Empty;
            Basket.instance.modeType = String.Empty;
            Basket.instance.saveData.Clear();
        }

        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void MenuPressExitDeskButton()
    {
        Application.Quit();
    }

    public void SettingDialogPressClose()
    {
        SettingsDialog.SetActive(false);
    }

    public void setPauseBool(bool new_bool)
    {
        pauseBool = new_bool;
    }

    public void setSaveWinBool(bool new_bool)
    {
        saveWindowBool = new_bool;
    }

    public void setLoadWinBool(bool new_bool)
    {
        loadWindowBool = new_bool;
    }

    public void setExportWinBool(bool new_bool)
    {
        exportWindowBool = new_bool;
    }

    public bool getExportWinBool()
    {
        return exportWindowBool;
    }

    public void setStatWinBool(bool new_bool)
    {
        statWindowBool = new_bool;
    }

    public bool getStatWinBool()
    {
        return statWindowBool;
    }

    public bool getPauseBool()
    {
        return pauseBool;
    }
}