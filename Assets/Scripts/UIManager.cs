using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum UIState
    {
        Game,Menu
    }
    
    public static UIManager instance;
    public UIState curUIState;
    public GameObject MenuUI;
    public GameObject GameUI;
    public GameObject GameManager;
    public GameObject InputHandler;


    private void Awake()
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
        curUIState = UIState.Menu;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (curUIState)
        {
            case UIState.Game:
            {
                GameUI.SetActive(true);
                MenuUI.SetActive(false);
                break;
            }

            case UIState.Menu:
            {
                GameUI.SetActive(false);
                MenuUI.SetActive(true);
                InputHandler.SetActive(false);
                break;    
            }
            default:
            break;
                
        }
    }
}
