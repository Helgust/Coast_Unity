using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

    private void Update()
    {
        if (UIManager.instance.isSaveItemDeSelected == true)
        {
            deleteButton.interactable = false;
        }
        
    }

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
        UIManager.instance.setSaveWinBool(false);
        LoadProcess(UIManager.instance.choosedSave);
        UIManager.instance.setPauseBool(false);
        ExistSaveList.SetActive(false);
        ExistSaveList.SetActive(true);
    }
    public void PressDelete()
    {
        if (UIManager.instance.choosedSave != null && UIManager.instance.choosedSave.EndsWith(".data"))
        {
            File.Delete(Application.dataPath + "/Save/" + UIManager.instance.choosedSave);
        }
        ExistSaveList.SetActive(false);
        UIManager.instance.choosedSave = String.Empty;
        ExistSaveList.SetActive(true);
    }

    public void PressCancel()
    {
        UIManager.instance.setSaveWinBool(false);
        UIManager.instance.setPauseBool(false);
        UIManager.instance.LoadingDialog.SetActive(false);
    }
    
    public void PressOnSaveItem()
    {
        //Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
        UIManager.instance.choosedSave = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        LoadProcess(UIManager.instance.choosedSave, 1);
        deleteButton.interactable = true;
        UIManager.instance.isSaveItemDeSelected = false;

    }
}
