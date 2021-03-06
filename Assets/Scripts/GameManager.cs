﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using Assets.SimpleLocalization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool ShiftBool;
    public bool CtrlBool;
    
    public int currentYear;
    public string mapType = String.Empty;

    public int finalYear;

    //public bool inMainMenuState;
    private BoardManager BoardScript;

    public GameObject IHObject;
    public GameObject DBObject;
    public GameObject UIObject;
    private InputHandler IHScript;


    //public bool enable;
    private string configJSON;
    private string configMapJSON;
    private string configBGJSON;

    void GetConfig()
    {
        //Debug.Log("DEBUG"+Application.dataPath+"/Maps/" + Basket.instance.mapData.mapConfig);
        configJSON = File.ReadAllText(Application.dataPath+"/Maps/" + Basket.instance.mapData.mapConfig+".json");
        configMapJSON = File.ReadAllText(Application.dataPath+"/Maps/" + Basket.instance.mapData.mapElementsConfig+".json");
        configBGJSON = File.ReadAllText(Application.dataPath+"/Maps/" + Basket.instance.mapData.mapUnderConfig+".json");
        mapType = Basket.instance.mapData.name;
    }


    //Awake is always called before any Start functions
    void Awake() // here was Awake
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        //gameStartFlag = false;
        //DontDestroyOnLoad(gameObject);
        UIManager.instance.InputHandler.SetActive(true);
        BoardScript = GetComponent<BoardManager>();
        IHScript = UIManager.instance.InputHandler.GetComponent<InputHandler>();
        if (Basket.instance.modeType == "LOAD")
        {
            instance.LoadFromSave(Basket.instance.saveData);
        }
        else // modeType == "NEW"
        {
            GetConfig();
            InitGame();
        }

        //inMainMenuState = true;
    }

    //This is called each time a scene is loaded.
    private void Start()
    {
        
    }

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
        UIManager.instance.InputHandler.SetActive(true);
    }

    void CheckGameOver()
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
        if ((currentYear > finalYear - 1))
        {
            enabled = false;
            GameUIManager.instance.NextMoveButtons.interactable = false;
            GameUIManager.instance.FinalDialogText.GetComponent<LocalizedText>().LocalizationKey = "Final.GameOver1";
            GameUIManager.instance.FinalDialog.SetActive(true);
        }
        else if (DB.instance.is_over)
        {
            enabled = false;
            GameUIManager.instance.NextMoveButtons.interactable = false;
            GameUIManager.instance.FinalDialogText.GetComponent<LocalizedText>().LocalizationKey = "Final.GameOver2";
            GameUIManager.instance.FinalDialog.SetActive(true);
        }
        else
        {
            List<float> UIText = IHScript.FromUIToDB();
            DB.instance.NextMoveDB(currentYear, UIText);
            currentYear += 1;
            Destroy(GameObject.FindWithTag("gameBoard"));
            BoardScript.SetupScene(DB.instance.board);
            IHScript.InitNextMove();
            InputHandler.instance.ChangeUiTextParams();
        }
    }

    public Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.currentYear = GameManager.instance.currentYear;
        save.saveName = GameUIManager.instance.CreatingSave.text;
        save.mapType = mapType;
        save.Listofyears = DB.instance.yearDataBase;
        save.statDict = DB.instance.statDict;
        save.board = DB.instance.board;
        save.boardBG = DB.instance.boardBG;
        save.is_over = DB.instance.is_over;
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

            //DB.instance.board.array2d.Reverse();
            BoardScript.SetupBGScene(DB.instance.boardBG);
            BoardScript.SetupScene(DB.instance.board);
            GameObject.FindWithTag("gameBoardBG").SetActive(true);
            //todo 
        }
    }
}