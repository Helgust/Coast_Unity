using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]

public class Save
{
    public string saveName;
    public int mapType;
    public List<Year> Listofyears;
    public Dictionary<string, List<float>> statDict;
}
