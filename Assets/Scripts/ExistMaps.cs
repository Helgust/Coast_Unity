using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.SimpleLocalization;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExistMaps : MonoBehaviour
{
    public GameObject mapList;
    public  GameObject MapItemGameObject;
    public Text Description;
    private GameObject SavingDiag;
    private List<GameObject> _gameObjectList;
    private List<Map> _MapList;
   
    private RectTransform grid;
    private RectTransform maplistRectTransform;
    private string[] dirs;

    private void Awake()
    {
        maplistRectTransform = mapList.GetComponent<RectTransform>();
        _gameObjectList = new List<GameObject>();
        _MapList = new List<Map>();
    }

    private void OnEnable()
    {
        foreach (GameObject gameObject in _gameObjectList)
        {
            Destroy(gameObject);
        }
        
        _gameObjectList.Clear();
        _MapList.Clear();
        grid = mapList.transform.Find("grid").GetComponent<RectTransform>();
        //MapItemGameObject = grid.Find("MapTemplate").gameObject;
        ScanSaveloc();
        //ShowSaveData();
    }

    private void ScanSaveloc()
    {
        string path = Application.dataPath + "/Maps/";
        if (!Directory.Exists(path))
        {
            Debug.Log("Dir not exist: " + path);
            //Directory.CreateDirectory(path);
        }

       dirs = Directory.GetFiles(path, "*.json");
        for (int i = 0; i < dirs.Length; i++)
        {
            GameObject map_item = Instantiate(MapItemGameObject, grid, false);
            _gameObjectList.Add(map_item);
            Map _map = getMapData(dirs[i]);
            _MapList.Add(_map);
            map_item.GetComponent<Map>().name = _map.name;
            map_item.GetComponent<Map>().descriptionName = _map.descriptionName;
            map_item.GetComponent<Map>().mapConfig = _map.mapConfig;
            map_item.GetComponent<Map>().mapElementsConfig = _map.mapElementsConfig;
            map_item.GetComponent<Map>().mapUnderConfig = _map.mapUnderConfig;
            map_item.GetComponentInChildren<Text>().text = _map.name;
            map_item.GetComponentInChildren<LocalizedText>().LocalizationKey = "NewGame."+_map.name;
            map_item.SetActive(true);
        }

        Description.GetComponent<LocalizedText>().LocalizationKey = "NewGame."+_MapList[0].descriptionName;
        Description.GetComponent<LocalizedText>().Start();
        Basket.instance.mapData = _gameObjectList[0].GetComponent<Map>();
    }

    private string CutText(string text)
    {
        int ind = text.LastIndexOf('/');
        return text.Substring(ind + 1);
    }

    private Map getMapData(string path)
    {
        Debug.Log("PATH="+path);
        string mapInfo = File.ReadAllText(path);
        Map map = JsonConvert.DeserializeObject<Map>(mapInfo);
        Debug.Log("Name="+map.name);
        return map;
    }

    private void ShowMapData()
    {
        string text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        int ind = GetIndInSaveList(dirs,text);
        //mapText.text = _MapList[0].saveName + ".data";
        //mapNameText.text = _MapList[0].mapType.ToString();
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