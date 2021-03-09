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
        if (UIManager.instance.isSaveItemDeSelected == true)
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
        return Environment.MachineName + DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy-hh-dd-ss");
    }

    public void PressSave()
    {
        UIManager.instance.setSaveWinBool(false);
        SaveProcess();
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
        UIManager.instance.choosedSave = string.Empty;
        ExistSaveList.SetActive(true);
    }

    public void PressCancel()
    {
        UIManager.instance.setSaveWinBool(false);
        UIManager.instance.setPauseBool(false);
        UIManager.instance.SavingDialog.SetActive(false);
    }
    
    public void PressOnSaveItem()
    {
        UIManager.instance.choosedSave = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        deleteButton.interactable = true;
        UIManager.instance.isSaveItemDeSelected = false;
    }
}
