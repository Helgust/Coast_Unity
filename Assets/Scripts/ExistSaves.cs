using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExistSaves : MonoBehaviour
{
    public GameObject saveList;
    public Text saveText;
    public Text mapNameText;
    private GameObject SavingDiag;
    private List<GameObject> _gameObjectList;
    private List<Save> _SaveList;
    private GameObject SaveItemGameObject;
    private RectTransform grid;
    private RectTransform savelistRectTransform;
    private string[] dirs;

    private void Awake()
    {
        savelistRectTransform = saveList.GetComponent<RectTransform>();
        _gameObjectList = new List<GameObject>();
        _SaveList = new List<Save>();
    }

    private void OnEnable()
    {
        foreach (GameObject gameObject in _gameObjectList)
        {
            Destroy(gameObject);
        }
        
        _gameObjectList.Clear();
        _SaveList.Clear();
        grid = saveList.transform.Find("grid").GetComponent<RectTransform>();
        SaveItemGameObject = grid.Find("SaveItemButton Template").gameObject;
        ScanSaveloc();
        //ShowSaveData();
    }

    private void ScanSaveloc()
    {
        string path = Application.dataPath + "/Save/";
        if (!Directory.Exists(path))
        {
            Debug.Log("Dir not exist: " + path);
            Directory.CreateDirectory(path);
        }

       dirs = Directory.GetFiles(path, "*.data");
        for (int i = 0; i < dirs.Length; i++)
        {
            GameObject save_item = Instantiate(SaveItemGameObject, grid, false);
            _gameObjectList.Add(save_item);
            if (File.Exists(dirs[i]))
            {
                _SaveList.Add(getSaveData(dirs[i]));
            }

            save_item.GetComponentInChildren<Text>().text = CutText(dirs[i]);
            save_item.SetActive(true);
        }
    }

    private string CutText(string text)
    {
        int ind = text.LastIndexOf('/');
        return text.Substring(ind + 1);
    }

    private Save getSaveData(string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        Save save = bf.Deserialize(stream) as Save;
        stream.Close();
        return save;
    }

    private void ShowSaveData()
    {
        string text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        int ind = GetIndInSaveList(dirs,text);
        saveText.text = _SaveList[0].saveName + ".data";
        mapNameText.text = _SaveList[0].mapType.ToString();
    }

    private int GetIndInSaveList( string[] list,string text)
    {
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] == text)
            {
                return i;
            }
        }
        return 0;
    }
}