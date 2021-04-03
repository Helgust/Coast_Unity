using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExportDialog : MonoBehaviour
{
    public InputField inputField;
    private GameObject SavingDiag;
    private RectTransform grid;

    private void Update()
    {
    }

    private void OnEnable()
    {
        inputField.text = "report_" + GetCurrentUserNameDateTime();
    }

    // Start is called before the first frame update
    private void ExportProcess()
    {
        string path = Application.dataPath + "/Reports/";
        if (!Directory.Exists(path))
        {
            Debug.Log("Dir not exist: " + path);
            Directory.CreateDirectory(path);
        } 
        path = path + inputField.text + ".csv";
        Debug.Log("PATH="+path);
        FileStream fileStream = File.Create(path);
        fileStream.Close();
        StreamWriter writer = new StreamWriter(path);
        string title;
        title = String.Join(", ",DB.instance.statDict.Keys.ToArray());
        title = "year," + title;
        writer.WriteLine(title);
        
        for (int i = 0; i < GameManager.instance.currentYear; i++)
        {
            string line;
            List<float> tempList = new List<float>();
            tempList.Add(i+1);
            foreach (var key in DB.instance.statDict.Keys)
            {
                tempList.Add(DB.instance.statDict[key][i]);
            }
            line = String.Join(", ",tempList.ToArray());
            writer.WriteLine(line);
        }
        writer.Close();
        

    }

    private string GetCurrentUserNameDateTime()
    {
        return Environment.UserName+"_" + DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy-hh-dd-ss");
    }

    public void PressExport()
    {
        ExportProcess();
        UIManager.instance.setExportWinBool(false);
        UIManager.instance.ExportDialog.SetActive(false);
        UIManager.instance.setPauseBool(false);
    }


    public void PressCancel()
    {
        UIManager.instance.ExportDialog.SetActive(false);
        UIManager.instance.setExportWinBool(false);
        UIManager.instance.setPauseBool(false);
    }
}