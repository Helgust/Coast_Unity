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
	    save.saveName = UIManager.instance.CreatingSave.text;
	    save.mapType = GameManager.instance.mapType;
	    save.Listofyears = DBObject.GetComponent<DB>().yearDataBase;
	    save.statDict = DBObject.GetComponent<DB>().statDict;
	    return save;
    }
}
