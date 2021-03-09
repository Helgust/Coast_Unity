using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine.UI;

using System.Collections.Generic;//Allows us to use Lists. 

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
    public bool ShiftBool;
    public bool CtrlBool;

    public int currentYear;
    public int mapType = 1;

    public int finalYear;
    private DB DBScript;
    private BoardManager BoardScript;

    public GameObject IHObject;
    public GameObject DBObject;
    public GameObject UIObject;
    private InputHandler IHScript;


    //public bool enable;


    private TextAsset configJSON;
    private TextAsset configMapJSON;
    private TextAsset configBGJSON;

    void GetConfig()
    {
	    configJSON = Resources.Load <TextAsset> ("Configs/config2");
	    configMapJSON = Resources.Load <TextAsset> ("Configs/config2Map");
	    configBGJSON = Resources.Load <TextAsset> ("Configs/config2BG");
    }


    //Awake is always called before any Start functions
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
	    
	    GetConfig();
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

     void Update() 
	{
		
	} 

    

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
            UIObject.GetComponent<UIManager>().NextMoveButtons.SetActive(false);
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
    
    public Save CreateSaveGameObject()
    {
	    Save save = new Save();
	    save.currentYear = GameManager.instance.currentYear;
	    save.saveName = UIManager.instance.CreatingSave.text;
	    save.mapType = mapType;
	    save.Listofyears = DBObject.GetComponent<DB>().yearDataBase;
	    save.statDict = DBObject.GetComponent<DB>().statDict;
	    save.board = DBObject.GetComponent<DB>().board;
	    save.boardBG = DBObject.GetComponent<DB>().boardBG;
	    save.is_over = DBObject.GetComponent<DB>().is_over;
	    return save;
    }

    public void LoadFromSave(Save new_save)
    {
	    Time.timeScale = 0;
	    if (DBScript.yearDataBase.Count == 0)
	    {
		    DBScript.yearDataBase.Clear();
		    DBScript.yearDataBase = new_save.Listofyears;
		    DBScript.statDict = new_save.statDict;
	    }
	    else
	    {
		    Debug.Log("Enter2");
		    
		    Destroy(GameObject.FindWithTag("gameBoardBG"));
		    Destroy(GameObject.FindWithTag("gameBoard"));

		    
		    DBScript.yearDataBase.Clear();
		    DBScript.statDict.Clear();
		    
		    GameManager.instance.currentYear = new_save.currentYear;
		    DBScript.yearDataBase = new_save.Listofyears;
		    DBScript.statDict = new_save.statDict;
		    DBScript.boardBG = new_save.boardBG;
		    DBScript.board = new_save.board;
		    DBScript.is_over = new_save.is_over;
		    
		    DBScript.board.array2d.Reverse();
		    BoardScript.SetupBGScene(DBScript.boardBG);
		    BoardScript.SetupScene(DBScript.board);
		    GameObject.FindWithTag("gameBoardBG").SetActive(false);
		    //todo 
	    }
	    
    }
    

}
