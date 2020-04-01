using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

using System.Collections.Generic;		//Allows us to use Lists. 
//using UnityEngine.UI;					//Allows us to use UI.

public class GameManager : MonoBehaviour
{
	
	public int currentYear;
	private YearsDB DBScript;
	//public bool enable;


	private string configJSON = "Assets/Configs/config2.json";
	
	
	//Awake is always called before any Start functions
	void Awake() // here was Awake
	{

		DBScript = GetComponent<YearsDB>();
		InitGame();
	}

	//This is called each time a scene is loaded.

	
	//Initializes the game for each level.
	void InitGame()
	{
		currentYear=0;
		DBScript.InitDB(configJSON);
		currentYear=1;
		//DBScript.PreGameCalc();
	}

	void CheckGameOver()
	{
		if(currentYear > 3) 
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
			currentYear +=1;
		}
		
		
	}
	
}
