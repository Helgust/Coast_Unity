using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine.UI;

using System.Collections.Generic;		//Allows us to use Lists. 

public class GameManager : MonoBehaviour
{
    public bool ShiftBool;
    public bool CtrlBool;

    public int currentYear;

    public int finalYear;
    private DB DBScript;
    private BoardManager BoardScript;

    public GameObject IHObject;
    public GameObject DBObject;
    public GameObject WGObject;
    public GameObject ResUIObject;
    public GameObject EconomUIObject;
    public GameObject SocUIObject;
    public GameObject EcologUIObject;

    public GameObject NextMoveButtons;
    public GameObject ShowGraphButtons;
    

    private InputHandler IHScript;
    private string stat_parametr;

    //public bool enable;


    private string configJSON = "Assets/Configs/config2.json";
    private string configMapJSON = "Assets/Configs/config2Map.json";
     private string configBGJSON = "Assets/Configs/config2BG.json";



    //Awake is always called before any Start functions
    void Awake() // here was Awake
    {

        DBScript = DBObject.GetComponent<DB>();
        BoardScript = GetComponent<BoardManager>();
        IHScript = IHObject.GetComponent<InputHandler>();
        InitGame();
    }

    //This is called each time a scene is loaded.


    //Initializes the game for each level.
    void InitGame()
    {
        currentYear = 0;
        DBScript.InitDB(configJSON, finalYear);
        DBScript.InitBoard(configMapJSON);
        DBScript.InitBG(configBGJSON);
        BoardScript.SetupBGScene(DBScript.boardBG);
        BoardScript.SetupScene(DBScript.board);
        IHScript.InitTextUI();
        currentYear = 1;
    }

    void CheckGameOver()
    {

    }

    /* void Update() 
	{
		//bool down = Input.GetKeyDown(KeyCode.Space);
		if(currentYear > finalYear - 1 )
		{
			enabled = false;
			NextMoveButtons.SetActive(false);
		}
		else
		{
			DBScript.AbsCalc(currentYear);
			DBScript.MapCalc(currentYear);
			currentYear +=1;
			Destroy(GameObject.FindWithTag("gameBoard"));
			BoardScript.SetupScene(DBScript.board);
		}
		
		
	}  */

    private void PrintList(List<int> L)
    {
        Debug.Log("--------");
        for (int i = 0; i < L.Count; i++)
        {
            Debug.Log(L[i]);
        }
        Debug.Log("--------");

    }
    public void NextMove()
    {
        Debug.Log("IS_OVER: " + DBScript.is_over);
        if ((currentYear > finalYear - 1) || (DBScript.is_over == true))
        {
            enabled = false;
            NextMoveButtons.SetActive(false);
        }
        else
        {
            List<float> UIText = IHScript.FromUIToDB();

            //PrintList(UIText);
            DBScript.NextMoveDB(currentYear, UIText);
            currentYear += 1;
            Destroy(GameObject.FindWithTag("gameBoard"));
            BoardScript.SetupScene(DBScript.board);
            IHScript.InitNextMove();
        }

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
        valueList = DBScript.GetValueStatList(param);
        Window_graph script = WGObject.transform.Find("pfWindow_graph").GetComponent<Window_graph>();
        script.ShowGraph(valueList);
    }
    

}
