﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;
    private string value;
    private DB DBScript;
    public GameObject InputPar1;
    public GameObject InputPar2;
    public GameObject InputPar3;
    public GameObject InputPar4;
    public GameObject InputPar5;
    public GameObject InputPar6;
    public GameObject InputPar7;
    public GameObject SumPar;
    public GameObject ResourceBar;

    private int ProcPar1 = 0;
    private int ProcPar2 = 0;
    private int ProcPar3 = 0;
    private int ProcPar4 = 0;
    private int ProcPar5 = 0;
    private int ProcPar6 = 5;
    private int ProcPar7 = 5;

    //private int SumProc = 10;
    private int ProcTotal;


    private int FuncProcTotal()
    {
        return ProcPar1 + ProcPar2 + ProcPar3 + ProcPar4 + ProcPar5 + ProcPar6 + ProcPar7;
    }

    private int FuncMoneyTotal()
    {
        return ProcPar1 + ProcPar2 + ProcPar3 + ProcPar4 + ProcPar5 + ProcPar6 + ProcPar7;
    }

    List<float> Res = new List<float>();

    int c_year;


    void Awake() // here was Awake
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        //DontDestroyOnLoad(gameObject);
        
    }

    public void OnEnable()
    {
        //c_year = GameObject.FindWithTag("GameController").GetComponent<GameManager>().currentYear;
        //DBScript = GameManager.instance.DBObject.GetComponent<DB>();
        ProcPar1 = 0;
        ProcPar2 = 0;
        ProcPar3 = 0;
        ProcPar4 = 0;
        ProcPar5 = 0;
        ProcPar6 = 5;
        ProcPar7 = 5;
        InitTextUI();
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


    public void ChangeUiTextParams()
    {
        if (UIManager.instance.curUIState == UIManager.UIState.Game)
        {
            c_year = GameManager.instance.currentYear;
            if (c_year == 0)
            {
                c_year = 1;
            }

            // index 2 its Money Par
            InputPar1.transform.GetChild(2).GetComponent<Text>().text =
                (DB.instance.yearDataBase[c_year - 1].budget * (float) ProcPar1 / 100.0f).ToString();
            InputPar2.transform.GetChild(2).GetComponent<Text>().text =
                (DB.instance.yearDataBase[c_year - 1].budget * (float) ProcPar2 / 100.0f).ToString();
            InputPar3.transform.GetChild(2).GetComponent<Text>().text =
                (DB.instance.yearDataBase[c_year - 1].budget * (float) ProcPar3 / 100.0f).ToString();
            InputPar4.transform.GetChild(2).GetComponent<Text>().text =
                (DB.instance.yearDataBase[c_year - 1].budget * (float) ProcPar4 / 100.0f).ToString();
            InputPar5.transform.GetChild(2).GetComponent<Text>().text =
                (DB.instance.yearDataBase[c_year - 1].budget * (float) ProcPar5 / 100.0f).ToString();
            InputPar6.transform.GetChild(2).GetComponent<Text>().text =
                (DB.instance.yearDataBase[c_year - 1].budget * (float) ProcPar6 / 100.0f).ToString();
            InputPar7.transform.GetChild(2).GetComponent<Text>().text =
                (DB.instance.yearDataBase[c_year - 1].budget * (float) ProcPar7 / 100.0f).ToString();
            SumPar.transform.GetChild(1).GetComponent<Text>().text =
                (DB.instance.yearDataBase[c_year - 1].budget * (float) FuncProcTotal() / 100.0f)
                .ToString();

            //index 3 its Proc Par
            InputPar1.transform.GetChild(3).GetComponent<Text>().text = ProcPar1.ToString();
            InputPar2.transform.GetChild(3).GetComponent<Text>().text = ProcPar2.ToString();
            InputPar3.transform.GetChild(3).GetComponent<Text>().text = ProcPar3.ToString();
            InputPar4.transform.GetChild(3).GetComponent<Text>().text = ProcPar4.ToString();
            InputPar5.transform.GetChild(3).GetComponent<Text>().text = ProcPar5.ToString();
            InputPar6.transform.GetChild(3).GetComponent<Text>().text = ProcPar6.ToString();
            InputPar7.transform.GetChild(3).GetComponent<Text>().text = ProcPar7.ToString();
            SumPar.transform.GetChild(2).GetComponent<Text>().text = FuncProcTotal().ToString();


            ResourceBar.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>().text = (c_year - 1 + 1).ToString();
            ResourceBar.transform.GetChild(1).GetChild(2).GetComponent<TMP_Text>().text =
                DB.instance.yearDataBase[c_year - 1].fishAmount.ToString("0,0");
            ResourceBar.transform.GetChild(2).GetChild(2).GetComponent<TMP_Text>().text = DB.instance
                .yearDataBase[c_year - 1].population.ToString("0,0");
            ResourceBar.transform.GetChild(3).GetChild(2).GetComponent<TMP_Text>().text =
                DB.instance.yearDataBase[c_year - 1].budget.ToString("0,0");
            ResourceBar.transform.GetChild(4).GetChild(2).GetComponent<TMP_Text>().text = DB.instance
                .yearDataBase[c_year - 1].incomeSumPerHum.ToString("0.00");
            ResourceBar.transform.GetChild(5).GetChild(2).GetComponent<TMP_Text>().text = DB.instance
                .yearDataBase[c_year - 1].qualityOfEnv.ToString("0.00");
            ResourceBar.transform.GetChild(6).GetChild(2).GetComponent<TMP_Text>().text =
                DB.instance.yearDataBase[c_year - 1].humDevInd.ToString("0.0");
        }
    }

    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            GameUIManager.instance.PauseMenuCheck();
        }
    }

    public void InitTextUI()
    {
        // index 2 its Money Par
        InputPar1.transform.GetChild(2).GetComponent<Text>().text = "0";
        InputPar2.transform.GetChild(2).GetComponent<Text>().text = "0";
        InputPar3.transform.GetChild(2).GetComponent<Text>().text = "0";
        InputPar4.transform.GetChild(2).GetComponent<Text>().text = "0";
        InputPar5.transform.GetChild(2).GetComponent<Text>().text = "0";
        InputPar6.transform.GetChild(2).GetComponent<Text>().text = "50";
        InputPar7.transform.GetChild(2).GetComponent<Text>().text = "50";

        //index 3 its Proc Par
        InputPar1.transform.GetChild(3).GetComponent<Text>().text = "0";
        InputPar2.transform.GetChild(3).GetComponent<Text>().text = "0";
        InputPar3.transform.GetChild(3).GetComponent<Text>().text = "0";
        InputPar4.transform.GetChild(3).GetComponent<Text>().text = "0";
        InputPar5.transform.GetChild(3).GetComponent<Text>().text = "0";
        InputPar6.transform.GetChild(3).GetComponent<Text>().text = "5";
        InputPar7.transform.GetChild(3).GetComponent<Text>().text = "5";
        SumPar.transform.GetChild(2).GetComponent<Text>().text = "10";
        ChangeUiTextParams();
    }

    public void PlusClickPar1()
    {
        if (FuncProcTotal() < 100)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((FuncProcTotal() + 10) < 100))
            {
                ProcPar1 += 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((FuncProcTotal() + 25) < 100))
            {
                //Debug.Log("PINK");
                ProcPar1 += 25;
            }
            else
            {
                ProcPar1 += 1;
            }

            ChangeUiTextParams();
        }
    }

    public void PlusClickPar2()
    {
        if (FuncProcTotal() < 100)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((FuncProcTotal() + 10) < 100))
            {
                ProcPar2 += 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((FuncProcTotal() + 25) < 100))
            {
                //Debug.Log("PINK");
                ProcPar2 += 25;
            }
            else
            {
                ProcPar2 += 1;
            }
        }

        ChangeUiTextParams();
    }

    public void PlusClickPar3()
    {
        if (FuncProcTotal() < 100)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((FuncProcTotal() + 10) < 100))
            {
                ProcPar3 += 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((FuncProcTotal() + 25) < 100))
            {
                //Debug.Log("PINK");
                ProcPar3 += 25;
            }
            else
            {
                ProcPar3 += 1;
            }
        }

        ChangeUiTextParams();
    }

    public void PlusClickPar4()
    {
        if (FuncProcTotal() < 100)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((FuncProcTotal() + 10) < 100))
            {
                ProcPar4 += 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((FuncProcTotal() + 25) < 100))
            {
                //Debug.Log("PINK");
                ProcPar4 += 25;
            }
            else
            {
                ProcPar4 += 1;
            }
        }

        ChangeUiTextParams();
    }

    public void PlusClickPar5()
    {
        if (FuncProcTotal() < 100)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((FuncProcTotal() + 10) < 100))
            {
                ProcPar5 += 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((FuncProcTotal() + 25) < 100))
            {
                //Debug.Log("PINK");
                ProcPar5 += 25;
            }
            else
            {
                ProcPar5 += 1;
            }
        }

        ChangeUiTextParams();
    }

    public void PlusClickPar6()
    {
        if (FuncProcTotal() < 100)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((FuncProcTotal() + 10) < 100))
            {
                ProcPar6 += 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((FuncProcTotal() + 25) < 100))
            {
                //Debug.Log("PINK");
                ProcPar6 += 25;
            }
            else
            {
                ProcPar6 += 1;
            }
        }

        ChangeUiTextParams();
    }

    public void PlusClickPar7()
    {
        if (FuncProcTotal() < 100)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((FuncProcTotal() + 10) < 100))
            {
                ProcPar7 += 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((FuncProcTotal() + 25) < 100))
            {
                //Debug.Log("PINK");
                ProcPar7 += 25;
            }
            else
            {
                ProcPar7 += 1;
            }
        }

        ChangeUiTextParams();
    }

    public void MinusClickPar1()
    {
        if ((ProcPar1) > 0)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((ProcPar1 - 10) > 0))
            {
                ProcPar1 -= 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((ProcPar1 - 25) > 0))
            {
                //Debug.Log("PINK");
                ProcPar1 -= 25;
            }
            else
            {
                ProcPar1 -= 1;
            }
        }

        ChangeUiTextParams();
    }

    public void MinusClickPar2()
    {
        if (ProcPar2 > 0)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((ProcPar2 - 10) > 0))
            {
                ProcPar2 -= 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((ProcPar2 - 25) > 0))
            {
                //Debug.Log("PINK");
                ProcPar2 -= 25;
            }
            else
            {
                ProcPar2 -= 1;
            }
        }

        ChangeUiTextParams();
    }

    public void MinusClickPar3()
    {
        if (ProcPar3 > 0)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((ProcPar3 - 10) > 0))
            {
                ProcPar3 -= 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((ProcPar3 - 25) > 0))
            {
                //Debug.Log("PINK");
                ProcPar3 -= 25;
            }
            else
            {
                ProcPar3 -= 1;
            }
        }

        ChangeUiTextParams();
    }

    public void MinusClickPar4()
    {
        if (ProcPar4 > 0)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((ProcPar4 - 10) > 0))
            {
                ProcPar4 -= 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((ProcPar4 - 25) > 0))
            {
                //Debug.Log("PINK");
                ProcPar4 -= 25;
            }
            else
            {
                ProcPar4 -= 1;
            }
        }

        ChangeUiTextParams();
    }

    public void MinusClickPar5()
    {
        if (ProcPar5 > 0)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((ProcPar5 - 10) > 0))
            {
                ProcPar5 -= 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((ProcPar5 - 25) > 0))
            {
                //Debug.Log("PINK");
                ProcPar5 -= 25;
            }
            else
            {
                ProcPar5 -= 1;
            }
        }

        ChangeUiTextParams();
    }

    public void MinusClickPar6()
    {
        if (ProcPar6 > 0)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((ProcPar6 - 10) > 0))
            {
                ProcPar6 -= 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((ProcPar6 - 25) > 0))
            {
                //Debug.Log("PINK");
                ProcPar6 -= 25;
            }
            else
            {
                ProcPar6 -= 1;
            }
        }

        ChangeUiTextParams();
    }

    public void MinusClickPar7()
    {
        if (ProcPar7 > 0)
        {
            if ((Input.GetKey(KeyCode.LeftControl)) && ((ProcPar7 - 10) > 0))
            {
                ProcPar7 -= 10;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && ((ProcPar7 - 25) > 0))
            {
                //Debug.Log("PINK");
                ProcPar7 -= 25;
            }
            else
            {
                ProcPar7 -= 1;
            }
        }

        ChangeUiTextParams();
    }


    public float Invest1()
    {
        value = InputPar1.transform.GetChild(2).GetComponent<Text>().text;
        if (value != string.Empty)
        {
            return float.Parse(value);
        }
        else
        {
            return 0;
        }
    }

    public float Invest2()
    {
        value = InputPar2.transform.GetChild(2).GetComponent<Text>().text;

        if (value != string.Empty)
        {
            return float.Parse(value);
        }
        else
        {
            return 0;
        }
    }

    public float Invest3()
    {
        value = InputPar3.transform.GetChild(2).GetComponent<Text>().text;

        if (value != string.Empty)
        {
            return float.Parse(value);
        }
        else
        {
            return 0;
        }
    }

    public float Invest4()
    {
        value = InputPar4.transform.GetChild(2).GetComponent<Text>().text;
        if (value != string.Empty)
        {
            return float.Parse(value);
        }
        else
        {
            return 0;
        }
    }

    public float Invest5()
    {
        value = InputPar5.transform.GetChild(2).GetComponent<Text>().text;
        if (value != string.Empty)
        {
            return float.Parse(value);
        }
        else
        {
            return 0;
        }
    }

    public float Invest6()
    {
        value = InputPar6.transform.GetChild(2).GetComponent<Text>().text;
        if (value != string.Empty)
        {
            return float.Parse(value);
        }
        else
        {
            return DB.instance.yearDataBase[c_year - 1].budget * 0.05f;
        }
    }

    public float Invest7()
    {
        value = InputPar7.transform.GetChild(2).GetComponent<Text>().text;
        if (value != string.Empty)
        {
            return float.Parse(value);
        }
        else
        {
            return DBScript.yearDataBase[c_year - 1].budget * 0.05f;
        }
    }
}