using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public GameObject NextMoveButtons;
    public GameObject PauseMenu;
    public GameObject SavingDialog;
    public GameObject LoadingDialog;
    public GameObject ExportDialog;
    public InputField CreatingSave;

    private string stat_parametr;
    private bool pauseBool;
    private bool statWindowBool = false;
    private bool saveWindowBool = false;
    private bool exportWindowBool = false;
    public bool isSaveItemDeSelected = false;
    public string choosedSave = String.Empty;
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

        //DontDestroyOnLoad(gameObject);
    }
    
    
    public void ShowStatView()
    { 
        //List<int> valueList = new List<int>() {23,5,1,76,2,4,43,68,23,4,15,25};

        HideAllStatButtons();
        WGObject.SetActive(true);
        setStatWinBool(true);
        ResPressButton();
            //PressFishRes();
        ShowGraph("fishAmount");

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

    public void ShowGraph(string param)
    {
        List<float> valueList = new List<float>();
        valueList = DBObject.GetComponent<DB>().GetValueStatList(param);
        Window_graph script = WGObject.transform.Find("pfWindow_graph").GetComponent<Window_graph>();
        script.ShowGraph(valueList,Color.green);
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
        if (getStatWinBool()&&!getExportWinBool())
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
    
    public void MenuPressSettingButton()
    {

    }
    public void MenuPressExitMenuButton()
    {
        Basket.instance.mapType = String.Empty;
        Basket.instance.modeType = String.Empty;
        //savedata empty
    }
    public void MenuPressExitDeskButton()
    {
        
    }

    public void setPauseBool(bool new_bool)
    {
        pauseBool = new_bool;
    }
    public void setSaveWinBool(bool new_bool)
    {
        saveWindowBool = new_bool;
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
