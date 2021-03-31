using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]

public class Save
{
    public string saveName;
    public int currentYear;
    public Board board;
    public bool is_over;
    public Board boardBG;
    public string mapType;
    public List<Year> Listofyears;
    public Dictionary<string, List<float>> statDict;

    public void  Clear()
    {
        saveName = String.Empty;
        currentYear = 0;
        board.array2d.Clear();
        board.rows = 0;
        board.columns = 0;
        is_over = false;
        boardBG.array2d.Clear();
        boardBG.columns = 0;
        boardBG.rows = 0;
        mapType = String.Empty;
        Listofyears .Clear();
        statDict.Clear();
    }
}
