using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

using System.Collections.Generic;		//Allows us to use Lists. 
//using UnityEngine.UI;					//Allows us to use UI.

public class GameManager : MonoBehaviour
{
	
	private YearsDB DBScript;

	private string configJSON = "Assets/Configs/config1.json";
	
	
	//Awake is always called before any Start functions
	void Awake() // here was Awake
	{

		DBScript = GetComponent<YearsDB>();
		//InitGame();
	}

	//This is called each time a scene is loaded.

	
	//Initializes the game for each level.
	void InitGame()
	{
		DBScript.InitDB(configJSON);
	}

	void Update() 
	{
		bool down = Input.GetKeyDown(KeyCode.Space);
		if (down)
		{
			Debug.Log("CHECK");
		}
	}
	
}
