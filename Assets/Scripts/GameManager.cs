using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Newtonsoft.Json;

using System.Collections.Generic;		//Allows us to use Lists. 
//using UnityEngine.UI;					//Allows us to use UI.

public class GameManager : MonoBehaviour
{
	
	public int currentYear;
	private DB DBScript;
	//private BoardManager BoardScript;
	//public bool enable;


	private string configJSON = "Assets/Configs/config2.json";
	private string configMapJSON = "Assets/Configs/config2Map.json";
	
	
	//Awake is always called before any Start functions
	void Awake() // here was Awake
	{

		DBScript = GetComponent<DB>();
		//BoardScript = GetComponent<BoardManager>();
		InitGame();
	}

	//This is called each time a scene is loaded.

	
	//Initializes the game for each level.
	void InitGame()
	{
		currentYear=0;
		DBScript.InitDB(configJSON);
		DBScript.InitBoard(configMapJSON);
		currentYear=1;
	}

	void CheckGameOver()
	{
		if(currentYear > 19) 
		{
			enabled = false;
		}
	}

	void Update() 
	{
		CheckGameOver();
		bool down = Input.GetKeyDown(KeyCode.Space);
		if(down)
		{
			Debug.Log("Check");
			DBScript.AbsCalc(currentYear);
			DBScript.MapCalc(currentYear);
			currentYear +=1;
		}
		
		
	}
	
}
