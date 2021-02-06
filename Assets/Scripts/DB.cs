using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class DB : MonoBehaviour
{

    public bool is_over = false;
    public List<Year> yearDataBase = new List<Year>();
    public Board board;
    public Board boardBG;
    public List<(int, int)> array_old = new List<(int, int)>();

    private Dictionary<string, List<float>> statDict = new Dictionary<string, List<float>>();

    private void PrintList(List<float> L)
    {
        Debug.Log("--------");
        for (int i = 0; i < L.Count; i++)
        {
            Debug.Log(L[i]);
        }
        Debug.Log("--------");

    }

    private void PrintList2(List<(int, int)> L)
    {
        Debug.Log("--------");
        for (int i = 0; i < L.Count; i++)
        {
            Debug.Log(L[i]);
        }
        Debug.Log("--------");

    }

    // private void FillUpBoard_OldWithZero(int rows, int columns)
    // {
    //     for(int i = 0; i < rows; i++)
    //     {
    //         for(int j = 0; j < columns; j++)
    //         {
    //             board_old.array2d[i][j] = 0;
    //         }
    //     }
    // }


    public void InitDB(TextAsset jsonAsset, int finalYear)
    {
        //yearDataBase.Add(new Year());
        // for current moment size og list is locked by dev TODO: made it modifiable(����������)

        //Debug.Log("InitDB: File Exists: " + File.Exists(jsonString));
        //string json = File.ReadAllText(jsonString);
        yearDataBase[0] = JsonConvert.DeserializeObject<Year>(jsonAsset.text);

        InitDict();
        PreCalc();
        PutAllInfoToDict(0);
        
        //PutAllInfoToDict(0);
        //yearDataBase.Add(new Year());
        Debug.Log("InitDB: Size of list: " + yearDataBase.Count);


    }

    public void InitBoard(TextAsset jsonAsset)
    {
        //Debug.Log("InitBoard: File Exists: " + File.Exists(jsonString));
        //string json = File.ReadAllText(jsonString);
        board = JsonConvert.DeserializeObject<Board>(jsonAsset.text);
        /* for (int i = 0; i < 20; i++)
        {
            Debug.Log(board.array2d[19][i]);
        } */

    }
    public void InitBG(TextAsset jsonAsset)
    {
        //Debug.Log("InitBoard: File Exists: " + File.Exists(jsonString));
        //string json = File.ReadAllText(jsonString);
        boardBG = JsonConvert.DeserializeObject<Board>(jsonAsset.text);
        /* for (int i = 0; i < 20; i++)
        {
            Debug.Log(board.array2d[19][i]);
        } */

    }

    public void NextMoveDB(int currentYear, List<float> UIText)
    {
        Debug.Log("DB:CurrentYear= " + currentYear);
        Debug.Log("DB: Size of list: " + yearDataBase.Count);

        //PrintList(UIText);
        InvestCalc(currentYear, UIText);
        AbsCalc(currentYear);
        MapCalc(currentYear);
        PutAllInfoToDict(currentYear);
        //PutAllInfoToDict(currentYear);
    }


    private float InvSumCalc(int currentYear)
    {
        return yearDataBase[currentYear].paperfactory.investments +
                                            yearDataBase[currentYear].fish.investments +
                                            yearDataBase[currentYear].aquaCulture.investments +
                                            yearDataBase[currentYear].agroCulture.investments +
                                            yearDataBase[currentYear].tourism.investments +
                                            yearDataBase[currentYear].chemCleaning.investments +
                                            yearDataBase[currentYear].bioCleaning.investments;
    }

    public void AbsCalc(int currentYear)
    {
        MoveConst(currentYear);
        MoneyCalc(currentYear);
        AmorCacl(currentYear);
        CapCalc(currentYear);
        CapSumCalc(currentYear);
        JobsReqCalc(currentYear);
        JobsReqSumCalc(currentYear);
        PopIncCalc(currentYear);
        PopAmCalc(currentYear);
        AbleToJobPopCalc(currentYear);
        JobsAmOrig(currentYear);
        JobsAmCalc(currentYear);
        ProdCalc(currentYear);
        EmployRateCalc(currentYear);
        UnEmployRateCalc(currentYear);
        FishCalc(currentYear);
        DirtEjectCacl(currentYear);
        ResediuEjectCacl(currentYear);
        DegrCalc(currentYear);
        IncomeCalc(currentYear);
        IncomeSumCalc(currentYear);
        ProfitCalc(currentYear);
        ToBudgCalc(currentYear);
        NewBudgetCalc(currentYear);
        IncomeSumPerHumanCalc(currentYear);


    }

    private void MoveConst(int currentYear)
    {
        yearDataBase[currentYear].FISH_INC = yearDataBase[currentYear - 1].FISH_INC;
        yearDataBase[currentYear].POP_INC = yearDataBase[currentYear - 1].POP_INC;
        yearDataBase[currentYear].PROFIT_TAX = yearDataBase[currentYear - 1].PROFIT_TAX;
        yearDataBase[currentYear].ABLE_TO_LABOR = yearDataBase[currentYear - 1].ABLE_TO_LABOR;
        yearDataBase[currentYear].BASE_COST_INC = yearDataBase[currentYear - 1].BASE_COST_INC;
        yearDataBase[currentYear].BANK_PROCENT = yearDataBase[currentYear - 1].BANK_PROCENT;
        yearDataBase[currentYear].E_COL_OTH_POP = yearDataBase[currentYear - 1].E_COL_OTH_POP;
        yearDataBase[currentYear].ORG_OTH_POP = yearDataBase[currentYear - 1].ORG_OTH_POP;
        yearDataBase[currentYear].shipUCap = yearDataBase[currentYear - 1].shipUCap;
        yearDataBase[currentYear].agroUCap = yearDataBase[currentYear - 1].agroUCap;
        yearDataBase[currentYear].turUCap = yearDataBase[currentYear - 1].turUCap;
        //yearDataBase[currentYear].budget = yearDataBase[currentYear-1].budget;


        yearDataBase[currentYear].paperfactory.CAP_LIFE_TIME = yearDataBase[currentYear - 1].paperfactory.CAP_LIFE_TIME;
        yearDataBase[currentYear].paperfactory.NUM_JOB_PER_CAP = yearDataBase[currentYear - 1].paperfactory.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].paperfactory.VAR_COSTS = yearDataBase[currentYear - 1].paperfactory.VAR_COSTS;
        yearDataBase[currentYear].paperfactory.BASE_COST = yearDataBase[currentYear - 1].paperfactory.BASE_COST;
        yearDataBase[currentYear].paperfactory.AVG_LABOR_PROD = yearDataBase[currentYear - 1].paperfactory.AVG_LABOR_PROD;
        yearDataBase[currentYear].paperfactory.ORG_OTH = yearDataBase[currentYear - 1].paperfactory.ORG_OTH;

        yearDataBase[currentYear].fish.CAP_LIFE_TIME = yearDataBase[currentYear - 1].fish.CAP_LIFE_TIME;
        yearDataBase[currentYear].fish.NUM_JOB_PER_CAP = yearDataBase[currentYear - 1].fish.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].fish.VAR_COSTS = yearDataBase[currentYear - 1].fish.VAR_COSTS;
        yearDataBase[currentYear].fish.BASE_COST = yearDataBase[currentYear - 1].fish.BASE_COST;
        yearDataBase[currentYear].fish.AVG_LABOR_PROD = yearDataBase[currentYear - 1].fish.AVG_LABOR_PROD;
        yearDataBase[currentYear].fish.E_COL_OTH = yearDataBase[currentYear - 1].fish.E_COL_OTH;
        yearDataBase[currentYear].fish.ORG_OTH = yearDataBase[currentYear - 1].fish.ORG_OTH;

        yearDataBase[currentYear].aquaCulture.CAP_LIFE_TIME = yearDataBase[currentYear - 1].aquaCulture.CAP_LIFE_TIME;
        yearDataBase[currentYear].aquaCulture.NUM_JOB_PER_CAP = yearDataBase[currentYear - 1].aquaCulture.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].aquaCulture.VAR_COSTS = yearDataBase[currentYear - 1].aquaCulture.VAR_COSTS;
        yearDataBase[currentYear].aquaCulture.BASE_COST = yearDataBase[currentYear - 1].aquaCulture.BASE_COST;
        yearDataBase[currentYear].aquaCulture.AVG_LABOR_PROD = yearDataBase[currentYear - 1].aquaCulture.AVG_LABOR_PROD;
        yearDataBase[currentYear].aquaCulture.ORG_OTH = yearDataBase[currentYear - 1].aquaCulture.ORG_OTH;
        yearDataBase[currentYear].aquaCulture.PHS_OTH = yearDataBase[currentYear - 1].aquaCulture.PHS_OTH;

        yearDataBase[currentYear].agroCulture.CAP_LIFE_TIME = yearDataBase[currentYear - 1].agroCulture.CAP_LIFE_TIME;
        yearDataBase[currentYear].agroCulture.NUM_JOB_PER_CAP = yearDataBase[currentYear - 1].agroCulture.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].agroCulture.VAR_COSTS = yearDataBase[currentYear - 1].agroCulture.VAR_COSTS;
        yearDataBase[currentYear].agroCulture.BASE_COST = yearDataBase[currentYear - 1].agroCulture.BASE_COST;
        yearDataBase[currentYear].agroCulture.AVG_LABOR_PROD = yearDataBase[currentYear - 1].agroCulture.AVG_LABOR_PROD;
        yearDataBase[currentYear].agroCulture.ORG_OTH = yearDataBase[currentYear - 1].agroCulture.ORG_OTH;
        yearDataBase[currentYear].agroCulture.PHS_OTH = yearDataBase[currentYear - 1].agroCulture.PHS_OTH;
        yearDataBase[currentYear].agroCulture.E_COL_OTH = yearDataBase[currentYear - 1].agroCulture.E_COL_OTH;

        yearDataBase[currentYear].tourism.CAP_LIFE_TIME = yearDataBase[currentYear - 1].tourism.CAP_LIFE_TIME;
        yearDataBase[currentYear].tourism.NUM_JOB_PER_CAP = yearDataBase[currentYear - 1].tourism.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].tourism.VAR_COSTS = yearDataBase[currentYear - 1].tourism.VAR_COSTS;
        yearDataBase[currentYear].tourism.BASE_COST = yearDataBase[currentYear - 1].tourism.BASE_COST;
        yearDataBase[currentYear].tourism.AVG_LABOR_PROD = yearDataBase[currentYear - 1].tourism.AVG_LABOR_PROD;
        yearDataBase[currentYear].tourism.E_COL_OTH = yearDataBase[currentYear - 1].tourism.E_COL_OTH;
        yearDataBase[currentYear].tourism.ORG_OTH = yearDataBase[currentYear - 1].tourism.ORG_OTH;

        yearDataBase[currentYear].chemCleaning.CAP_LIFE_TIME = yearDataBase[currentYear - 1].chemCleaning.CAP_LIFE_TIME;
        yearDataBase[currentYear].chemCleaning.NUM_JOB_PER_CAP = yearDataBase[currentYear - 1].chemCleaning.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].chemCleaning.AVG_LABOR_PROD = yearDataBase[currentYear - 1].chemCleaning.AVG_LABOR_PROD;
        yearDataBase[currentYear].chemCleaning.CHEM_CLEAN_FACT = yearDataBase[currentYear - 1].chemCleaning.CHEM_CLEAN_FACT;

        yearDataBase[currentYear].bioCleaning.CAP_LIFE_TIME = yearDataBase[currentYear - 1].bioCleaning.CAP_LIFE_TIME;
        yearDataBase[currentYear].bioCleaning.NUM_JOB_PER_CAP = yearDataBase[currentYear - 1].bioCleaning.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].bioCleaning.AVG_LABOR_PROD = yearDataBase[currentYear - 1].bioCleaning.AVG_LABOR_PROD;
        yearDataBase[currentYear].bioCleaning.BIO_CLEAN_FACT = yearDataBase[currentYear - 1].bioCleaning.BIO_CLEAN_FACT;

        //yearDataBase[currentYear].qualityOfEnv = yearDataBase[currentYear-1].qualityOfEnv;
    }

    private void MoneyCalc(int currentYear)
    {
        yearDataBase[currentYear].moneySpend = InvSumCalc(currentYear);
        yearDataBase[currentYear].moneyLeft = yearDataBase[currentYear - 1].budget - yearDataBase[currentYear].moneySpend;

    }

    //������ ��������������� ���������� �� ��������
    private void AmorCacl(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.amortization = yearDataBase[currentYear - 1].paperfactory.capital / yearDataBase[currentYear - 1].paperfactory.CAP_LIFE_TIME;
        yearDataBase[currentYear].fish.amortization = yearDataBase[currentYear - 1].fish.capital / yearDataBase[currentYear - 1].fish.CAP_LIFE_TIME;
        yearDataBase[currentYear].aquaCulture.amortization = yearDataBase[currentYear - 1].aquaCulture.capital / yearDataBase[currentYear - 1].aquaCulture.CAP_LIFE_TIME;
        yearDataBase[currentYear].agroCulture.amortization = yearDataBase[currentYear - 1].agroCulture.capital / yearDataBase[currentYear - 1].agroCulture.CAP_LIFE_TIME;
        yearDataBase[currentYear].tourism.amortization = yearDataBase[currentYear - 1].tourism.capital / yearDataBase[currentYear - 1].tourism.CAP_LIFE_TIME;
        yearDataBase[currentYear].chemCleaning.amortization = yearDataBase[currentYear - 1].chemCleaning.capital / yearDataBase[currentYear - 1].chemCleaning.CAP_LIFE_TIME;
        yearDataBase[currentYear].bioCleaning.amortization = yearDataBase[currentYear - 1].bioCleaning.capital / yearDataBase[currentYear - 1].bioCleaning.CAP_LIFE_TIME;
    }




    //������ ���������� ��������� �������� � ���� ����
    private void CapCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.capital = (yearDataBase[currentYear - 1].paperfactory.capital + yearDataBase[currentYear].paperfactory.investments) - yearDataBase[currentYear].paperfactory.amortization;
        yearDataBase[currentYear].fish.capital = (yearDataBase[currentYear - 1].fish.capital + yearDataBase[currentYear].fish.investments) - yearDataBase[currentYear].fish.amortization;
        yearDataBase[currentYear].aquaCulture.capital = (yearDataBase[currentYear - 1].aquaCulture.capital + yearDataBase[currentYear].aquaCulture.investments) - yearDataBase[currentYear].aquaCulture.amortization;
        yearDataBase[currentYear].agroCulture.capital = (yearDataBase[currentYear - 1].agroCulture.capital + yearDataBase[currentYear].agroCulture.investments) - yearDataBase[currentYear].agroCulture.amortization;
        yearDataBase[currentYear].tourism.capital = (yearDataBase[currentYear - 1].tourism.capital + yearDataBase[currentYear].tourism.investments) - yearDataBase[currentYear].tourism.amortization;
        yearDataBase[currentYear].chemCleaning.capital = (yearDataBase[currentYear - 1].chemCleaning.capital + yearDataBase[currentYear].chemCleaning.investments) - yearDataBase[currentYear].chemCleaning.amortization;
        yearDataBase[currentYear].bioCleaning.capital = (yearDataBase[currentYear - 1].bioCleaning.capital + yearDataBase[currentYear].bioCleaning.investments) - yearDataBase[currentYear].bioCleaning.amortization;
    }

    private void CapSumCalc(int currentYear)
    {
        yearDataBase[currentYear].capitalSum = yearDataBase[currentYear].paperfactory.capital +
                                                yearDataBase[currentYear].fish.capital +
                                                yearDataBase[currentYear].aquaCulture.capital +
                                                yearDataBase[currentYear].agroCulture.capital +
                                                yearDataBase[currentYear].tourism.capital +
                                                yearDataBase[currentYear].chemCleaning.capital +
                                                yearDataBase[currentYear].bioCleaning.capital;
    }

    //������ ���������� ���������� ������� ���� �� ���������� �����������
    private void JobsReqCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.reqJobs = (yearDataBase[currentYear].paperfactory.NUM_JOB_PER_CAP * yearDataBase[currentYear].paperfactory.capital);
        yearDataBase[currentYear].fish.reqJobs = (yearDataBase[currentYear].fish.NUM_JOB_PER_CAP * yearDataBase[currentYear].fish.capital);
        yearDataBase[currentYear].aquaCulture.reqJobs = (yearDataBase[currentYear].aquaCulture.NUM_JOB_PER_CAP * yearDataBase[currentYear].aquaCulture.capital);
        yearDataBase[currentYear].agroCulture.reqJobs = (yearDataBase[currentYear].agroCulture.NUM_JOB_PER_CAP * yearDataBase[currentYear].agroCulture.capital);
        yearDataBase[currentYear].tourism.reqJobs = (yearDataBase[currentYear].tourism.NUM_JOB_PER_CAP * yearDataBase[currentYear].tourism.capital);
        yearDataBase[currentYear].chemCleaning.reqJobs = (yearDataBase[currentYear].chemCleaning.NUM_JOB_PER_CAP * yearDataBase[currentYear].chemCleaning.capital);
        yearDataBase[currentYear].bioCleaning.reqJobs = (yearDataBase[currentYear].bioCleaning.NUM_JOB_PER_CAP * yearDataBase[currentYear].bioCleaning.capital);
    }

    private void JobsReqSumCalc(int currentYear)
    {
        yearDataBase[currentYear].jobsReqSum = yearDataBase[currentYear].paperfactory.reqJobs +
                                                  yearDataBase[currentYear].fish.reqJobs +
                                                  yearDataBase[currentYear].aquaCulture.reqJobs +
                                                  yearDataBase[currentYear].agroCulture.reqJobs +
                                                  yearDataBase[currentYear].tourism.reqJobs +
                                                  yearDataBase[currentYear].chemCleaning.reqJobs +
                                                  yearDataBase[currentYear].bioCleaning.reqJobs;
    }

    private void PopIncCalc(int currentYear)
    {
        yearDataBase[currentYear].pop_incM = (yearDataBase[currentYear - 1].POP_INC * yearDataBase[currentYear - 1].qualityOfEnv);
    }

    private void PopAmCalc(int currentYear)
    {
        yearDataBase[currentYear].population = yearDataBase[currentYear - 1].population * (1 + (yearDataBase[currentYear].pop_incM / 100));
    }

    private void AbleToJobPopCalc(int currentYear)
    {

        yearDataBase[currentYear].ablePopSum = (yearDataBase[currentYear].population * (yearDataBase[currentYear].ABLE_TO_LABOR / 100));
        //Debug.Log(yearDataBase[currentYear].ablePopSum);
    }
    private void JobsAmOrig(int currentYear)
    {
        if (yearDataBase[currentYear].jobsReqSum > yearDataBase[currentYear].ablePopSum)
        {
            yearDataBase[currentYear].jobsAmSum = yearDataBase[currentYear].ablePopSum;
        }
        else
        {
            yearDataBase[currentYear].jobsAmSum = yearDataBase[currentYear].jobsReqSum;
        }
    }

    //������ ���������� ���������� �������������� ������� ���� �� ���������� �����������
    private void JobsAmCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.numJobs = yearDataBase[currentYear].paperfactory.reqJobs * yearDataBase[currentYear].jobsAmSum / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].fish.numJobs = yearDataBase[currentYear].fish.reqJobs * yearDataBase[currentYear].jobsAmSum / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].aquaCulture.numJobs = yearDataBase[currentYear].aquaCulture.reqJobs * yearDataBase[currentYear].jobsAmSum / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].agroCulture.numJobs = yearDataBase[currentYear].agroCulture.reqJobs * yearDataBase[currentYear].jobsAmSum / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].tourism.numJobs = yearDataBase[currentYear].tourism.reqJobs * yearDataBase[currentYear].jobsAmSum / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].chemCleaning.numJobs = yearDataBase[currentYear].chemCleaning.reqJobs * yearDataBase[currentYear].jobsAmSum / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].bioCleaning.numJobs = yearDataBase[currentYear].bioCleaning.reqJobs * yearDataBase[currentYear].jobsAmSum / yearDataBase[currentYear].jobsReqSum;

    }

    private float ProdExpCalc(float ProdRez, float VolRes)

    {
        float Res;
        //ProdRez - ���������������� ������
        //VolRes - ����� �����
        if (ProdRez > VolRes)
        {
            Res = VolRes;
        }
        else
        {
            Res = ProdRez;
        }
        return Res;
    }

    //������ ������ ������������ ��� ����� ���������� ���������� �����
    private void ProdCalc(int currentYear)
    {
        float temp1 = yearDataBase[currentYear].fish.AVG_LABOR_PROD * yearDataBase[currentYear].fish.numJobs;
        float temp2 = yearDataBase[currentYear].chemCleaning.AVG_LABOR_PROD * yearDataBase[currentYear].chemCleaning.numJobs;
        float temp3 = yearDataBase[currentYear].bioCleaning.AVG_LABOR_PROD * yearDataBase[currentYear].bioCleaning.numJobs;

        yearDataBase[currentYear].paperfactory.production = yearDataBase[currentYear].paperfactory.AVG_LABOR_PROD * yearDataBase[currentYear].paperfactory.numJobs * yearDataBase[currentYear - 1].qualityOfEnv;
        yearDataBase[currentYear].fish.production = ProdExpCalc(temp1, yearDataBase[currentYear - 1].fishAmount) * yearDataBase[currentYear - 1].qualityOfEnv;
        yearDataBase[currentYear].aquaCulture.production = yearDataBase[currentYear].aquaCulture.AVG_LABOR_PROD * yearDataBase[currentYear].aquaCulture.numJobs * yearDataBase[currentYear - 1].qualityOfEnv;
        yearDataBase[currentYear].agroCulture.production = yearDataBase[currentYear].agroCulture.AVG_LABOR_PROD * yearDataBase[currentYear].agroCulture.numJobs * yearDataBase[currentYear - 1].qualityOfEnv;
        yearDataBase[currentYear].tourism.production = yearDataBase[currentYear].tourism.AVG_LABOR_PROD * yearDataBase[currentYear].tourism.numJobs * yearDataBase[currentYear - 1].qualityOfEnv;
        yearDataBase[currentYear].chemCleaning.production = ProdExpCalc(temp2, ChemSens(currentYear));
        yearDataBase[currentYear].bioCleaning.production = ProdExpCalc(temp3, BioSens(currentYear));
    }

    private void FishCalc(int currentYear)
    {
        yearDataBase[currentYear].fishAmount = (float)(yearDataBase[currentYear - 1].fishAmount + (yearDataBase[currentYear - 1].fishAmount
                                                                                                * (yearDataBase[currentYear].FISH_INC / 100)
                                                                                                * yearDataBase[currentYear - 1].qualityOfEnv
                                                                                                * (2.6 * Mathf.Exp((-1 * Mathf.Pow((yearDataBase[currentYear - 1].fishAmount - 2000), 2) / 180000))))
                                                                                                - yearDataBase[currentYear].fish.production);

    }



    //������ ������� � ���� ����

    private void IncomeCalc(int currentYear)
    {
        Debug.Log("BASE_COST: " + yearDataBase[currentYear].paperfactory.BASE_COST + " BASE_COST_INC: " + yearDataBase[currentYear].BASE_COST_INC + " CurrentYear: " + currentYear + " PROD: " + yearDataBase[currentYear].paperfactory.production);
        yearDataBase[currentYear].paperfactory.income = yearDataBase[currentYear].paperfactory.BASE_COST * (1 + ((yearDataBase[currentYear].BASE_COST_INC / 100) * currentYear)) * yearDataBase[currentYear].paperfactory.production;
        yearDataBase[currentYear].fish.income = yearDataBase[currentYear].fish.BASE_COST * (1 + ((yearDataBase[currentYear].BASE_COST_INC / 100) * currentYear)) * yearDataBase[currentYear].fish.production;
        yearDataBase[currentYear].aquaCulture.income = yearDataBase[currentYear].aquaCulture.BASE_COST * (1 + ((yearDataBase[currentYear].BASE_COST_INC / 100) * currentYear)) * yearDataBase[currentYear].aquaCulture.production;
        yearDataBase[currentYear].agroCulture.income = yearDataBase[currentYear].agroCulture.BASE_COST * (1 + ((yearDataBase[currentYear].BASE_COST_INC / 100) * currentYear)) * yearDataBase[currentYear].agroCulture.production;
        yearDataBase[currentYear].tourism.income = yearDataBase[currentYear].tourism.BASE_COST * (1 + ((yearDataBase[currentYear].BASE_COST_INC / 100) * currentYear)) * yearDataBase[currentYear].tourism.production;
    }


    private void ProfitCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.profit = (yearDataBase[currentYear].paperfactory.income - yearDataBase[currentYear].paperfactory.amortization - (yearDataBase[currentYear].paperfactory.production * yearDataBase[currentYear].paperfactory.VAR_COSTS));
        yearDataBase[currentYear].fish.profit = (yearDataBase[currentYear].fish.income - yearDataBase[currentYear].fish.amortization - (yearDataBase[currentYear].fish.production * yearDataBase[currentYear].fish.VAR_COSTS));
        yearDataBase[currentYear].aquaCulture.profit = (yearDataBase[currentYear].aquaCulture.income - yearDataBase[currentYear].aquaCulture.amortization - (yearDataBase[currentYear].aquaCulture.production * yearDataBase[currentYear].aquaCulture.VAR_COSTS));
        yearDataBase[currentYear].agroCulture.profit = (yearDataBase[currentYear].agroCulture.income - yearDataBase[currentYear].agroCulture.amortization - (yearDataBase[currentYear].agroCulture.production * yearDataBase[currentYear].agroCulture.VAR_COSTS));
        yearDataBase[currentYear].tourism.profit = (yearDataBase[currentYear].tourism.income - yearDataBase[currentYear].tourism.amortization - (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.VAR_COSTS));
    }


    private void ToBudgCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.toBudget = yearDataBase[currentYear].paperfactory.profit > 0 ? yearDataBase[currentYear].paperfactory.profit * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].fish.toBudget = yearDataBase[currentYear].fish.profit > 0 ? yearDataBase[currentYear].fish.profit * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].aquaCulture.toBudget = yearDataBase[currentYear].aquaCulture.profit > 0 ? yearDataBase[currentYear].aquaCulture.profit * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].agroCulture.toBudget = yearDataBase[currentYear].agroCulture.profit > 0 ? yearDataBase[currentYear].agroCulture.profit * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].tourism.toBudget = yearDataBase[currentYear].tourism.profit > 0 ? yearDataBase[currentYear].tourism.profit * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;

    }

    private void HumDevIndCacl(int currentYear)
    {
        float Res = 33.0f * yearDataBase[currentYear].qualityOfEnv + 33.0f * (yearDataBase[currentYear].incomeSumPerHum / 25.0f) + 33.0f * (yearDataBase[currentYear].employmentRate / 100.0f);
        yearDataBase[currentYear].humDevInd = Res;
    }

    private void QualEnvCalc(int currentYear) // TODO Rewrite
    {
        float Res = 0;
        int Sea_good = 0;
        int Sea_bad = 0;
        int Land_good = 0;
        int Land_bad = 0;
        AnMMap(1);
        Sea_good = Sea_good + array_old.Count;
        AnMMap(2);
        Sea_good = Sea_good + array_old.Count;
        AnMMap(10);
        Sea_good = Sea_good + array_old.Count;
        AnMMap(11);
        Sea_good = Sea_good + array_old.Count;
        AnMMap(6);
        Sea_bad = Sea_bad + array_old.Count;
        AnMMap(7);
        Sea_bad = Sea_bad + array_old.Count;
        AnMMap(6);
        PrintList2(array_old);
        Land_good = Land_good + array_old.Count;
        AnMMap(4);
        Land_good = Land_good + array_old.Count;
        AnMMap(3);
        Land_good = Land_good + array_old.Count;
        AnMMap(12);
        Land_good = Land_good + array_old.Count;
        AnMMap(13);
        Land_good = Land_good + array_old.Count;
        AnMMap(14);
        Land_good = Land_good + array_old.Count;
        AnMMap(8);
        Land_bad = Land_bad + array_old.Count;
        AnMMap(9);
        Land_bad = Land_bad + array_old.Count;

        Debug.Log("Sea_G: " + Sea_good + " Sea_B: " + Sea_bad + " Land_G: " + Land_good + " Lang_B: " + Land_bad);
        Res += (((float)Sea_good - (float)Sea_bad) / (float)Sea_good) * 0.10000f + (((float)Land_good - (float)Land_bad) / (float)Land_good) * 0.90000f;
        Debug.Log("Res: " + Res);

        //return (int(Math.pow(Res, 3) * 100) / 100);
        yearDataBase[currentYear].qualityOfEnv = (float)Mathf.Pow(Res, 3);
    }

    private void IncomeSumPerHumanCalc(int currentYear)
    {
        yearDataBase[currentYear].incomeSumPerHum = yearDataBase[currentYear].incomeSum / yearDataBase[currentYear].population;
    }

    //������ ���������� ������ ��� �������� (��� �������� ����������)
    private void IncomeSumCalc(int currentYear)
    {
        yearDataBase[currentYear].incomeSum = yearDataBase[currentYear].paperfactory.income +
                                                   yearDataBase[currentYear].fish.income +
                                                   yearDataBase[currentYear].aquaCulture.income +
                                                   yearDataBase[currentYear].agroCulture.income +
                                                   yearDataBase[currentYear].tourism.income;
    }

    private void NewBudgetCalc(int currentYear)
    {
        Debug.Log("NEW budget " + (1 + yearDataBase[currentYear].BANK_PROCENT));
        yearDataBase[currentYear].budget = yearDataBase[currentYear].moneyLeft * (1.0f + yearDataBase[currentYear].BANK_PROCENT) +
                                           yearDataBase[currentYear].paperfactory.toBudget +
                                           yearDataBase[currentYear].fish.toBudget +
                                           yearDataBase[currentYear].aquaCulture.toBudget +
                                           yearDataBase[currentYear].agroCulture.toBudget +
                                           yearDataBase[currentYear].tourism.toBudget;
    }


    //������ ������� � ����� �������������� �����


    //������ ���������� ��������������� ���������

    //�������� �� ��������������� ���������� � ����������� (���������� �������)
    private float ChemSens(int currentYear)
    {
        if (yearDataBase[currentYear - 1].residueOrg < yearDataBase[currentYear].chemCleaning.CHEM_CLEAN_FACT)
        {
            return 0;
        }
        else
        {
            return yearDataBase[currentYear - 1].residueOrg;
        }
    }

    //�������� �� ��������������� ���������� � ����������� (������������� �������)
    private float BioSens(int currentYear)
    {
        if (yearDataBase[currentYear - 1].residueEColi < yearDataBase[currentYear].bioCleaning.BIO_CLEAN_FACT)
        {
            return 0;
        }
        else
        {
            return yearDataBase[currentYear - 1].residueEColi;
        }
    }

    //������ ������ ���������, %
    private void EmployRateCalc(int currentYear)
    {
        yearDataBase[currentYear].employmentRate = (yearDataBase[currentYear].jobsAmSum / yearDataBase[currentYear].ablePopSum * 100);
    }
    //������ ������ �����������, %
    private void UnEmployRateCalc(int currentYear)
    {
        yearDataBase[currentYear].unemploymentRate = 100 - yearDataBase[currentYear].employmentRate;
    }

    //������ ������� �������������
    private void DirtEjectCacl(int currentYear) // Watch Carefully
    {
        yearDataBase[currentYear].ejectEColi = (yearDataBase[currentYear].fish.production * yearDataBase[currentYear].fish.E_COL_OTH / 100) +
                                                (yearDataBase[currentYear].agroCulture.production * yearDataBase[currentYear].agroCulture.PHS_OTH / 100) +
                                                (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.E_COL_OTH / 100) +
                                                (yearDataBase[currentYear].E_COL_OTH_POP * yearDataBase[currentYear].population);
        yearDataBase[currentYear].ejectOrg = (yearDataBase[currentYear].paperfactory.production * yearDataBase[currentYear].paperfactory.ORG_OTH / 100) +
                                            (yearDataBase[currentYear].fish.production * yearDataBase[currentYear].fish.ORG_OTH / 100) +
                                            (yearDataBase[currentYear].agroCulture.production * yearDataBase[currentYear].agroCulture.ORG_OTH / 100) +
                                            (yearDataBase[currentYear].aquaCulture.production * yearDataBase[currentYear].aquaCulture.ORG_OTH / 100) +
                                            (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.ORG_OTH / 100) +
                                            (yearDataBase[currentYear].ORG_OTH_POP * yearDataBase[currentYear].population);
        yearDataBase[currentYear].ejectPhs = (yearDataBase[currentYear].agroCulture.production * yearDataBase[currentYear].agroCulture.PHS_OTH / 100) +
                                                (yearDataBase[currentYear].aquaCulture.production * yearDataBase[currentYear].aquaCulture.PHS_OTH / 100);

    }

    private void ResediuEjectCacl(int currentYear)
    {
        yearDataBase[currentYear].residueEColi = yearDataBase[currentYear - 1].residueEColi + yearDataBase[currentYear].ejectEColi - yearDataBase[currentYear].bioCleaning.production;
        yearDataBase[currentYear].residueOrg = yearDataBase[currentYear - 1].residueOrg + yearDataBase[currentYear].ejectOrg - yearDataBase[currentYear].chemCleaning.production;
        yearDataBase[currentYear].residuePhs = yearDataBase[currentYear - 1].residuePhs + yearDataBase[currentYear].ejectPhs;

    }


    private void LifespanCalc(int currentYear)
    {
        yearDataBase[currentYear].lifespan = (75.0f * yearDataBase[currentYear].qualityOfEnv);
    }

    private void DegrCalc(int currentYear)
    {
        float Res = -0.040000f * (1 - Mathf.Pow(1000f / yearDataBase[currentYear].residueOrg, -0.300000f));
        Res = Res - 0.010000f * (1 - Mathf.Pow(1000f / yearDataBase[currentYear].residueEColi, -0.200000f));
        Res = Res + 0.010000f * (1 - Mathf.Pow(1000f / yearDataBase[currentYear].residuePhs, -0.300000f));
        Res = Res * 2;
        //yearDataBase[currentYear].degr = (int)(Res * 1000);
        //Debug.Log("RES" + Res);
        yearDataBase[currentYear].degr = Res * 1000; // Maybe need make result as int
    }


    void InvestCalc(int currentYear, List<float> UIInv)
    {
        PrintList(UIInv);
        //Debug.Log("Year= "+currentYear);
        yearDataBase[currentYear].paperfactory.investments = UIInv[0];
        yearDataBase[currentYear].fish.investments = UIInv[1];
        yearDataBase[currentYear].aquaCulture.investments = UIInv[2];
        yearDataBase[currentYear].agroCulture.investments = UIInv[3];
        yearDataBase[currentYear].tourism.investments = UIInv[4];
        yearDataBase[currentYear].chemCleaning.investments = UIInv[5];
        yearDataBase[currentYear].bioCleaning.investments = UIInv[6];
    }




    public void PreCalc()
    {
        yearDataBase[0].unemploymentRate = 100 - yearDataBase[0].employmentRate;
        yearDataBase[0].pop_incM = yearDataBase[0].pop_incM * yearDataBase[0].qualityOfEnv;

    }



    // [Action in Frame 95]
    public void MapCalc(int currentYear)
    {

        float loc2 = yearDataBase[currentYear].degr - yearDataBase[currentYear - 1].degr;
        //DegrR(_loc2); ToDo reaction
        if (loc2 > 0)
        {
            float Melk = (float)(loc2 * 0.25f);
            float Plag = (float)(loc2 * 0.25f);
            float Sea = (float)(loc2 * 0.25f);
            float PrirF = (float)(loc2 * 0.12f);
            float PrirL = loc2 - Sea - Melk - Plag - PrirF;
            int ost = ModifMMap(2, 7, (int)Melk);
            yearDataBase[currentYear].degrSea = yearDataBase[currentYear - 1].degrSea + (Melk - (float)ost);
            Plag = Plag + (float)ost;
            ost = ModifMMap(3, 8, (int)Plag);
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear - 1].degrLand + (Plag - (float)ost);
            Sea = Sea + (float)ost;
            ost = ModifMMap(1, 6, (int)Sea);
            yearDataBase[currentYear].degrSea = yearDataBase[currentYear - 1].degrSea + (Sea - (float)ost);
            PrirF = PrirF + (float)ost;
            ost = ModifMMap(4, 9, (int)PrirF);
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear - 1].degrLand + (PrirF - (float)ost);
            PrirL = PrirL + (float)ost;
            ost = ModifMMap(14, 9, (int)PrirL);
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear - 1].degrLand + (PrirL - (float)ost);
            //Debug.Log("ost_for_forest=" + ost);
            if (ost > 0)
            {
                ost = ModifMMap(4, 9, ost);
            } // end if
              //Debug.Log("ost_all=" + ost);

            if (ost > 0)
            {
                // AddTextInf("<br><b>" + MSG_endprir + "</b>");
                // MC_msg.MSG_bot.text = MSG_endprir;
                is_over = true;
                //Debug.Log("enter at some place for making interaction with UI 1 //TODO ");
            } // end if
        }
        else
        {
            loc2 = Mathf.Abs(loc2);
            var Melk = (float)(loc2 * 0.250000);
            var Plag = (float)(loc2 * 0.250000);
            var Sea = (float)(loc2 * 0.250000);
            var PrirF = (float)(loc2 * 0.120000);
            var PrirL = loc2 - Sea - Melk - Plag - PrirF;
            int ost = ModifMMap(7, 2, (int)(Mathf.Abs(Melk)));
            // trace ("Melk=" + Melk + "  ost=" + ost);
            // Debug.Log("Melk= " + Melk + " ost=" + ost);
            yearDataBase[currentYear].degrSea = yearDataBase[currentYear - 1].degrSea + (Melk - ost);
            Plag = Plag + ost;
            ost = ModifMMap(8, 3, (int)(Mathf.Abs(Plag)));
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear - 1].degrLand + (Plag - ost);
            Sea = Sea + ost;
            ost = ModifMMap(6, 1, (int)(Mathf.Abs(Sea)));
            yearDataBase[currentYear].degrSea = yearDataBase[currentYear - 1].degrSea + (Sea - ost);
            PrirF = PrirF + ost;
            ost = ModifMMap(9, 4, (int)(Mathf.Abs(PrirF)));
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear - 1].degrLand + (PrirF - ost);
            PrirL = PrirL + ost;
            ost = ModifMMap(9, 14, (int)(Mathf.Abs(PrirL)));
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear - 1].degrLand + (PrirL - ost);

        } // end else if
        float loc3 = (yearDataBase[currentYear].tourism.capital - yearDataBase[currentYear - 1].tourism.capital) / yearDataBase[currentYear].turUCap;
        //TurR(_loc3);
        if (loc3 > 0)
        {
            float Plag = (float)(loc3 * 0.25);
            float Prir = loc3 - Plag;
            int ost = ModifMMap(3, 12, (int)Plag);
            Prir = Prir + ost;
            ost = ModifMMap(4, 13, (int)Prir);
            if (ost > 0)
            {
                is_over = true;
                // AddTextInf("<br><b>" + MSG_endres + "</b>");
                // MC_msg.MSG_bot.text = MSG_endres;
                //Debug.Log("enter at some place for making interaction with UI 2 //TODO");
            } // end if
        }
        else
        {
            float Plag = (float)(loc3 * 0.250000);
            float Prir = loc3 - Plag;
            int ost = ModifMMap(12, 3, (int)(Mathf.Abs(Plag)));
            Prir = Prir + ost;
            ost = ModifMMap(13, 4, (int)(Mathf.Abs(Prir)));
        } // end else if
        float Agro = (yearDataBase[currentYear].agroCulture.capital - yearDataBase[currentYear - 1].agroCulture.capital) / yearDataBase[currentYear].agroUCap;
        //AgroR(Agro);
        Debug.Log("AGRO= " + Agro);
        if (Agro > 0)
        {
            int ost = ModifMMap(14, 5, (int)(Agro));
            ost = ModifMMap(4, 5, (int)(Mathf.Abs(ost)));
            if (ost > 0)
            {
                is_over = true;
                // AddTextInf("<br><b>" + MSG_endres + "</b>");
                // MC_msg.MSG_bot.text = MSG_endres;
                //Debug.Log("enter at some place for making interaction with UI 3 //TODO");
            } // end if
        }
        else
        {
            float Flug = (float)(Agro * 0.500000);
            float Fles = Agro - Flug;
            int ost = ModifMMap(5, 14, (int)(Mathf.Abs(Flug)));
            Fles = Fles + ost;
            ost = ModifMMap(5, 4, (int)(Mathf.Abs(Fles)));
        } // end else if
        float Ship = (yearDataBase[currentYear].fish.capital - yearDataBase[currentYear - 1].fish.capital) / yearDataBase[currentYear].shipUCap;
        // FishR(Ship);
        if (Ship > 0)
        {
            var Sea = (int)(Ship * 0.750000);
            int ost = ModifMMap(1, 10, (int)(Sea));
            float Melk = Ship - Sea + ost;
            ost = ModifMMap(2, 11, (int)(Melk));
            if (ost > 0)
            {
                is_over = true;
                // AddTextInf("<br><b>" + MSG_endres + "</b>");
                // MC_msg.MSG_bot.text = MSG_endres;
                //Debug.Log("enter at some place for making interaction with UI 4 //TODO");
            } // end if
        }
        else
        {
            var Sea = (int)(Ship * 0.750000);
            var Melk = (int)(Ship) - Sea;
            int ost = ModifMMap(10, 1, (int)(Mathf.Abs(Sea)));
            Melk = Melk + ost;
            ost = ModifMMap(11, 2, (int)(Mathf.Abs(Melk)));
        } // end else if
          //CbkR(_loc1.CapPar1[_loc1.year]);
          // if (_loc1.PribPar1[_loc1.year] < 0)
          // {
          //     AddTextInf(ALT_cbkMC + ": " + MSG_ubi);
          // } // end if
          // if (_loc1.PribPar2[_loc1.year] < 0)
          // {
          //     AddTextInf(ALT_ribMC + ": " + MSG_ubi);
          // } // end if
          // AcvaFermR(_loc1.CapPar3[_loc1.year]);
          // if (_loc1.PribPar3[_loc1.year] < 0)
          // {
          //     AddTextInf(ALT_aqMC + ": " + MSG_ubi);
          // } // end if
          // if (_loc1.PribPar4[_loc1.year] < 0)
          // {
          //     AddTextInf(ALT_agroMC + ": " + MSG_ubi);
          // } // end if
          // if (_loc1.PribPar5[_loc1.year] < 0)
          // {
          //     AddTextInf(ALT_turMC + ": " + MSG_ubi);
          // } // end if
          //Debug.Log("enter at some place for making interaction with UI 4 //TODO");

        //BioClnR(_loc1.CapPar7[_loc1.year]);
        //ChemClnR(_loc1.CapPar6[_loc1.year]);

        QualEnvCalc(currentYear);
        HumDevIndCacl(currentYear);
        LifespanCalc(currentYear);

        // HDevR();    
        // OcrSrR();
        // TestTime();
        // MC_msg.Year_tm.text = _root.MSG_year + " " + _loc1.year + " " + _root.MSG_of + " " + _loc1.endYear;
        // MC_msg.I1.text = _loc1.Budt[_loc1.year];
        // MC_msg.I2.text = _loc1.FishAm[_loc1.year];
        // MC_msg.I3.text = _loc1.NasAm[_loc1.year];
        // MC_msg.U1.text = _loc1.DohSumNDN[_loc1.year];
        // MC_msg.U2.text = _loc1.QuolOcrSr[_loc1.year];
        // MC_msg.U3.text = _loc1.HDev[_loc1.year];
        // EndGame();

    } // End of the function


    private int ModifMMap(int old_index, int new_index, int count)
    {
        while (count > 0)
        {
            AnMMap(old_index);

            if (array_old.Count == 0) //
            {
                break;
            }
            else
            {
                RandMMap(old_index, new_index);
            } // end else if
            count--;
        } // end while
        return (count);
    } // End of the function


    private void AnMMap(int old_index)
    {
        array_old.Clear();
        for (int i = 0; i < board.rows; i++)
        {
            for (int j = 0; j < board.columns; j++)
            {
                if (board.array2d[j][i] == old_index)
                {
                    array_old.Add((j, i));
                }
            }
        }
    }

    private void RandMMap(int old_index, int new_index)
    {
        int numb = (int)(Random.value * array_old.Count);
        //++_global.all_num;
        //int column = _global.OldArr[numb][0];
        //int row = _global.OldArr[numb][1];
        int column = array_old[numb].Item1;
        int row = array_old[numb].Item2;
        board.array2d[column][row] = new_index;
        // eval(base + "." + column + "." + row + "." + "icon").gotoAndStop(new_index);
    } // End of the function

    public List<float> GetValueStatList(string param)
    {

        return statDict[param];
    }
    private void InitDict()
    {
        statDict["pf_capital"] = new List<float>();
        statDict["pf_invest"] = new List<float>();
        statDict["pf_production"] = new List<float>();
        statDict["pf_amortization"] = new List<float>();
        statDict["pf_income"] = new List<float>();
        statDict["pf_profit"] = new List<float>();
        statDict["pf_toBudget"] = new List<float>();
        statDict["pf_numJobs"] = new List<float>();
        statDict["pf_reqJobs"] = new List<float>();

        statDict["f_capital"] = new List<float>();
        statDict["f_invest"] = new List<float>();
        statDict["f_production"] = new List<float>();
        statDict["f_amortization"] = new List<float>();
        statDict["f_income"] = new List<float>();
        statDict["f_profit"] = new List<float>();
        statDict["f_toBudget"] = new List<float>();
        statDict["f_numJobs"] = new List<float>();
        statDict["f_reqJobs"] = new List<float>();

        statDict["aq_capital"] = new List<float>();
        statDict["aq_invest"] = new List<float>();
        statDict["aq_production"] = new List<float>();
        statDict["aq_amortization"] = new List<float>();
        statDict["aq_income"] = new List<float>();
        statDict["aq_profit"] = new List<float>();
        statDict["aq_toBudget"] = new List<float>();
        statDict["aq_numJobs"] = new List<float>();
        statDict["aq_reqJobs"] = new List<float>();

        statDict["ag_capital"] = new List<float>();
        statDict["ag_invest"] = new List<float>();
        statDict["ag_production"] = new List<float>();
        statDict["ag_amortization"] = new List<float>();
        statDict["ag_income"] = new List<float>();
        statDict["ag_profit"] = new List<float>();
        statDict["ag_toBudget"] = new List<float>();
        statDict["ag_numJobs"] = new List<float>();
        statDict["ag_reqJobs"] = new List<float>();



        statDict["t_capital"] = new List<float>();
        statDict["t_invest"] = new List<float>();
        statDict["t_production"] = new List<float>();
        statDict["t_amortization"] = new List<float>();
        statDict["t_income"] = new List<float>();
        statDict["t_profit"] = new List<float>();
        statDict["t_toBudget"] = new List<float>();
        statDict["t_numJobs"] = new List<float>();
        statDict["t_reqJobs"] = new List<float>();


        statDict["chem_capital"] = new List<float>();
        statDict["chem_invest"] = new List<float>();
        statDict["chem_production"] = new List<float>();
        statDict["chem_amortization"] = new List<float>();
        statDict["chem_income"] = new List<float>();
        statDict["chem_profit"] = new List<float>();
        statDict["chem_toBudget"] = new List<float>();
        statDict["chem_numJobs"] = new List<float>();
        statDict["chem_reqJobs"] = new List<float>();


        statDict["bio_capital"] = new List<float>();
        statDict["bio_invest"] = new List<float>();
        statDict["bio_production"] = new List<float>();
        statDict["bio_amortization"] = new List<float>();
        statDict["bio_income"] = new List<float>();
        statDict["bio_profit"] = new List<float>();
        statDict["bio_toBudget"] = new List<float>();
        statDict["bio_numJobs"] = new List<float>();
        statDict["bio_reqJobs"] = new List<float>();

        statDict["fishAmount"] = new List<float>();
        statDict["ejectEColi"] = new List<float>();
        statDict["ejectOrg"] = new List<float>();
        statDict["ejectPhs"] = new List<float>();
        statDict["residueEColi"] = new List<float>();
        statDict["residueOrg"] = new List<float>();
        statDict["residuePhs"] = new List<float>();
        statDict["degr"] = new List<float>();
        statDict["degrLand"] = new List<float>();
        statDict["degrSea"] = new List<float>();
        statDict["budget"] = new List<float>();
        statDict["moneySpend"] = new List<float>();
        statDict["moneyLeft"] = new List<float>();
        statDict["incomeSum"] = new List<float>();
        statDict["capitalSum"] = new List<float>();
        statDict["incomeSumPerHum"] = new List<float>();
        statDict["population"] = new List<float>();
        statDict["employmentRate"] = new List<float>();
        statDict["unemploymentRate"] = new List<float>();
        statDict["jobsAmSum"] = new List<float>();
        statDict["JobsReqSum"] = new List<float>();
        statDict["ablePopSum"] = new List<float>();
        statDict["lifespan"] = new List<float>();
        statDict["humDevInd"] = new List<float>();
        statDict["qualityOfEnv"] = new List<float>();
    }
    private void PutAllInfoToDict(int currentYear)
    {
        statDict["pf_capital"].Add(yearDataBase[currentYear].paperfactory.capital);
        statDict["pf_invest"].Add(yearDataBase[currentYear].paperfactory.investments);
        statDict["pf_production"].Add(yearDataBase[currentYear].paperfactory.production);
        statDict["pf_amortization"].Add(yearDataBase[currentYear].paperfactory.amortization);
        statDict["pf_income"].Add(yearDataBase[currentYear].paperfactory.income);
        statDict["pf_profit"].Add(yearDataBase[currentYear].paperfactory.profit);
        statDict["pf_toBudget"].Add(yearDataBase[currentYear].paperfactory.toBudget);
        statDict["pf_numJobs"].Add(yearDataBase[currentYear].paperfactory.numJobs);
        statDict["pf_reqJobs"].Add(yearDataBase[currentYear].paperfactory.reqJobs);

        statDict["f_capital"].Add(yearDataBase[currentYear].fish.capital);
        statDict["f_invest"].Add(yearDataBase[currentYear].fish.investments);
        statDict["f_production"].Add(yearDataBase[currentYear].fish.production);
        statDict["f_amortization"].Add(yearDataBase[currentYear].fish.amortization);
        statDict["f_income"].Add(yearDataBase[currentYear].fish.income);
        statDict["f_profit"].Add(yearDataBase[currentYear].fish.profit);
        statDict["f_toBudget"].Add(yearDataBase[currentYear].fish.toBudget);
        statDict["f_numJobs"].Add(yearDataBase[currentYear].fish.numJobs);
        statDict["f_reqJobs"].Add(yearDataBase[currentYear].fish.reqJobs);

        statDict["aq_capital"].Add(yearDataBase[currentYear].aquaCulture.capital);
        statDict["aq_invest"].Add(yearDataBase[currentYear].aquaCulture.investments);
        statDict["aq_production"].Add(yearDataBase[currentYear].aquaCulture.production);
        statDict["aq_amortization"].Add(yearDataBase[currentYear].aquaCulture.amortization);
        statDict["aq_income"].Add(yearDataBase[currentYear].aquaCulture.income);
        statDict["aq_profit"].Add(yearDataBase[currentYear].aquaCulture.profit);
        statDict["aq_toBudget"].Add(yearDataBase[currentYear].aquaCulture.toBudget);
        statDict["aq_numJobs"].Add(yearDataBase[currentYear].aquaCulture.numJobs);
        statDict["aq_reqJobs"].Add(yearDataBase[currentYear].aquaCulture.reqJobs);

        statDict["ag_capital"].Add(yearDataBase[currentYear].agroCulture.capital);
        statDict["ag_invest"].Add(yearDataBase[currentYear].agroCulture.investments);
        statDict["ag_production"].Add(yearDataBase[currentYear].agroCulture.production);
        statDict["ag_amortization"].Add(yearDataBase[currentYear].agroCulture.amortization);
        statDict["ag_income"].Add(yearDataBase[currentYear].agroCulture.income);
        statDict["ag_profit"].Add(yearDataBase[currentYear].agroCulture.profit);
        statDict["ag_toBudget"].Add(yearDataBase[currentYear].agroCulture.toBudget);
        statDict["ag_numJobs"].Add(yearDataBase[currentYear].agroCulture.numJobs);
        statDict["ag_reqJobs"].Add(yearDataBase[currentYear].agroCulture.reqJobs);



        statDict["t_capital"].Add(yearDataBase[currentYear].tourism.capital);
        statDict["t_invest"].Add(yearDataBase[currentYear].tourism.investments);
        statDict["t_production"].Add(yearDataBase[currentYear].tourism.production);
        statDict["t_amortization"].Add(yearDataBase[currentYear].tourism.amortization);
        statDict["t_income"].Add(yearDataBase[currentYear].tourism.income);
        statDict["t_profit"].Add(yearDataBase[currentYear].tourism.profit);
        statDict["t_toBudget"].Add(yearDataBase[currentYear].tourism.toBudget);
        statDict["t_numJobs"].Add(yearDataBase[currentYear].tourism.numJobs);
        statDict["t_reqJobs"].Add(yearDataBase[currentYear].tourism.reqJobs);


        statDict["chem_capital"].Add(yearDataBase[currentYear].chemCleaning.capital);
        statDict["chem_invest"].Add(yearDataBase[currentYear].chemCleaning.investments);
        statDict["chem_production"].Add(yearDataBase[currentYear].chemCleaning.production);
        statDict["chem_amortization"].Add(yearDataBase[currentYear].chemCleaning.amortization);
        statDict["chem_income"].Add(yearDataBase[currentYear].chemCleaning.income);
        statDict["chem_profit"].Add(yearDataBase[currentYear].chemCleaning.profit);
        statDict["chem_toBudget"].Add(yearDataBase[currentYear].chemCleaning.toBudget);
        statDict["chem_numJobs"].Add(yearDataBase[currentYear].chemCleaning.numJobs);
        statDict["chem_reqJobs"].Add(yearDataBase[currentYear].chemCleaning.reqJobs);


        statDict["bio_capital"].Add(yearDataBase[currentYear].bioCleaning.capital);
        statDict["bio_invest"].Add(yearDataBase[currentYear].bioCleaning.investments);
        statDict["bio_production"].Add(yearDataBase[currentYear].bioCleaning.production);
        statDict["bio_amortization"].Add(yearDataBase[currentYear].bioCleaning.amortization);
        statDict["bio_income"].Add(yearDataBase[currentYear].bioCleaning.income);
        statDict["bio_profit"].Add(yearDataBase[currentYear].bioCleaning.profit);
        statDict["bio_toBudget"].Add(yearDataBase[currentYear].bioCleaning.toBudget);
        statDict["bio_numJobs"].Add(yearDataBase[currentYear].bioCleaning.numJobs);
        statDict["bio_reqJobs"].Add(yearDataBase[currentYear].bioCleaning.reqJobs);

        statDict["fishAmount"].Add(yearDataBase[currentYear].fishAmount);
        statDict["ejectEColi"].Add(yearDataBase[currentYear].ejectEColi);
        statDict["ejectOrg"].Add(yearDataBase[currentYear].ejectOrg);
        statDict["ejectPhs"].Add(yearDataBase[currentYear].ejectPhs);
        statDict["residueEColi"].Add(yearDataBase[currentYear].residueEColi);
        statDict["residueOrg"].Add(yearDataBase[currentYear].residueOrg);
        statDict["residuePhs"].Add(yearDataBase[currentYear].residuePhs);
        statDict["degr"].Add(yearDataBase[currentYear].degr);
        statDict["degrLand"].Add(yearDataBase[currentYear].degrLand);
        statDict["degrSea"].Add(yearDataBase[currentYear].degrSea);
        statDict["budget"].Add(yearDataBase[currentYear].budget);
        statDict["moneySpend"].Add(yearDataBase[currentYear].moneySpend);
        statDict["moneyLeft"].Add(yearDataBase[currentYear].moneyLeft);
        statDict["incomeSum"].Add(yearDataBase[currentYear].incomeSum);
        statDict["capitalSum"].Add(yearDataBase[currentYear].capitalSum);
        statDict["incomeSumPerHum"].Add(yearDataBase[currentYear].incomeSumPerHum);
        statDict["population"].Add(yearDataBase[currentYear].population);
        statDict["employmentRate"].Add(yearDataBase[currentYear].employmentRate);
        statDict["unemploymentRate"].Add(yearDataBase[currentYear].unemploymentRate);
        statDict["jobsAmSum"].Add(yearDataBase[currentYear].jobsAmSum);
        statDict["JobsReqSum"].Add(yearDataBase[currentYear].jobsReqSum);
        statDict["ablePopSum"].Add(yearDataBase[currentYear].ablePopSum);
        statDict["lifespan"].Add(yearDataBase[currentYear].lifespan);
        statDict["humDevInd"].Add(yearDataBase[currentYear].humDevInd);
        statDict["qualityOfEnv"].Add(yearDataBase[currentYear].qualityOfEnv);
    }
}

