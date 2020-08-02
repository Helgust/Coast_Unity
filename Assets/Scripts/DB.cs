﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class DB : MonoBehaviour
{
    public List<Year> yearDataBase = new List<Year>();
    public Board board;
    public List<(int , int)>  array_old = new List<(int,int)>();
    

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


    public void InitDB(string jsonString)
    {
        // for current moment size og list is locked by dev TODO: made it modifiable(изменяемым)
        Debug.Log("InitDB: Size of list" + yearDataBase.Count);
        Debug.Log("InitDB: File Exists: " + File.Exists(jsonString));
        string json = File.ReadAllText(jsonString);
        yearDataBase[0] = JsonConvert.DeserializeObject<Year>(json);
        PreCalc();
    }

    public void InitBoard(string jsonString)
    {
			Debug.Log("InitBoard: File Exists: " + File.Exists(jsonString));
			string json = File.ReadAllText(jsonString);
			board = JsonConvert.DeserializeObject<Board>(json);
            /* for (int i = 0; i < 20; i++)
            {
                Debug.Log(board.array2d[19][i]);
            } */
            
    }


    //Расчет амотризационных отчислений по отраслям
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
    //Расчет количества денежжных ресурсов в этом году
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
        yearDataBase[currentYear].capitalSum =  yearDataBase[currentYear].paperfactory.capital +
                                                yearDataBase[currentYear].fish.capital +
                                                yearDataBase[currentYear].aquaCulture.capital +
                                                yearDataBase[currentYear].agroCulture.capital +
                                                yearDataBase[currentYear].tourism.capital + 
                                                yearDataBase[currentYear].chemCleaning.capital +
                                                yearDataBase[currentYear].bioCleaning.capital;
    }

    //Расчет требуемого количества рабочих мест на конкретном предприятии
    private void JobsReqCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.reqJobs = (int)(yearDataBase[currentYear].paperfactory.NUM_JOB_PER_CAP * yearDataBase[currentYear].paperfactory.capital);
        yearDataBase[currentYear].fish.reqJobs = (int)(yearDataBase[currentYear].fish.NUM_JOB_PER_CAP * yearDataBase[currentYear].fish.capital);
        yearDataBase[currentYear].aquaCulture.reqJobs = (int)(yearDataBase[currentYear].aquaCulture.NUM_JOB_PER_CAP * yearDataBase[currentYear].aquaCulture.capital);
        yearDataBase[currentYear].agroCulture.reqJobs = (int)(yearDataBase[currentYear].agroCulture.NUM_JOB_PER_CAP * yearDataBase[currentYear].agroCulture.capital);
        yearDataBase[currentYear].tourism.reqJobs = (int)(yearDataBase[currentYear].tourism.NUM_JOB_PER_CAP * yearDataBase[currentYear].tourism.capital);
        yearDataBase[currentYear].chemCleaning.reqJobs = (int)(yearDataBase[currentYear].chemCleaning.NUM_JOB_PER_CAP * yearDataBase[currentYear].chemCleaning.capital);
        yearDataBase[currentYear].bioCleaning.reqJobs = (int)(yearDataBase[currentYear].bioCleaning.NUM_JOB_PER_CAP * yearDataBase[currentYear].bioCleaning.capital);
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


    private void PopAmCalc(int currentYear)
    {
        yearDataBase[currentYear].population = yearDataBase[currentYear - 1].population * (int)(1 + yearDataBase[currentYear].POP_INC / 100);
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

    //Расчет требуемого количества востребованных рабочих мест на конкретном предприятии
    private void JobsAmCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.numJobs = (yearDataBase[currentYear].paperfactory.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].fish.numJobs = (yearDataBase[currentYear].fish.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].aquaCulture.numJobs = (yearDataBase[currentYear].aquaCulture.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].agroCulture.numJobs = (yearDataBase[currentYear].agroCulture.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].tourism.numJobs = (yearDataBase[currentYear].tourism.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].chemCleaning.numJobs = (yearDataBase[currentYear].chemCleaning.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].bioCleaning.numJobs = (yearDataBase[currentYear].bioCleaning.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;

    }

    private int ProdExpCalc(int ProdRez, int VolRes)

    {
        int Res;
        //ProdRez - Производственный резерв
        //VolRes - Объем сырья
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

    //Расчет объема производства без учета количества доступного сырья
    private void ProdCalc(int currentYear)
    {
        int temp1 = yearDataBase[currentYear].fish.AVG_LABOR_PROD * yearDataBase[currentYear].fish.numJobs;
        int temp2 = yearDataBase[currentYear].chemCleaning.AVG_LABOR_PROD * yearDataBase[currentYear].chemCleaning.numJobs;
        int temp3 = yearDataBase[currentYear].bioCleaning.AVG_LABOR_PROD * yearDataBase[currentYear].bioCleaning.numJobs;

        yearDataBase[currentYear].paperfactory.production = yearDataBase[currentYear].paperfactory.AVG_LABOR_PROD * yearDataBase[currentYear].paperfactory.numJobs * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].fish.production = ProdExpCalc(temp1, yearDataBase[currentYear - 1].fishAmount) * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].aquaCulture.production = yearDataBase[currentYear].aquaCulture.AVG_LABOR_PROD * yearDataBase[currentYear].aquaCulture.numJobs * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].agroCulture.production = yearDataBase[currentYear].agroCulture.AVG_LABOR_PROD * yearDataBase[currentYear].agroCulture.numJobs * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].tourism.production = yearDataBase[currentYear].tourism.AVG_LABOR_PROD * yearDataBase[currentYear].tourism.numJobs * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].chemCleaning.production = ProdExpCalc(temp2, ChemSens(currentYear));
        yearDataBase[currentYear].bioCleaning.production =  ProdExpCalc(temp3, BioSens(currentYear));
    }

    private void FishCalc(int currentYear)
    {
        yearDataBase[currentYear].fishAmount = yearDataBase[currentYear - 1].fishAmount + yearDataBase[currentYear - 1].fishAmount * yearDataBase[currentYear].FISH_INC / 100 * yearDataBase[currentYear].qualityOfEnv * (int)(2.600000 * Mathf.Exp(-1 * ((yearDataBase[currentYear-1].fishAmount - 2000) * (yearDataBase[currentYear-1].fishAmount - 2000)) / 180000)) - yearDataBase[currentYear].fish.production;

    }



    //Расчет доходов в этом году

    private void IncomeCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.income = yearDataBase[currentYear].paperfactory.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].paperfactory.production;
        yearDataBase[currentYear].fish.income = yearDataBase[currentYear].fish.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].fish.production;
        yearDataBase[currentYear].aquaCulture.income = yearDataBase[currentYear].aquaCulture.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].aquaCulture.production;
        yearDataBase[currentYear].agroCulture.income = yearDataBase[currentYear].agroCulture.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].agroCulture.production;
        yearDataBase[currentYear].tourism.income = yearDataBase[currentYear].tourism.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].tourism.production;
    }


    private void ProfitCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.profit = (int)((yearDataBase[currentYear].paperfactory.income - yearDataBase[currentYear].paperfactory.amortization) - (yearDataBase[currentYear].paperfactory.production * yearDataBase[currentYear].paperfactory.VAR_COSTS));
        yearDataBase[currentYear].fish.profit = (int)((yearDataBase[currentYear].fish.income - yearDataBase[currentYear].fish.amortization) - (yearDataBase[currentYear].fish.production * yearDataBase[currentYear].fish.VAR_COSTS));
        yearDataBase[currentYear].aquaCulture.profit = (int)((yearDataBase[currentYear].aquaCulture.income - yearDataBase[currentYear].aquaCulture.amortization) - (yearDataBase[currentYear].aquaCulture.production * yearDataBase[currentYear].aquaCulture.VAR_COSTS));
        yearDataBase[currentYear].agroCulture.profit = (int)((yearDataBase[currentYear].agroCulture.income - yearDataBase[currentYear].agroCulture.amortization) - (yearDataBase[currentYear].agroCulture.production * yearDataBase[currentYear].agroCulture.VAR_COSTS));
        yearDataBase[currentYear].tourism.profit = (int)((yearDataBase[currentYear].tourism.income - yearDataBase[currentYear].tourism.amortization) - (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.VAR_COSTS));
    }


    private void ToBudgCalc(int currentYear)
    {
        yearDataBase[currentYear].paperfactory.toBudget = yearDataBase[currentYear].paperfactory.income > 0 ? yearDataBase[currentYear].paperfactory.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].fish.toBudget = yearDataBase[currentYear].fish.income > 0 ? yearDataBase[currentYear].fish.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].aquaCulture.toBudget = yearDataBase[currentYear].aquaCulture.income > 0 ? yearDataBase[currentYear].aquaCulture.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].agroCulture.toBudget = yearDataBase[currentYear].agroCulture.income > 0 ? yearDataBase[currentYear].agroCulture.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].tourism.toBudget = yearDataBase[currentYear].tourism.income > 0 ? yearDataBase[currentYear].tourism.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;

    }

    private void HumDevIndCacl(int currentYear)
    {
        float Res =  33 * yearDataBase[currentYear].qualityOfEnv + 33 * (yearDataBase[currentYear].incomeSum / 25) + 33 * (yearDataBase[currentYear].employmentRate / 100);
        yearDataBase[currentYear].humDevInd = (int)(Res) ;
    }

    private void QualEnvCalc(int currentYear) // TODO Rewrite
    {
        
        int Sea_good = 0;
        int Sea_bed = 0;
        int Land_good = 0;
        int Land_bed = 0;
        AnMMap(1);
        Sea_good = Sea_good + array_old.Count;
        AnMMap(2);
        Sea_good = Sea_good + array_old.Count;
        AnMMap(10);
        Sea_good = Sea_good + array_old.Count;
        AnMMap(11);
        Sea_good = Sea_good + array_old.Count;
        AnMMap(6);
        Sea_bed = Sea_bed + array_old.Count;
        AnMMap(7);
        Sea_bed = Sea_bed + array_old.Count;
        AnMMap(6);
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
        Land_bed = Land_bed + array_old.Count;
        AnMMap(9);
        Land_bed = Land_bed + array_old.Count;
        float Res = (Sea_good - Sea_bed) / Sea_good * 0.100000f + (Land_good - Land_bed) / Land_good * 0.900000f;
        
        //return (int(Math.pow(Res, 3) * 100) / 100);
        yearDataBase[currentYear].qualityOfEnv = (int)((Mathf.Pow(Res, 3) * 100) / 100);
    }

    private void IncomeSumPerHumanCalc(int currentYear)
    {
        yearDataBase[currentYear].incomeSumPerHum = (int)(yearDataBase[currentYear].incomeSum / yearDataBase[currentYear].population * 1000) / 1000;
    }

    //Расчет суммарного дохода все отраслей (без очистных сооружений)
    private void IncomeSumCalc(int currentYear)
    {
        yearDataBase[currentYear].incomeSum =  yearDataBase[currentYear].paperfactory.income +
                                                   yearDataBase[currentYear].fish.income +
                                                   yearDataBase[currentYear].aquaCulture.income +
                                                   yearDataBase[currentYear].agroCulture.income +
                                                   yearDataBase[currentYear].tourism.income;
    }

    private void NewbudgetCalc(int currentYear)
    {
        Debug.Log("NEW budget");
        yearDataBase[currentYear].budget = yearDataBase[currentYear-1].moneyLeft*(1 + yearDataBase[currentYear].BANK_PROCENT ) +
                                           yearDataBase[currentYear-1].paperfactory.toBudget +
                                           yearDataBase[currentYear-1].fish.toBudget +
                                           yearDataBase[currentYear-1].aquaCulture.toBudget +
                                           yearDataBase[currentYear-1].agroCulture.toBudget +
                                           yearDataBase[currentYear-1].tourism.toBudget;
    }


    //Расчет остатка и общей распределенной суммы
    private void MoneyCalc(int currentYear)
    {
        //ADD MoneySpend Calc
        yearDataBase[currentYear].moneySpend = 0;
        // yearDataBase[currentYear].budget = yearDataBase[currentYear-1].budget - yearDataBase[currentYear].moneySpend;
        yearDataBase[currentYear].moneyLeft = yearDataBase[currentYear-1].moneyLeft;

    }

    //Расчет количества трудоспособного населения
    private void AbleToJobPopCalc(int currentYear)
    {

        yearDataBase[currentYear].ablePopSum = (int)((yearDataBase[currentYear].population * yearDataBase[currentYear].ABLE_TO_LABOR)/100);

    }
    //Поправка на чуствительность технологии к переработке (Химическая очистка)
    private int ChemSens(int currentYear)
    {
        if (yearDataBase[currentYear-1].residueOrg < yearDataBase[currentYear].chemCleaning.CHEM_CLEAN_FACT)
        {
            return 0;
        }
        else
        {
            return yearDataBase[currentYear-1].residueOrg;
        }
    }

    //Поправка на чуствительность технологии к переработке (Биологическая очистка)
    private int BioSens(int currentYear)
    {
        if (yearDataBase[currentYear-1].residueEColi < yearDataBase[currentYear].bioCleaning.BIO_CLEAN_FACT)
        {
            return 0;
        }
        else
        {
            return yearDataBase[currentYear-1].residueEColi;
        }
    }

    //Расчет уровня занятости, %
    private void EmployRateCalc(int currentYear)
    {
        yearDataBase[currentYear].employmentRate = (int)(yearDataBase[currentYear].jobsAmSum/yearDataBase[currentYear].ablePopSum*100);
    }
     //Расчет уровня безработицы, %
    private void UnEmployRateCalc(int currentYear)
    {
        yearDataBase[currentYear].unemploymentRate = 100 - yearDataBase[currentYear].employmentRate;
    }

    //Расчет выброса загрязнителей
    private void DirtEjectCacl(int currentYear)
    {
        yearDataBase[currentYear].ejectEColi = (yearDataBase[currentYear].fish.production * yearDataBase[currentYear].fish.E_COL_OTH/100) + 
                                                (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.E_COL_OTH/100) + 
                                                (yearDataBase[currentYear].E_COL_OTH_POP * yearDataBase[currentYear].population);
        yearDataBase[currentYear].ejectOrg = (yearDataBase[currentYear].agroCulture.production * yearDataBase[currentYear].agroCulture.ORG_OTH/100) + 
                                            (yearDataBase[currentYear].aquaCulture.production * yearDataBase[currentYear].aquaCulture.ORG_OTH/100) +
                                            (yearDataBase[currentYear].ORG_OTH_POP * yearDataBase[currentYear].population);
        yearDataBase[currentYear].ejectPhs = (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.PHS_OTH/100);

    }

    private void ResediuEjectCacl(int currentYear)
    {
        yearDataBase[currentYear].residueEColi = yearDataBase[currentYear-1].residueEColi + yearDataBase[currentYear].ejectEColi - yearDataBase[currentYear].bioCleaning.production;
        yearDataBase[currentYear].residueOrg = yearDataBase[currentYear-1].residueOrg + yearDataBase[currentYear].ejectOrg - yearDataBase[currentYear].chemCleaning.production;
        yearDataBase[currentYear].residuePhs = yearDataBase[currentYear-1].residuePhs + yearDataBase[currentYear].ejectPhs;

    }

    private void PopIncCalc(int currentYear)
    {
        yearDataBase[currentYear].POP_INC =  yearDataBase[currentYear-1].POP_INC * yearDataBase[currentYear-1].qualityOfEnv;
    }
    
    private void LifespanCalc(int currentYear)
    {
         yearDataBase[currentYear].lifespan = (int)(75 * yearDataBase[currentYear].qualityOfEnv);
    }

    private void DegrCalc(int currentYear)
    {
        float Res = -0.040000f * (1 - Mathf.Pow(1000f / yearDataBase[currentYear].residueOrg, -0.300000f));
        Res = Res - 0.010000f * (1 - Mathf.Pow(1000f / yearDataBase[currentYear].residueEColi, -0.200000f));
        Res = Res + 0.010000f * (1 - Mathf.Pow(1000f / yearDataBase[currentYear].residuePhs, -0.300000f));
        Res = Res * 2;
        // yearDataBase[currentYear].degr = (int)(Res * 1000);
        yearDataBase[currentYear].degr = 0;
    }

    private void MoveConst(int currentYear)
    {
        yearDataBase[currentYear].FISH_INC = yearDataBase[currentYear-1].FISH_INC;
        yearDataBase[currentYear].PROFIT_TAX = yearDataBase[currentYear-1].PROFIT_TAX;
        yearDataBase[currentYear].ABLE_TO_LABOR = yearDataBase[currentYear-1].ABLE_TO_LABOR;
        yearDataBase[currentYear].BASE_COST_INC = yearDataBase[currentYear-1].BASE_COST_INC;
        yearDataBase[currentYear].BANK_PROCENT = yearDataBase[currentYear-1].BANK_PROCENT;
        yearDataBase[currentYear].E_COL_OTH_POP = yearDataBase[currentYear-1].E_COL_OTH_POP;
        yearDataBase[currentYear].ORG_OTH_POP = yearDataBase[currentYear-1].ORG_OTH_POP;
        yearDataBase[currentYear].shipUCap = yearDataBase[currentYear-1].shipUCap;
        yearDataBase[currentYear].agroUCap = yearDataBase[currentYear-1].agroUCap;
        yearDataBase[currentYear].turUCap = yearDataBase[currentYear-1].turUCap;
        //yearDataBase[currentYear].budget = yearDataBase[currentYear-1].budget;


        yearDataBase[currentYear].paperfactory.investments = 0;
        yearDataBase[currentYear].fish.investments = 0;
        yearDataBase[currentYear].aquaCulture.investments = 0;
        yearDataBase[currentYear].agroCulture.investments = 0;
        yearDataBase[currentYear].tourism.investments = 0;
        yearDataBase[currentYear].chemCleaning.investments = 0;
        yearDataBase[currentYear].bioCleaning.investments = 0;

        yearDataBase[currentYear].paperfactory.CAP_LIFE_TIME = yearDataBase[currentYear-1].paperfactory.CAP_LIFE_TIME;
        yearDataBase[currentYear].paperfactory.NUM_JOB_PER_CAP = yearDataBase[currentYear-1].paperfactory.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].paperfactory.VAR_COSTS = yearDataBase[currentYear-1].paperfactory.VAR_COSTS;
        yearDataBase[currentYear].paperfactory.BASE_COST = yearDataBase[currentYear-1].paperfactory.BASE_COST;
        yearDataBase[currentYear].paperfactory.AVG_LABOR_PROD = yearDataBase[currentYear-1].paperfactory.AVG_LABOR_PROD;

        yearDataBase[currentYear].fish.CAP_LIFE_TIME = yearDataBase[currentYear-1].fish.CAP_LIFE_TIME;
        yearDataBase[currentYear].fish.NUM_JOB_PER_CAP = yearDataBase[currentYear-1].fish.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].fish.VAR_COSTS = yearDataBase[currentYear-1].fish.VAR_COSTS;
        yearDataBase[currentYear].fish.BASE_COST = yearDataBase[currentYear-1].fish.BASE_COST;
        yearDataBase[currentYear].fish.AVG_LABOR_PROD = yearDataBase[currentYear-1].fish.AVG_LABOR_PROD;
        yearDataBase[currentYear].fish.E_COL_OTH = yearDataBase[currentYear-1].fish.E_COL_OTH;

        yearDataBase[currentYear].aquaCulture.CAP_LIFE_TIME = yearDataBase[currentYear-1].aquaCulture.CAP_LIFE_TIME;
        yearDataBase[currentYear].aquaCulture.NUM_JOB_PER_CAP = yearDataBase[currentYear-1].aquaCulture.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].aquaCulture.VAR_COSTS = yearDataBase[currentYear-1].aquaCulture.VAR_COSTS;
        yearDataBase[currentYear].aquaCulture.BASE_COST = yearDataBase[currentYear-1].aquaCulture.BASE_COST;
        yearDataBase[currentYear].aquaCulture.AVG_LABOR_PROD = yearDataBase[currentYear-1].aquaCulture.AVG_LABOR_PROD;
        yearDataBase[currentYear].aquaCulture.ORG_OTH = yearDataBase[currentYear-1].aquaCulture.ORG_OTH;

        yearDataBase[currentYear].agroCulture.CAP_LIFE_TIME = yearDataBase[currentYear-1].agroCulture.CAP_LIFE_TIME;
        yearDataBase[currentYear].agroCulture.NUM_JOB_PER_CAP = yearDataBase[currentYear-1].agroCulture.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].agroCulture.VAR_COSTS = yearDataBase[currentYear-1].agroCulture.VAR_COSTS;
        yearDataBase[currentYear].agroCulture.BASE_COST = yearDataBase[currentYear-1].agroCulture.BASE_COST;
        yearDataBase[currentYear].agroCulture.AVG_LABOR_PROD = yearDataBase[currentYear-1].agroCulture.AVG_LABOR_PROD;
        yearDataBase[currentYear].agroCulture.ORG_OTH = yearDataBase[currentYear-1].agroCulture.ORG_OTH;

        yearDataBase[currentYear].tourism.CAP_LIFE_TIME = yearDataBase[currentYear-1].tourism.CAP_LIFE_TIME;
        yearDataBase[currentYear].tourism.NUM_JOB_PER_CAP = yearDataBase[currentYear-1].tourism.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].tourism.VAR_COSTS = yearDataBase[currentYear-1].tourism.VAR_COSTS;
        yearDataBase[currentYear].tourism.BASE_COST = yearDataBase[currentYear-1].tourism.BASE_COST;
        yearDataBase[currentYear].tourism.AVG_LABOR_PROD = yearDataBase[currentYear-1].tourism.AVG_LABOR_PROD;
        yearDataBase[currentYear].tourism.E_COL_OTH = yearDataBase[currentYear-1].tourism.E_COL_OTH;
        yearDataBase[currentYear].tourism.PHS_OTH = yearDataBase[currentYear-1].tourism.PHS_OTH;

        yearDataBase[currentYear].chemCleaning.CAP_LIFE_TIME = yearDataBase[currentYear-1].chemCleaning.CAP_LIFE_TIME;
        yearDataBase[currentYear].chemCleaning.NUM_JOB_PER_CAP = yearDataBase[currentYear-1].chemCleaning.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].chemCleaning.AVG_LABOR_PROD = yearDataBase[currentYear-1].chemCleaning.AVG_LABOR_PROD;
        yearDataBase[currentYear].chemCleaning.CHEM_CLEAN_FACT = yearDataBase[currentYear-1].chemCleaning.CHEM_CLEAN_FACT;

        yearDataBase[currentYear].bioCleaning.CAP_LIFE_TIME = yearDataBase[currentYear-1].bioCleaning.CAP_LIFE_TIME;
        yearDataBase[currentYear].bioCleaning.NUM_JOB_PER_CAP = yearDataBase[currentYear-1].bioCleaning.NUM_JOB_PER_CAP;
        yearDataBase[currentYear].bioCleaning.AVG_LABOR_PROD = yearDataBase[currentYear-1].bioCleaning.AVG_LABOR_PROD;
        yearDataBase[currentYear].bioCleaning.BIO_CLEAN_FACT = yearDataBase[currentYear-1].bioCleaning.BIO_CLEAN_FACT;
        
        yearDataBase[currentYear].qualityOfEnv = yearDataBase[currentYear-1].qualityOfEnv;
        
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
        DegrCalc(currentYear); // TODO
        IncomeCalc(currentYear);
        IncomeSumCalc(currentYear);
        ProfitCalc(currentYear);
        ToBudgCalc(currentYear);
        NewbudgetCalc(currentYear);
        IncomeSumPerHumanCalc(currentYear);
        // HumDevIndCacl(currentYear);
        // QualEnvCalc(currentYear); 
        // LifespanCalc(currentYear);      
    }

     public void PreCalc()
    {
        yearDataBase[0].unemploymentRate = 100 - yearDataBase[0].employmentRate;
        yearDataBase[0].POP_INC    = yearDataBase[0].POP_INC * yearDataBase[0].qualityOfEnv;  
       
    } 



    // [Action in Frame 95]
    public void MapCalc(int currentYear)
    {
        int loc2;
        loc2 = yearDataBase[currentYear].degr - yearDataBase[currentYear-1].degr;
        //DegrR(_loc2);
        if (loc2 > 0)
        {
            int  Melk = (int)(loc2 * 0.250000);
            int  Plag = (int)(loc2 * 0.250000);
            int  Sea = (int)(loc2 * 0.250000);
            int  PrirF = (int)(loc2 * 0.120000);
            int  PrirL = loc2 - Sea - Melk - Plag - PrirF;
            int ost = ModifMMap(2, 7, Melk);
            yearDataBase[currentYear].degrSea = yearDataBase[currentYear-1].degrSea + (Melk - ost);
            Plag = Plag + ost;
            ost = ModifMMap(3, 8, Plag);
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear-1].degrLand + (Plag - ost);
            Sea = Sea + ost;
            ost = ModifMMap(1, 6, Sea);
            yearDataBase[currentYear].degrSea = yearDataBase[currentYear-1].degrSea + (Sea - ost);
            PrirF = PrirF + ost;
            ost = ModifMMap(4, 9, PrirF);
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear-1].degrLand + (PrirF - ost);
            PrirL = PrirL + ost;
            ost = ModifMMap(14, 9, PrirL);
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear-1].degrLand + (PrirL - ost);
            Debug.Log("ost_for_forest=" + ost);
            if (ost > 0)
            {
                ost = ModifMMap(4, 9, ost);
            } // end if
            Debug.Log("ost_all=" + ost);
            
            if (ost > 0)
            {
                // AddTextInf("<br><b>" + MSG_endprir + "</b>");
                // MC_msg.MSG_bot.text = MSG_endprir;
                // _loc1.is_over = true;
                Debug.Log("enter at some place for making interaction with UI 1 //TODO ");
            } // end if
        }
        else
        {
            loc2 = Mathf.Abs(loc2);
            var Melk = (int)(loc2 * 0.250000);
            var Plag = (int)(loc2 * 0.250000);
            var Sea = (int)(loc2 * 0.250000);
            var PrirF = (int)(loc2 * 0.120000);
            var PrirL = loc2 - Sea - Melk - Plag - PrirF;
            int ost = ModifMMap(7, 2, (int)(Mathf.Abs(Melk)));
           // trace ("Melk=" + Melk + "  ost=" + ost);
            Debug.Log("Melk= " + Melk + " ost=" + ost);
            yearDataBase[currentYear].degrSea = yearDataBase[currentYear-1].degrSea + (Melk - ost);
            Plag = Plag + ost;
            ost = ModifMMap(8, 3, (int)(Mathf.Abs(Plag)));
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear-1].degrLand + (Plag - ost);
            Sea = Sea + ost;
            ost = ModifMMap(6, 1, (int)(Mathf.Abs(Sea)));
            yearDataBase[currentYear].degrSea = yearDataBase[currentYear-1].degrSea + (Sea - ost);
            PrirF = PrirF + ost;
            ost = ModifMMap(9, 4, (int)(Mathf.Abs(PrirF)));
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear-1].degrLand + (PrirF - ost);
            PrirL = PrirL + ost;
            ost = ModifMMap(9, 14, (int)(Mathf.Abs(PrirL)));
            yearDataBase[currentYear].degrLand = yearDataBase[currentYear-1].degrLand + (PrirL - ost);

        } // end else if
        int loc3 = (yearDataBase[currentYear].tourism.capital - yearDataBase[currentYear - 1].tourism.capital) / yearDataBase[currentYear].turUCap;
        //TurR(_loc3);
        if (loc3 > 0)
        {
            int Plag = (int)(loc3 * 0.250000);
            int Prir = loc3 - Plag;
            int ost = ModifMMap(3, 12, Plag);
            Prir = Prir + ost;
            ost = ModifMMap(4, 13, Prir);
            if (ost > 0)
            {
                // _loc1.is_over = true;
                // AddTextInf("<br><b>" + MSG_endres + "</b>");
                // MC_msg.MSG_bot.text = MSG_endres;
                Debug.Log("enter at some place for making interaction with UI 2 //TODO");
            } // end if
        }
        else
        {
            int Plag = (int)(loc3 * 0.250000);
            int Prir = loc3 - Plag;
            int ost = ModifMMap(12, 3, (int)(Mathf.Abs(Plag)));
            Prir = Prir + ost;
            ost = ModifMMap(13, 4, (int)(Mathf.Abs(Prir)));
        } // end else if
        int Agro =(yearDataBase[currentYear].agroCulture.capital - yearDataBase[currentYear - 1].agroCulture.capital) / yearDataBase[currentYear].agroUCap;
        //AgroR(Agro);
        if (Agro > 0)
        {
            int ost = ModifMMap(14, 5, (int)(Agro));
            ost = ModifMMap(4, 5, (int)(Mathf.Abs(ost)));
            if (ost > 0)
            {
                // _loc1.is_over = true;
                // AddTextInf("<br><b>" + MSG_endres + "</b>");
                // MC_msg.MSG_bot.text = MSG_endres;
                Debug.Log("enter at some place for making interaction with UI 3 //TODO");
            } // end if
        }
        else
        {
            int Flug = (int)(Agro * 0.500000);
            int Fles = Agro - Flug;
            int ost = ModifMMap(5, 14, (int)(Mathf.Abs(Flug)));
            Fles = Fles + ost;
            ost = ModifMMap(5, 4, (int)(Mathf.Abs(Fles)));
        } // end else if
        int Ship  =(yearDataBase[currentYear].fish.capital - yearDataBase[currentYear - 1].fish.capital) / yearDataBase[currentYear].shipUCap;
        // FishR(Ship);
        if (Ship > 0)
        {
            var Sea = (int)(Ship * 0.750000);
            int ost = ModifMMap(1, 10, (int)(Sea));
            int Melk = Ship - Sea + ost;
            ost = ModifMMap(2, 11, (int)(Melk));
            if (ost > 0)
            {
                // _loc1.is_over = true;
                // AddTextInf("<br><b>" + MSG_endres + "</b>");
                // MC_msg.MSG_bot.text = MSG_endres;
                Debug.Log("enter at some place for making interaction with UI 4 //TODO");
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
        Debug.Log("enter at some place for making interaction with UI 4 //TODO");

        //BioClnR(_loc1.CapPar7[_loc1.year]);
        //ChemClnR(_loc1.CapPar6[_loc1.year]);

         HumDevIndCacl(currentYear);
         QualEnvCalc(currentYear); 
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


    private int  ModifMMap(int old_index, int new_index, int count)
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
        int numb = (int) (Random.value * array_old.Count);
        //++_global.all_num;
        //int column = _global.OldArr[numb][0];
        //int row = _global.OldArr[numb][1];
        int column = array_old[numb].Item1;
        int row = array_old[numb].Item2;
        board.array2d[column][row] = new_index;
        // eval(base + "." + column + "." + row + "." + "icon").gotoAndStop(new_index);
    } // End of the function





}
