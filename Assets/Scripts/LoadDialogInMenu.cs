using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadDialogInMenu : MonoBehaviour
{
    public Text MapNameText;
    public Text SaveNameText;
    public GameObject ExistSaveList;
    public Button deleteButton;
    private GameObject LoadingDiag;
    private List<GameObject> _gameObjectList;
    private GameObject SaveItemGameObject;
    private RectTransform grid;
    private RectTransform savelistRectTransform;

    private void Update()
    {
        
        // if (UIManager.instance.isSaveItemDeSelected == true)
        // {
        //     deleteButton.interactable = false;
        // }
        
    }

    private void OnEnable()
    {
        deleteButton.interactable = false;
        MapNameText.text = String.Empty;
        SaveNameText.text = String.Empty;
    }

    // Start is called before the first frame update
    private void LoadProcessFromMenu(string filename,int forUI = 0)
    {
        string path = Application.dataPath +"/Save/" + filename;

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Save data = bf.Deserialize(fileStream) as Save;
            if (forUI != 1)
            {
                Basket.instance.modeType = "LOAD";
                Basket.instance.saveData = data;
                //GameManager.instance.LoadFromSave(data);
                SceneManager.LoadScene("Scenes/SampleScene");
            }
            SaveNameText.text = data.saveName;
            MapNameText.text = data.mapType.ToString();
            fileStream.Close();
        }
    }
    private string GetCurrentUserNameDateTime()
    {
        return Environment.MachineName + DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy-hh-dd-ss");
    }

    public void PressLoad()
    {
        MenuManager.instance.setSaveWinBool(false);
        LoadProcessFromMenu(MenuManager.instance.saveName);
        ExistSaveList.SetActive(false);
        ExistSaveList.SetActive(true);
        UIManager.instance.curUIState = UIManager.UIState.Game;
    }
    public void PressDelete()
    {
        if (MenuManager.instance.saveName != null && MenuManager.instance.saveName.EndsWith(".data"))
        {
            File.Delete(Application.dataPath + "/Save/" + MenuManager.instance.saveName);
        }
        ExistSaveList.SetActive(false);
        MenuManager.instance.saveName = String.Empty;
        ExistSaveList.SetActive(true);
    }

    public void PressCancel()
    {
        //UIManager.instance.setSaveWinBool(false);
        //UIManager.instance.setPauseBool(false);
        MenuManager.instance.LoadingDialog.SetActive(false);
    }
    
    public void PressOnSaveItem()
    {
        //Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
        MenuManager.instance.saveName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        LoadProcessFromMenu(MenuManager.instance.saveName, 1);
        deleteButton.interactable = true;
        MenuManager.instance.isSaveItemDeSelected = false;

    }
}
