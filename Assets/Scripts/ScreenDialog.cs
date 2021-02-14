using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDialog : MonoBehaviour
{
    public InputField inputField;
    public GameObject saveList;
    private GameObject SavingDiag;
    private List<GameObject> _gameObjectList;
    private GameObject SaveItemGameObject;
    private RectTransform grid;
    private RectTransform savelistRectTransform;
    

    private void Awake()
    {
        savelistRectTransform = saveList.GetComponent<RectTransform>();
        _gameObjectList = new List<GameObject>();
    }

    private void OnEnable()
    {
        foreach (GameObject gameObject in _gameObjectList)
        {
            Destroy(gameObject);
        }
        _gameObjectList.Clear();
        grid = saveList.transform.Find("grid").GetComponent<RectTransform>();
        SaveItemGameObject = grid.Find("SaveItemButton Template").gameObject;
        
        inputField.text = GetCurrentUserNameDateTime();
        ScanSaveloc();
    }


    // Start is called before the first frame update
    private void SaveProcess()
    {
        Save save = GameManager.instance.CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        //FileStream fileStream = File.Create(Application.dataPath + "/Save/" + save.saveName + ".data");
        FileStream fileStream = File.Create(Application.dataPath + "/Save/" +save.saveName+ ".data");
        bf.Serialize(fileStream,save);
        fileStream.Close();
    }
    private string GetCurrentUserNameDateTime()
    {
        return Environment.MachineName + DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy-hh-dd-ss");
    }

    private void ScanSaveloc()
    {
        string path = Application.dataPath + "/Save/";
        if (!Directory.Exists (path))
        {
            Debug.Log("Dir not exist: " + path);
            Directory.CreateDirectory(path);
            
        }
        

        string[] dirs = Directory.GetFiles(path,"*.data");
        for (int i = 0; i < dirs.Length; i++)
        {
            GameObject save_item = Instantiate(SaveItemGameObject, grid, false);
            _gameObjectList.Add(save_item);
            save_item.GetComponentInChildren<Text>().text = CutText(dirs[i]);
            save_item.SetActive(true);
        }

    }

    private string CutText(string text)
    {
        int ind = text.LastIndexOf('/');
        return text.Substring(ind+1);
    }

    public void PressSave()
    {
        UIManager.instance.setSaveWinBool(false);
        SaveProcess();
        UIManager.instance.setPauseBool(false);
        UIManager.instance.SavingDialog.SetActive(false);
    }

    public void PressCancel()
    {
        UIManager.instance.setSaveWinBool(false);
        UIManager.instance.setPauseBool(false);
        UIManager.instance.SavingDialog.SetActive(false);
    }
    

}
