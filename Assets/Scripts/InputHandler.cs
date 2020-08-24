using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public string value;
    public GameObject InputField1;
    public GameObject InputField2;
    public GameObject InputField3;
    public GameObject InputField4;
    public GameObject InputField5;
    public GameObject InputField6;
    public GameObject InputField7;


    List<int> Res = new List<int>();
    public List<int> FromUIToDB()
    {
        Res.Add(Invest1());
        Res.Add(Invest2());
        Res.Add(Invest3());
        Res.Add(Invest4());
        Res.Add(Invest5());
        Res.Add(Invest6());
        Res.Add(Invest7());

        return Res;
    }

    public int Invest1()
    {
        value = InputField1.GetComponent<Text>().text;
        if (value != string.Empty){
            
            return int.Parse(value);;
        }
        else{
            return 0;
        }

    }
    public int Invest2()
    {
        value = InputField2.GetComponent<Text>().text;

        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 0;
        }
        

    }
    public int Invest3()
    {
        value = InputField3.GetComponent<Text>().text;

        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 0;
        }

    }
    public int Invest4()
    {
        value = InputField4.GetComponent<Text>().text;
        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 0;
        }

    }
    public int Invest5()
    {
        value = InputField5.GetComponent<Text>().text;
        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 0;
        }

    }
    public int Invest6()
    {
        value = InputField6.GetComponent<Text>().text;
        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 50;
        }

    }
    public int Invest7()
    {
        value = InputField7.GetComponent<Text>().text;
        if (value != string.Empty){
            return int.Parse(value);
        }
        else{
            return 50;
        }

    }
}
