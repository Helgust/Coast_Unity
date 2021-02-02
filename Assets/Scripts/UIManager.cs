using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject DBObject; 
    public GameObject WGObject;
    public GameObject ResUIObject;
    public GameObject EconomUIObject;
    public GameObject SocUIObject;
    public GameObject EcologUIObject;
    
    
    public GameObject NextMoveButtons;
    public GameObject ShowGraphButtons;
    public GameObject PauseMenu;
    
    private string stat_parametr;

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
    
    public void PressCountinueButton()
    {
        PauseMenu.SetActive(false);
        
    }
    public void PressSaveButton()
    {
        
        
    }
    public void PressSettingButton()
    {
        
        
    }
    public void PressExitMenuButton()
    {
        
        
    }
    public void PressExitDeskButton()
    {
        
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
