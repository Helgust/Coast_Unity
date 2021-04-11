using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        string filePath = path + inputField.text + ".csv";
        Debug.Log("PATH="+filePath);
        FileStream fileStream = File.Create(filePath);
        fileStream.Close();
        StreamWriter writer = new StreamWriter(filePath);
        string title = "year";
        for (int i = 0; i < GameManager.instance.currentYear; i++)
        {
            title = String.Concat(title,";",i+1);
        }
        writer.WriteLine(title);
        foreach (var pair in DB.instance.statDict)
        {
            string line = String.Empty;
            line = line + pair.Key;
            line = line + ";"+String.Join(";",pair.Value.ToArray());
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