using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveDialog : MonoBehaviour
{
    public InputField inputField;
    public GameObject ExistSaveList;
    public Button deleteButton;
    private GameObject SavingDiag;
    private List<GameObject> _gameObjectList;
    private GameObject SaveItemGameObject;
    private RectTransform grid;
    private RectTransform savelistRectTransform;

    private void Update()
    {
        if (GameUIManager.instance.isSaveItemDeSelected == true)
        {
            deleteButton.interactable = false;
        }
    }

    private void OnEnable()
    {
        inputField.text = GetCurrentUserNameDateTime();
        deleteButton.interactable = false;
    }

    // Start is called before the first frame update
    private void SaveProcess()
    {
        Save save = GameManager.instance.CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath + "/Save/" +save.saveName+ ".data");
        bf.Serialize(fileStream,save);
        fileStream.Close();
    }
    private string GetCurrentUserNameDateTime()
    {
        return Environment.UserName+"_"+ DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy-hh-dd-ss");
    }

    public void PressSave()
    {
        GameUIManager.instance.setSaveWinBool(false);
        SaveProcess();
        GameUIManager.instance.setPauseBool(false);
        ExistSaveList.SetActive(false);
        ExistSaveList.SetActive(true);
    }
    public void PressDelete()
    {
        if (GameUIManager.instance.choosedSave != null && GameUIManager.instance.choosedSave.EndsWith(".data"))
        {
            File.Delete(Application.dataPath + "/Save/" + GameUIManager.instance.choosedSave);
        }
        ExistSaveList.SetActive(false);
        GameUIManager.instance.choosedSave = string.Empty;
        ExistSaveList.SetActive(true);
    }

    public void PressCancel()
    {
        GameUIManager.instance.setSaveWinBool(false);
        GameUIManager.instance.setPauseBool(false);
        GameUIManager.instance.SavingDialog.SetActive(false);
    }
    
    public void PressOnSaveItem()
    {
        GameUIManager.instance.choosedSave = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        deleteButton.interactable = true;
        GameUIManager.instance.isSaveItemDeSelected = false;
    }
}
