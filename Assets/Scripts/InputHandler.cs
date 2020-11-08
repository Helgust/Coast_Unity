using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InputHandler : MonoBehaviour
{
    private string value;
    public GameObject DBObject;
    private DB DBScript;
    public GameObject InputPar1;
    public GameObject InputPar2;
    public GameObject InputPar3;
    public GameObject InputPar4;
    public GameObject InputPar5;
    public GameObject InputPar6;
    public GameObject InputPar7;

    private int ProcPar1 = 0;
    private int ProcPar2 = 0;
    private int ProcPar3 = 0;
    private int ProcPar4 = 0;
    private int ProcPar5 = 0;
    private int ProcPar6 = 5;
    private int ProcPar7 = 5;

    private int ProcTotal;

    private int FuncProcTotal()
    {
        return ProcPar1 + ProcPar2 + ProcPar3 + ProcPar4 + ProcPar4 + ProcPar5 + ProcPar6 + ProcPar7;
    }

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

    public void InitNextMove()
    {
        ProcPar1 = 0;
        ProcPar2 = 0;
        ProcPar3 = 0;
        ProcPar4 = 0;
        ProcPar5 = 0;
        ProcPar6 = 5;
        ProcPar7 = 5;
    }
    
    public void Update()
    {
        c_year  = GameObject.FindWithTag("GameController").GetComponent<GameManager>().currentYear;
        if (c_year == 0)
        {
            c_year = 1; // remove it AFAP(As Fast As Possible)
        }

        // index 0 its Money Par
        InputPar1.transform.GetChild(0).GetComponent<Text>().text = (DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * (float)ProcPar1/100.0f).ToString();
        InputPar2.transform.GetChild(0).GetComponent<Text>().text = (DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * (float)ProcPar2/100.0f).ToString();
        InputPar3.transform.GetChild(0).GetComponent<Text>().text = (DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * (float)ProcPar3/100.0f).ToString();
        InputPar4.transform.GetChild(0).GetComponent<Text>().text = (DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * (float)ProcPar4/100.0f).ToString();
        InputPar5.transform.GetChild(0).GetComponent<Text>().text = (DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * (float)ProcPar5/100.0f).ToString();
        InputPar6.transform.GetChild(0).GetComponent<Text>().text = (DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * (float)ProcPar6/100.0f).ToString();
        InputPar7.transform.GetChild(0).GetComponent<Text>().text = (DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * (float)ProcPar7/100.0f).ToString();

        //index 1 its Proc Par
        InputPar1.transform.GetChild(1).GetComponent<Text>().text = ProcPar1.ToString();
        InputPar2.transform.GetChild(1).GetComponent<Text>().text = ProcPar2.ToString();
        InputPar3.transform.GetChild(1).GetComponent<Text>().text = ProcPar3.ToString();
        InputPar4.transform.GetChild(1).GetComponent<Text>().text = ProcPar4.ToString();
        InputPar5.transform.GetChild(1).GetComponent<Text>().text = ProcPar5.ToString();
        InputPar6.transform.GetChild(1).GetComponent<Text>().text = ProcPar6.ToString();
        InputPar7.transform.GetChild(1).GetComponent<Text>().text = ProcPar7.ToString();
    }

    public void InitTextUI()
    {
        // index 0 its Money Par
        InputPar1.transform.GetChild(0).GetComponent<Text>().text = "0";
        InputPar2.transform.GetChild(0).GetComponent<Text>().text = "0";
        InputPar3.transform.GetChild(0).GetComponent<Text>().text = "0";
        InputPar4.transform.GetChild(0).GetComponent<Text>().text = "0";
        InputPar5.transform.GetChild(0).GetComponent<Text>().text = "0";
        InputPar6.transform.GetChild(0).GetComponent<Text>().text = "50";
        InputPar7.transform.GetChild(0).GetComponent<Text>().text = "50";

        //index 1 its Proc Par
        InputPar1.transform.GetChild(1).GetComponent<Text>().text = "0";
        InputPar2.transform.GetChild(1).GetComponent<Text>().text = "0";
        InputPar3.transform.GetChild(1).GetComponent<Text>().text = "0";
        InputPar4.transform.GetChild(1).GetComponent<Text>().text = "0";
        InputPar5.transform.GetChild(1).GetComponent<Text>().text = "0";
        InputPar6.transform.GetChild(1).GetComponent<Text>().text = "5";
        InputPar7.transform.GetChild(1).GetComponent<Text>().text = "5";
    }

    public void PlusClickPar1()
    {
        if (FuncProcTotal() < 100)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar1 += 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar1 += 25;
            }
            else
            {
                ProcPar1 += 1;
            }
        }
    }
    public void PlusClickPar2()
    {
        if (FuncProcTotal() < 100)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar2 += 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar2 += 25;
            }
            else
            {
                ProcPar2 += 1;
            }
        }
            
    }
    public void PlusClickPar3()
    {
        if (FuncProcTotal() < 100)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar3 += 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar3 += 25;
            }
            else
            {
                ProcPar3 += 1;
            }
        }
    }
    public void PlusClickPar4()
    {
        if (FuncProcTotal() < 100)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar4 += 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar4 += 25;
            }
            else
            {
                ProcPar4 += 1;
            }
        }
    }
    public void PlusClickPar5()
    {
        if (FuncProcTotal() < 100)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar5 += 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar5 += 25;
            }
            else
            {
                ProcPar5 += 1;
            }
        }
    }

    public void PlusClickPar6()
    {
        if (FuncProcTotal() < 100)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar6 += 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar6 += 25;
            }
            else
            {
                ProcPar6 += 1;
            }
        }
    }
    public void PlusClickPar7()
    {
        if (FuncProcTotal() < 100)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar7 += 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar7 += 25;
            }
            else
            {
                ProcPar7 += 1;
            }
        }
    }

    public void MinusClickPar1()
    {
        if (ProcPar1 > 0)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar1 -= 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar1 -= 25;
            }
            else
            {
                ProcPar1 -= 1;
            }
        }
    }
    public void MinusClickPar2()
    {
        if (ProcPar2 > 0)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar2 -= 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar2 -= 25;
            }
            else
            {
                ProcPar2 -= 1;
            }
        }
    }
    public void MinusClickPar3()
    {
        if (ProcPar3 > 0)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar3 -= 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar3 -= 25;
            }
            else
            {
                ProcPar3 -= 1;
            }
        }
    }
    public void MinusClickPar4()
    {
        if (ProcPar4 > 0)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar4 -= 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar4 -= 25;
            }
            else
            {
                ProcPar4 -= 1;
            }
        }
    }
    public void MinusClickPar5()
    {
        if (ProcPar5 > 0)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar5 -= 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar5 -= 25;
            }
            else
            {
                ProcPar5 -= 1;
            }
        }
    }

    public void MinusClickPar6()
    {
        if (ProcPar6 > 0)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar6 -= 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar6 -= 25;
            }
            else
            {
                ProcPar6 -= 1;
            }
        }
    }
    public void MinusClickPar7()
    {
        if (ProcPar7 > 0)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                ProcPar7 -= 10;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("PINK");
                ProcPar7 -= 25;
            }
            else
            {
                ProcPar7 -= 1;
            }
        }
    }


    

    public float Invest1()
    {
        value = InputPar1.transform.GetChild(0).GetComponent<Text>().text;
        if (value != string.Empty){
            
            return float.Parse(value);
        }
        else{
            return 0;
        }

    } 
    public float Invest2()
    {
        value = InputPar2.transform.GetChild(0).GetComponent<Text>().text;

        if (value != string.Empty){
            return float.Parse(value);
        }
        else{
            return 0;
        }
        

    }
    public float Invest3()
    {
        value = InputPar3.transform.GetChild(0).GetComponent<Text>().text;

        if (value != string.Empty){
            return float.Parse(value);
        }
        else{
            return 0;
        }

    }
    public float Invest4()
    {
        value = InputPar4.transform.GetChild(0).GetComponent<Text>().text;
        if (value != string.Empty){
            return float.Parse(value);
        }
        else{
            return 0;
        }

    }
    public float Invest5()
    {
        value = InputPar5.transform.GetChild(0).GetComponent<Text>().text;
        if (value != string.Empty){
            return float.Parse(value);
        }
        else{
            return 0;
        }

    }
    public float Invest6()
    {
        value = InputPar6.transform.GetChild(0).GetComponent<Text>().text;
        if (value != string.Empty){
            return float.Parse(value);
        }
        else{
            return DBScript.GetComponent<DB>().yearDataBase[c_year-1].budget * 0.05f;
        }

    }
    public float Invest7()
    {
        value = InputPar7.transform.GetChild(0).GetComponent<Text>().text;
        if (value != string.Empty){
            return float.Parse(value);
        }
        else{
            return DBScript.yearDataBase[c_year-1].budget * 0.05f;
        }

    }
}
