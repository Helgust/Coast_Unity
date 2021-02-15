using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    public InputField CreatingSave;

    private string stat_parametr;
    private bool pauseBool;
    private bool saveWindowBool = false;
    public bool isSaveDeSelected = false;
    public string choosedSave = String.Empty;

    

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

        DontDestroyOnLoad(gameObject);
    }
    
    
    public void ShowStatView()
    { 
        //List<int> valueList = new List<int>() {23,5,1,76,2,4,43,68,23,4,15,25};

        HideAllStatButtons();
        WGObject.SetActive(true);
        ResPressButton();
        PressFishRes();

    }
    
    public void CloseGraph()
    {
        WGObject.SetActive(false);
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

    public void PressFishRes()
    {
        stat_parametr = "fishAmount";
        ShowGraph(stat_parametr);
        
    }
    public void PressPopRes()
    {
        stat_parametr = "population";
        ShowGraph(stat_parametr);
        
    }
    
    public void PressBudgetRes()
    {
        stat_parametr = "budget";
        ShowGraph(stat_parametr);
        
    }
    public void PressIncPerCapitaRes()
    {
        stat_parametr = "incomeSumPerHum";
        ShowGraph(stat_parametr);
        
    }
    public void PressQualityOfEnvRes()
    {
        stat_parametr = "qualityOfEnv";
        ShowGraph(stat_parametr);
        
    }
    public void PressHumDevIndRes()
    {
        stat_parametr = "humDevInd";
        ShowGraph(stat_parametr);
        
    }

    public void ShowGraph(string param)
    {
        List<float> valueList = new List<float>();
        valueList = DBObject.GetComponent<DB>().GetValueStatList(param);
        Window_graph script = WGObject.transform.Find("pfWindow_graph").GetComponent<Window_graph>();
        script.ShowGraph(valueList);
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
    public bool getPauseBool()
    {
        return pauseBool;
    }

}
