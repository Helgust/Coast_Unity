﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class YearsDB : MonoBehaviour
{
    public int currentYear;
    public List<Year> yearDataBase = new List<Year>();


    public void InitDB(string jsonString)
    {
        Debug.Log("File Exists" + File.Exists(jsonString));
        string json = File.ReadAllText(jsonString);
        yearDataBase[0] = JsonUtility.FromJson<Year>(json);
        currentYear = 1;
    }


    //Расчет амотризационных отчислений по отраслям
    public void AmorCacl()
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
    public void CapCalc()
    {
        yearDataBase[currentYear].paperfactory.capital = (yearDataBase[currentYear - 1].paperfactory.capital + yearDataBase[currentYear].paperfactory.investments) - yearDataBase[currentYear].paperfactory.amortization;
        yearDataBase[currentYear].fish.capital = (yearDataBase[currentYear - 1].fish.capital + yearDataBase[currentYear].fish.investments) - yearDataBase[currentYear].fish.amortization;
        yearDataBase[currentYear].aquaCulture.capital = (yearDataBase[currentYear - 1].aquaCulture.capital + yearDataBase[currentYear].aquaCulture.investments) - yearDataBase[currentYear].aquaCulture.amortization;
        yearDataBase[currentYear].agroCulture.capital = (yearDataBase[currentYear - 1].agroCulture.capital + yearDataBase[currentYear].agroCulture.investments) - yearDataBase[currentYear].agroCulture.amortization;
        yearDataBase[currentYear].tourism.capital = (yearDataBase[currentYear - 1].tourism.capital + yearDataBase[currentYear].tourism.investments) - yearDataBase[currentYear].tourism.amortization;
        yearDataBase[currentYear].chemCleaning.capital = (yearDataBase[currentYear - 1].chemCleaning.capital + yearDataBase[currentYear].chemCleaning.investments) - yearDataBase[currentYear].chemCleaning.amortization;
        yearDataBase[currentYear].bioCleaning.capital = (yearDataBase[currentYear - 1].bioCleaning.capital + yearDataBase[currentYear].bioCleaning.investments) - yearDataBase[currentYear].bioCleaning.amortization;
    }

    public void CapSumCalc()
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
    public void JobsReqCalc()
    {
        yearDataBase[currentYear].paperfactory.reqJobs = yearDataBase[currentYear].paperfactory.NUM_JOB_PER_CAP * yearDataBase[currentYear].paperfactory.capital;
        yearDataBase[currentYear].fish.reqJobs = yearDataBase[currentYear].fish.NUM_JOB_PER_CAP * yearDataBase[currentYear].fish.capital;
        yearDataBase[currentYear].aquaCulture.reqJobs = yearDataBase[currentYear].aquaCulture.NUM_JOB_PER_CAP * yearDataBase[currentYear].aquaCulture.capital;
        yearDataBase[currentYear].agroCulture.reqJobs = yearDataBase[currentYear].agroCulture.NUM_JOB_PER_CAP * yearDataBase[currentYear].agroCulture.capital;
        yearDataBase[currentYear].tourism.reqJobs = yearDataBase[currentYear].tourism.NUM_JOB_PER_CAP * yearDataBase[currentYear].tourism.capital;
        yearDataBase[currentYear].chemCleaning.reqJobs = yearDataBase[currentYear].chemCleaning.NUM_JOB_PER_CAP * yearDataBase[currentYear].chemCleaning.capital;
        yearDataBase[currentYear].bioCleaning.reqJobs = yearDataBase[currentYear].bioCleaning.NUM_JOB_PER_CAP * yearDataBase[currentYear].bioCleaning.capital;
    }

    public void JobsReqSumCalc()
    {
        yearDataBase[currentYear].jobsReqSum = yearDataBase[currentYear].paperfactory.reqJobs +
                                                  yearDataBase[currentYear].fish.reqJobs +
                                                  yearDataBase[currentYear].aquaCulture.reqJobs +
                                                  yearDataBase[currentYear].agroCulture.reqJobs +
                                                  yearDataBase[currentYear].tourism.reqJobs +
                                                  yearDataBase[currentYear].chemCleaning.reqJobs +
                                                  yearDataBase[currentYear].bioCleaning.reqJobs;
    }


    public void PopAmCalc()
    {
        yearDataBase[currentYear].population = yearDataBase[currentYear - 1].population * (1 + yearDataBase[currentYear].POP_INC / 100);
    }

    public void JobsAmOrig()
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
    public void JobsAmCalc()
    {
        yearDataBase[currentYear].paperfactory.numJobs = (yearDataBase[currentYear].paperfactory.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].fish.numJobs = (yearDataBase[currentYear].fish.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].aquaCulture.numJobs = (yearDataBase[currentYear].aquaCulture.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].agroCulture.numJobs = (yearDataBase[currentYear].agroCulture.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].tourism.numJobs = (yearDataBase[currentYear].tourism.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].chemCleaning.numJobs = (yearDataBase[currentYear].chemCleaning.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].bioCleaning.numJobs = (yearDataBase[currentYear].bioCleaning.reqJobs * yearDataBase[currentYear].jobsAmSum) / yearDataBase[currentYear].jobsReqSum;

    }

    public int ProdExpCalc(int ProdRez, int VolRes)

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
    public void ProdCalc()
    {
        int temp1 = yearDataBase[currentYear].fish.AVG_LABOR_PROD * yearDataBase[currentYear].fish.numJobs;
        int temp2 = yearDataBase[currentYear].chemCleaning.AVG_LABOR_PROD * yearDataBase[currentYear].chemCleaning.numJobs;
        int temp3 = yearDataBase[currentYear].bioCleaning.AVG_LABOR_PROD * yearDataBase[currentYear].bioCleaning.numJobs;

        yearDataBase[currentYear].paperfactory.production = yearDataBase[currentYear].paperfactory.AVG_LABOR_PROD * yearDataBase[currentYear].paperfactory.numJobs * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].fish.production = ProdExpCalc(temp1, yearDataBase[currentYear - 1].fishAmount) * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].aquaCulture.production = yearDataBase[currentYear].aquaCulture.AVG_LABOR_PROD * yearDataBase[currentYear].aquaCulture.numJobs * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].agroCulture.production = yearDataBase[currentYear].agroCulture.AVG_LABOR_PROD * yearDataBase[currentYear].agroCulture.numJobs * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].tourism.production = yearDataBase[currentYear].tourism.AVG_LABOR_PROD * yearDataBase[currentYear].tourism.numJobs * yearDataBase[currentYear-1].qualityOfEnv;
        yearDataBase[currentYear].chemCleaning.production = ProdExpCalc(temp2, ChemSens());
        yearDataBase[currentYear].bioCleaning.production =  ProdExpCalc(temp3, BioSens());
    }

    public void FishCalc()
    {
        yearDataBase[currentYear].fishAmount = (yearDataBase[currentYear - 1].fishAmount + yearDataBase[currentYear - 1].fishAmount * yearDataBase[currentYear].FISH_INC / 100 * yearDataBase[currentYear].qualityOfEnv)* (int)(2.600000 * Mathf.Exp(-1 * ((yearDataBase[currentYear-1].fishAmount - 2000) * (yearDataBase[currentYear-1].fishAmount - 2000)) / 180000)) - yearDataBase[currentYear].fish.production;

    }



    //Расчет доходов в этом году

    public void IncomeCalc()
    {
        yearDataBase[currentYear].paperfactory.income = yearDataBase[currentYear].paperfactory.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].paperfactory.production;
        yearDataBase[currentYear].fish.income = yearDataBase[currentYear].fish.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].fish.production;
        yearDataBase[currentYear].aquaCulture.income = yearDataBase[currentYear].aquaCulture.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].aquaCulture.production;
        yearDataBase[currentYear].agroCulture.income = yearDataBase[currentYear].agroCulture.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].agroCulture.production;
        yearDataBase[currentYear].tourism.income = yearDataBase[currentYear].tourism.BASE_COST * yearDataBase[currentYear].BASE_COST_INC / 100 * yearDataBase[currentYear].tourism.production;
    }


    public void ProfitCalc()
    {
        yearDataBase[currentYear].paperfactory.profit = (int)((yearDataBase[currentYear].paperfactory.income - yearDataBase[currentYear].paperfactory.amortization) - (yearDataBase[currentYear].paperfactory.production * yearDataBase[currentYear].paperfactory.VAR_COSTS));
        yearDataBase[currentYear].fish.profit = (int)((yearDataBase[currentYear].fish.income - yearDataBase[currentYear].fish.amortization) - (yearDataBase[currentYear].fish.production * yearDataBase[currentYear].fish.VAR_COSTS));
        yearDataBase[currentYear].aquaCulture.profit = (int)((yearDataBase[currentYear].aquaCulture.income - yearDataBase[currentYear].aquaCulture.amortization) - (yearDataBase[currentYear].aquaCulture.production * yearDataBase[currentYear].aquaCulture.VAR_COSTS));
        yearDataBase[currentYear].agroCulture.profit = (int)((yearDataBase[currentYear].agroCulture.income - yearDataBase[currentYear].agroCulture.amortization) - (yearDataBase[currentYear].agroCulture.production * yearDataBase[currentYear].agroCulture.VAR_COSTS));
        yearDataBase[currentYear].tourism.profit = (int)((yearDataBase[currentYear].tourism.income - yearDataBase[currentYear].tourism.amortization) - (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.VAR_COSTS));
    }


    public void ToBudgCalc()
    {
        yearDataBase[currentYear].paperfactory.toBudget = yearDataBase[currentYear].paperfactory.income > 0 ? yearDataBase[currentYear].paperfactory.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].fish.toBudget = yearDataBase[currentYear].fish.income > 0 ? yearDataBase[currentYear].fish.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].aquaCulture.toBudget = yearDataBase[currentYear].aquaCulture.income > 0 ? yearDataBase[currentYear].aquaCulture.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].agroCulture.toBudget = yearDataBase[currentYear].agroCulture.income > 0 ? yearDataBase[currentYear].agroCulture.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;
        yearDataBase[currentYear].tourism.toBudget = yearDataBase[currentYear].tourism.income > 0 ? yearDataBase[currentYear].tourism.income * yearDataBase[currentYear].PROFIT_TAX / 100 : 0;

    }

    public void HumDevIndCacl()
    {
        float Res =  33 * yearDataBase[currentYear].qualityOfEnv + 33 * (yearDataBase[currentYear].incomeSum / 25) + 33 * (yearDataBase[currentYear].employmentRate / 100);
        yearDataBase[currentYear].humDevInd = (int)(Res) ;
    }

    public void QualEnvCalc() // TODO Rewrite
    {
        float Res = yearDataBase[0].degr / (3.0f * yearDataBase[currentYear].degr);
        Res = Res + (2.0f * yearDataBase[currentYear].fishAmount) / (3.0f * yearDataBase[0].fishAmount);
        yearDataBase[currentYear].qualityOfEnv = (int)Res;
    }

    public void IncomeSumPerHumanCalc()
    {
        yearDataBase[currentYear].incomeSumPerHum = (int)(yearDataBase[currentYear].incomeSum / yearDataBase[currentYear].population * 1000) / 1000;
    }

    //Расчет суммарного дохода все отраслей (без очистных сооружений)
    public void IncomeSumCalc()
    {
        yearDataBase[currentYear].incomeSum =  yearDataBase[currentYear].paperfactory.income +
                                                   yearDataBase[currentYear].fish.income +
                                                   yearDataBase[currentYear].aquaCulture.income +
                                                   yearDataBase[currentYear].agroCulture.income +
                                                   yearDataBase[currentYear].tourism.income;
    }

    public void NewbudgetCalc()
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
    public void MoneyCalc()
    {
        //ADD MoneySpend Calc
        yearDataBase[currentYear].moneySpend = 0;
        // yearDataBase[currentYear].budget = yearDataBase[currentYear-1].budget - yearDataBase[currentYear].moneySpend;
        yearDataBase[currentYear].moneyLeft = yearDataBase[currentYear-1].moneyLeft;

    }

    //Расчет количества трудоспособного населения
    public void AbleToJobPopCalc()
    {

        yearDataBase[currentYear].ablePopSum = (int)((yearDataBase[currentYear].population * yearDataBase[currentYear].ABLE_TO_LABOR)/100);

    }
    //Поправка на чуствительность технологии к переработке (Химическая очистка)
    public int ChemSens()
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
    public int BioSens()
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
    public void EmployRateCalc()
    {
        yearDataBase[currentYear].employmentRate = (int)(yearDataBase[currentYear].jobsAmSum/yearDataBase[currentYear].ablePopSum*100);
    }
     //Расчет уровня безработицы, %
    public void UnEmployRateCalc()
    {
        yearDataBase[currentYear].unemploymentRate = 100 - yearDataBase[currentYear].employmentRate;
    }

    //Расчет выброса загрязнителей
    public void DirtEjectCacl()
    {
        yearDataBase[currentYear].ejectEColi = (yearDataBase[currentYear].fish.production * yearDataBase[currentYear].fish.E_COL_OTH/100) + (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.E_COL_OTH/100);
        yearDataBase[currentYear].ejectOrg = (yearDataBase[currentYear].agroCulture.production * yearDataBase[currentYear].agroCulture.ORG_OTH/100) + (yearDataBase[currentYear].aquaCulture.production * yearDataBase[currentYear].aquaCulture.ORG_OTH/100);
        yearDataBase[currentYear].ejectPhs = (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.PHS_OTH/100);

    }

    public void ResediuEjectCacl()
    {
        yearDataBase[currentYear].residueEColi = yearDataBase[currentYear-1].residueEColi + yearDataBase[currentYear].ejectEColi - yearDataBase[currentYear].bioCleaning.production;
        yearDataBase[currentYear].residueOrg = yearDataBase[currentYear-1].residueOrg + yearDataBase[currentYear].ejectOrg - yearDataBase[currentYear].chemCleaning.production;
        yearDataBase[currentYear].residuePhs = yearDataBase[currentYear-1].residuePhs + yearDataBase[currentYear].ejectPhs;

    }

    public void PopIncCalc()
    {
        yearDataBase[currentYear].POP_INC =  yearDataBase[currentYear-1].POP_INC * yearDataBase[currentYear-1].qualityOfEnv;
    }
    
    public void LifespanCalc()
    {
         yearDataBase[currentYear].lifespan = (int)(75 * yearDataBase[currentYear].qualityOfEnv);
    }

    public void DegrCalc()
    {
        float Res = -0.040000f * (1 - Mathf.Pow(1000f / yearDataBase[currentYear].residueOrg, -0.300000f));
        Res = Res - 0.010000f * (1 - Mathf.Pow(1000f / yearDataBase[currentYear].residueEColi, -0.200000f));
        Res = Res + 0.010000f * (1 - Mathf.Pow(1000f / yearDataBase[currentYear].residuePhs, -0.300000f));
        Res = Res * 2;
        yearDataBase[currentYear].degr = (int)(Res * 1000);
    }

    public void MoveConst()
    {
        yearDataBase[currentYear].FISH_INC = yearDataBase[currentYear-1].FISH_INC;
        yearDataBase[currentYear].POP_INC = yearDataBase[currentYear-1].POP_INC;
        yearDataBase[currentYear].PROFIT_TAX = yearDataBase[currentYear-1].PROFIT_TAX;
        yearDataBase[currentYear].ABLE_TO_LABOR = yearDataBase[currentYear-1].ABLE_TO_LABOR;
        yearDataBase[currentYear].BASE_COST_INC = yearDataBase[currentYear-1].BASE_COST_INC;
        yearDataBase[currentYear].budget = yearDataBase[currentYear-1].budget;


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
        
        
    }


    public void AbsCalc()
    {
        MoveConst();
        
        
        MoneyCalc();
        AmorCacl();
        CapCalc();
        CapSumCalc();
        JobsReqCalc();
        JobsReqSumCalc();
        PopIncCalc();
        PopAmCalc();
        AbleToJobPopCalc();
        JobsAmOrig();
        JobsAmCalc();
        ProdCalc();
        EmployRateCalc();
        UnEmployRateCalc();
        FishCalc();
        DirtEjectCacl();
        ResediuEjectCacl();
        DegrCalc(); // TODO
        IncomeCalc();
        IncomeSumCalc();
        ProfitCalc();
        ToBudgCalc();
        NewbudgetCalc();
        IncomeSumPerHumanCalc();
        HumDevIndCacl();
        QualEnvCalc(); 
        LifespanCalc(); 

        currentYear+=1;      
    }

   /*  public void PreGameCalc()
    {
        Debug.Log("PreCalc START");
        CapSumCalc();
        JobsReqCalc();
        JobsReqSumCalc();
        AbleToJobPopCalc();
        JobsAmOrig();
        //ProdCalc();
        Debug.Log("CHECK"); 
        EmployRateCalc();
        
        FishCalc();
        DirtEjectCacl();
        IncomeCalc();
        IncomeSumCalc();
        ProfitCalc();
        TaxCalc();
        HumDevIndCacl();
        QualEnvCalc();

        currentYear+=1; 
        Debug.Log("PreCalc FIN");
       
    } */
}
