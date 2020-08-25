using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine.UI;

using System.Collections.Generic;		//Allows us to use Lists. 
//using UnityEngine.UI;					//Allows us to use UI.

public class GameManager : MonoBehaviour
{
	public int currentYear;
	
   	public int finalYear;
	private DB DBScript;
	private BoardManager BoardScript;
	
	public GameObject IHObject;
	
	public GameObject NextMoveButtons;

	private InputHandler IHScript;
	
	//public bool enable;


	private string configJSON = "Assets/Configs/config2.json";
	private string configMapJSON = "Assets/Configs/config2Map.json"; 
	
	
	//Awake is always called before any Start functions
	void Awake() // here was Awake
	{

		DBScript = GetComponent<DB>();
		BoardScript = GetComponent<BoardManager>();
		IHScript = IHObject.GetComponent<InputHandler>();
		InitGame();
	}

	//This is called each time a scene is loaded.

	
	//Initializes the game for each level.
	void InitGame()
	{
		currentYear=0;
		DBScript.InitDB(configJSON,finalYear);
		DBScript.InitBoard(configMapJSON);
		BoardScript.SetupScene(DBScript.board);
		currentYear=1;
	}

	void CheckGameOver()
	{

	}

	/*  void Update() 
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
		for (int i=0; i < L.Count; i++)
		{
			Debug.Log(L[i]);
		}
		Debug.Log("--------");
		
	}
	public void NextMove()
	{
		Debug.Log("IS_OVER: " + DBScript.is_over);
		if((currentYear > finalYear - 1 ) || (DBScript.is_over == true)  )
		{
			enabled = false;
			NextMoveButtons.SetActive(false);
		}
		else
		{
			List<int> UIText = IHScript.FromUIToDB();

			//PrintList(UIText);
			DBScript.NextMoveDB(currentYear,UIText);
			currentYear +=1;
			Destroy(GameObject.FindWithTag("gameBoard"));
			BoardScript.SetupScene(DBScript.board);
		}
		
	}
	
}
