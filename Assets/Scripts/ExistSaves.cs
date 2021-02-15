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
        ScanSaveloc();
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
}
