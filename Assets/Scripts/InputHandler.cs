using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InputHandler : MonoBehaviour
{
    private string value;
    public GameObject DBObject;
    private DB DBScript;
    public GameObject InputField1;
    public GameObject InputField2;
    public GameObject InputField3;
    public GameObject InputField4;
    public GameObject InputField5;
    public GameObject InputField6;
    public GameObject InputField7;

    
    List<float> Res = new List<float>();

    int c_year;
    

    void Awake() // here was Awake
	{
        c_year  = GameObject.FindWithTag("GameController").GetComponent<GameManager>().currentYear;
		DBScript = DBObject.GetComponent<DB>();
        
	}

    public List<float> FromUIToDB()
    {
        Res.Clear();
        Res.Add(Invest1());
        Res.Add(Invest2());
        Res.Add(Invest3());
        Res.Add(Invest4());
        Res.Add(Invest5());
        Res.Add(Invest6());
        Res.Add(Invest7());

        return Res;
    }
    
    public void UpdatePlaceholder()
    {
        c_year  = GameObject.FindWithTag("GameController").GetComponent<GameManager>().currentYear;
        InputField6.GetComponent<InputField>().placeholder.GetComponent<Text>().text = (DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * 0.05f).ToString();
        InputField7.GetComponent<InputField>().placeholder.GetComponent<Text>().text = (DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * 0.05f).ToString();
    }

     public void InitPlaceholder()
    {
        InputField6.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "50";
        InputField7.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "50";
    }

    public float Invest1()
    {
        value = InputField1.GetComponent<InputField>().text;
        if (value != string.Empty){
            
            return int.Parse(value);
        }
        else{
            return 0;
        }

    } 
    public float Invest2()
    {
        value = InputField2.GetComponent<InputField>().text;

        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 0;
        }
        

    }
    public float Invest3()
    {
        value = InputField3.GetComponent<InputField>().text;

        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 0;
        }

    }
    public float Invest4()
    {
        value = InputField4.GetComponent<InputField>().text;
        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 0;
        }

    }
    public float Invest5()
    {
        value = InputField5.GetComponent<InputField>().text;
        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 0;
        }

    }
    public float Invest6()
    {
        value = InputField6.GetComponent<InputField>().text;
        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * 0.05f;
        }

    }
    public float Invest7()
    {
        value = InputField7.GetComponent<InputField>().text;
        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return DBScript.yearDataBase[c_year-1].budget * 0.05f;
        }

    }
}
