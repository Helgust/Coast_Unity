using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadDialog : MonoBehaviour
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


    private void OnEnable()
    {
        deleteButton.interactable = false;
        MapNameText.text = String.Empty;
        SaveNameText.text = String.Empty;
    }

    // Start is called before the first frame update
    private void LoadProcess(string filename,int forUI = 0)
    {
        string path = Application.dataPath +"/Save/" + filename;

        if (File.Exists(path))
        {
           
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Save data = bf.Deserialize(fileStream) as Save;
            if (forUI != 1)
            {
                GameManager.instance.LoadFromSave(data);
            }
            SaveNameText.text = data.saveName;
            MapNameText.GetComponent<LocalizedText>().LocalizationKey = "NewGame."+data.mapType;
            MapNameText.text = data.mapType;
            MapNameText.GetComponent<LocalizedText>().Start();
            fileStream.Close();
        }
    }
    private string GetCurrentUserNameDateTime()
    {
        return Environment.MachineName + DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy-hh-dd-ss");
    }

    public void PressLoad()
    {
        GameUIManager.instance.setSaveWinBool(false);
        LoadProcess(GameUIManager.instance.choosedSave);
        GameUIManager.instance.setPauseBool(false);
        ExistSaveList.SetActive(false);
        ExistSaveList.SetActive(true);
        GameUIManager.instance.setLoadWinBool(false);
        GameUIManager.instance.setPauseBool(false);
        GameUIManager.instance.LoadingDialog.SetActive(false);
    }
    public void PressDelete()
    {
        if (GameUIManager.instance.choosedSave != null && GameUIManager.instance.choosedSave.EndsWith(".data"))
        {
            File.Delete(Application.dataPath + "/Save/" + GameUIManager.instance.choosedSave);
        }
        ExistSaveList.SetActive(false);
        GameUIManager.instance.choosedSave = String.Empty;
        ExistSaveList.SetActive(true);
    }

    public void PressCancel()
    {
        GameUIManager.instance.setLoadWinBool(false);
        GameUIManager.instance.setPauseBool(false);
        GameUIManager.instance.LoadingDialog.SetActive(false);
    }
    
    public void PressOnSaveItem()
    {
        //Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
        GameUIManager.instance.choosedSave = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        LoadProcess(GameUIManager.instance.choosedSave, 1);
        deleteButton.interactable = true;
        GameUIManager.instance.isSaveItemDeSelected = false;

    }
}
