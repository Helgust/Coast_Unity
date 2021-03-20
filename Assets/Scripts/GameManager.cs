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
	    DB.instance = DBObject.GetComponent<DB>();
        BoardScript = GetComponent<BoardManager>();
        IHScript = IHObject.GetComponent<InputHandler>();
        InitGame();
    }

    //This is called each time a scene is loaded.


    //Initializes the game for each level.
    void InitGame()
    {
        currentYear = 0;
        DB.instance.InitDB(configJSON, finalYear);
        DB.instance.InitBoard(configMapJSON);
        DB.instance.InitBG(configBGJSON);
        BoardScript.SetupBGScene(DB.instance.boardBG);
        BoardScript.SetupScene(DB.instance.board);
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
        Debug.Log("IS_OVER: " + DB.instance.is_over);
        if ((currentYear > finalYear - 1) || (DB.instance.is_over == true))
        {
	        enabled = false;
            UIObject.GetComponent<UIManager>().NextMoveButtons.SetActive(false);
        }
        else
        {
            List<float> UIText = IHScript.FromUIToDB();

            //PrintList(UIText);
            DB.instance.NextMoveDB(currentYear, UIText);
            currentYear += 1;
            Destroy(GameObject.FindWithTag("gameBoard"));
            BoardScript.SetupScene(DB.instance.board);
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
	    if (DB.instance.yearDataBase.Count == 0)
	    {
		    DB.instance.yearDataBase.Clear();
		    DB.instance.yearDataBase = new_save.Listofyears;
		    DB.instance.statDict = new_save.statDict;
	    }
	    else
	    {
		    Debug.Log("Enter2");
		    
		    Destroy(GameObject.FindWithTag("gameBoardBG"));
		    Destroy(GameObject.FindWithTag("gameBoard"));

		    
		    DB.instance.yearDataBase.Clear();
		    DB.instance.statDict.Clear();
		    
		    GameManager.instance.currentYear = new_save.currentYear;
		    DB.instance.yearDataBase = new_save.Listofyears;
		    DB.instance.statDict = new_save.statDict;
		    DB.instance.boardBG = new_save.boardBG;
		    DB.instance.board = new_save.board;
		    DB.instance.is_over = new_save.is_over;
		    
		    DB.instance.board.array2d.Reverse();
		    BoardScript.SetupBGScene(DB.instance.boardBG);
		    BoardScript.SetupScene(DB.instance.board);
		    GameObject.FindWithTag("gameBoardBG").SetActive(false);
		    //todo 
	    }
	    
    }
    

}
