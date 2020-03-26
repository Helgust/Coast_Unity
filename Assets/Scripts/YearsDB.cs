using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class YearsDB : MonoBehaviour
{
    public int currentYear =0;
    public List<Year> yearDataBase = new List<Year>();


    public void InitDB( string jsonString )
    {
        Debug.Log("File Exists"+ File.Exists(jsonString));
        string json = File.ReadAllText(jsonString);
        yearDataBase[0] = JsonUtility.FromJson<Year>(json);
    }

    
    public void AmorCacl()
    {
        yearDataBase[currentYear].paperfactory.amortization = yearDataBase[currentYear-1].paperfactory.capital / yearDataBase[currentYear-1].paperfactory.CAP_LIFE_TIME;
        yearDataBase[currentYear].fish.amortization = yearDataBase[currentYear-1].fish.capital / yearDataBase[currentYear-1].fish.CAP_LIFE_TIME;
        yearDataBase[currentYear].aquaCulture.amortization = yearDataBase[currentYear-1].aquaCulture.capital / yearDataBase[currentYear-1].aquaCulture.CAP_LIFE_TIME;
        yearDataBase[currentYear].agroCulture.amortization = yearDataBase[currentYear-1].agroCulture.capital / yearDataBase[currentYear-1].agroCulture.CAP_LIFE_TIME;
        yearDataBase[currentYear].tourism.amortization = yearDataBase[currentYear-1].tourism.capital / yearDataBase[currentYear-1].tourism.CAP_LIFE_TIME;
        yearDataBase[currentYear].chemCleaning.amortization = yearDataBase[currentYear-1].chemCleaning.capital / yearDataBase[currentYear-1].chemCleaning.CAP_LIFE_TIME;
        yearDataBase[currentYear].bioCleaning.amortization = yearDataBase[currentYear-1].bioCleaning.capital / yearDataBase[currentYear-1].bioCleaning.CAP_LIFE_TIME;
    }
    public void CapCalc()
    {
        yearDataBase[currentYear].paperfactory.capital = (yearDataBase[currentYear-1].paperfactory.capital +  yearDataBase[currentYear].paperfactory.investments) - yearDataBase[currentYear].paperfactory.amortization;
        yearDataBase[currentYear].fish.capital = (yearDataBase[currentYear-1].fish.capital +  yearDataBase[currentYear].fish.investments) - yearDataBase[currentYear].fish.amortization;
        yearDataBase[currentYear].aquaCulture.capital = (yearDataBase[currentYear-1].aquaCulture.capital +  yearDataBase[currentYear].aquaCulture.investments) - yearDataBase[currentYear].aquaCulture.amortization;
        yearDataBase[currentYear].agroCulture.capital = (yearDataBase[currentYear-1].agroCulture.capital +  yearDataBase[currentYear].agroCulture.investments) - yearDataBase[currentYear].agroCulture.amortization;
        yearDataBase[currentYear].tourism.capital = (yearDataBase[currentYear-1].tourism.capital +  yearDataBase[currentYear].tourism.investments) - yearDataBase[currentYear].tourism.amortization;
        yearDataBase[currentYear].chemCleaning.capital = (yearDataBase[currentYear-1].chemCleaning.capital +  yearDataBase[currentYear].chemCleaning.investments) - yearDataBase[currentYear].chemCleaning.amortization;
        yearDataBase[currentYear].bioCleaning.capital = (yearDataBase[currentYear-1].bioCleaning.capital +  yearDataBase[currentYear].bioCleaning.investments) - yearDataBase[currentYear].bioCleaning.amortization;
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

    public void  JobsReqSumCalc()
    {
         yearDataBase[currentYear].jobsReqSum = yearDataBase[currentYear].paperfactory.reqJobs + 
                                                   yearDataBase[currentYear].fish.reqJobs +
                                                   yearDataBase[currentYear].aquaCulture.reqJobs +
                                                   yearDataBase[currentYear].agroCulture.reqJobs + 
                                                   yearDataBase[currentYear].tourism.reqJobs +
                                                   yearDataBase[currentYear].chemCleaning.reqJobs +
                                                   yearDataBase[currentYear].bioCleaning.reqJobs;
    }


    public void  PopAmCalc()
    {
	   yearDataBase[currentYear].population = yearDataBase[currentYear-1].population*(1+yearDataBase[currentYear].POP_INC/100);
	}

    public void JobsAmOrig()
    {
        if(yearDataBase[currentYear].jobsReqSum > yearDataBase[currentYear].ablePopSum)
        {
            yearDataBase[currentYear].jobsAmountSum =  yearDataBase[currentYear].ablePopSum;
        }
        else
        {
            yearDataBase[currentYear].jobsAmountSum = yearDataBase[currentYear].jobsReqSum;
        }
	}

//Расчет требуемого количества востребованных рабочих мест на конкретном предприятии
    public void JobsAmCalc()
    {
	    yearDataBase[currentYear].paperfactory.numJobs =  (yearDataBase[currentYear].paperfactory.reqJobs * yearDataBase[currentYear].jobsAmountSum)/yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].fish.numJobs =  (yearDataBase[currentYear].fish.reqJobs *  yearDataBase[currentYear].jobsAmountSum)/yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].aquaCulture.numJobs =  (yearDataBase[currentYear].aquaCulture.reqJobs *  yearDataBase[currentYear].jobsAmountSum)/yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].agroCulture.numJobs =  (yearDataBase[currentYear].agroCulture.reqJobs *  yearDataBase[currentYear].jobsAmountSum)/yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].tourism.numJobs = (yearDataBase[currentYear].tourism.reqJobs * yearDataBase[currentYear].jobsAmountSum)/yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].chemCleaning.numJobs = (yearDataBase[currentYear].chemCleaning.reqJobs *  yearDataBase[currentYear].jobsAmountSum)/yearDataBase[currentYear].jobsReqSum;
        yearDataBase[currentYear].bioCleaning.numJobs = (yearDataBase[currentYear].bioCleaning.reqJobs * yearDataBase[currentYear].jobsAmountSum)/yearDataBase[currentYear].jobsReqSum;

	}

    public int ProdExpCalc(int ProdRez, int VolRes)
    
    {
        int Res;
    //ProdRez - Производственный резерв
    //VolRes - Объем сырья
        if(ProdRez>VolRes)
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
    public void  ProdCalc()
    {
        int temp = yearDataBase[currentYear].fish.AVG_LABOR_PROD * yearDataBase[currentYear].fish.numJobs;

        yearDataBase[currentYear].paperfactory.production =  yearDataBase[currentYear].paperfactory.AVG_LABOR_PROD * yearDataBase[currentYear].paperfactory.numJobs;
        yearDataBase[currentYear].fish.production = ProdExpCalc(temp,yearDataBase[currentYear-1].fishAmount);
        yearDataBase[currentYear].aquaCulture.production = yearDataBase[currentYear].aquaCulture.AVG_LABOR_PROD *  yearDataBase[currentYear].aquaCulture.numJobs;
        yearDataBase[currentYear].agroCulture.production = yearDataBase[currentYear].agroCulture.AVG_LABOR_PROD * yearDataBase[currentYear].agroCulture.numJobs;
        yearDataBase[currentYear].tourism.production =  yearDataBase[currentYear].tourism.AVG_LABOR_PROD * yearDataBase[currentYear].tourism.numJobs ;
    }

    public void FishCalc()
    {
        yearDataBase[currentYear].fishAmount = (yearDataBase[currentYear-1].fishAmount + yearDataBase[currentYear-1].fishAmount * yearDataBase[currentYear].FISH_INC/100) - yearDataBase[currentYear].fish.production ;

    }

    public int SwampDifCalc()
    {
        float res;
        float par1 = 1000/yearDataBase[currentYear].residueOrg;
        res= -0.04f*(1.0f-Mathf.Pow(par1, -0.3f));
        return (int)res;
    }
    public void  SwampCalc()
    {
        yearDataBase[currentYear].swampArea = yearDataBase[currentYear-1].swampArea + SwampDifCalc();

    }

    //Расчет доходов

    public void IncomeCalc()
    {
        yearDataBase[currentYear].paperfactory.income =  yearDataBase[currentYear].paperfactory.BASE_COST *yearDataBase[currentYear].BASE_COST_INC/100 * yearDataBase[currentYear].paperfactory.production;
        yearDataBase[currentYear].fish.income = yearDataBase[currentYear].fish.BASE_COST *yearDataBase[currentYear].BASE_COST_INC/100 * yearDataBase[currentYear].fish.production;
        yearDataBase[currentYear].aquaCulture.income = yearDataBase[currentYear].aquaCulture.BASE_COST *yearDataBase[currentYear].BASE_COST_INC/100 * yearDataBase[currentYear].aquaCulture.production;
        yearDataBase[currentYear].agroCulture.income = yearDataBase[currentYear].agroCulture.BASE_COST *yearDataBase[currentYear].BASE_COST_INC/100 * yearDataBase[currentYear].agroCulture.production;
        yearDataBase[currentYear].tourism.income =  yearDataBase[currentYear].tourism.BASE_COST *yearDataBase[currentYear].BASE_COST_INC/100 * yearDataBase[currentYear].tourism.production;
    }


    public void ProfitCalc()
    {
        yearDataBase[currentYear].paperfactory.profit =  (int)((yearDataBase[currentYear].paperfactory.income -  yearDataBase[currentYear].paperfactory.amortization) - (yearDataBase[currentYear].paperfactory.production * yearDataBase[currentYear].paperfactory.VAR_COSTS));
        yearDataBase[currentYear].fish.profit = (int)((yearDataBase[currentYear].fish.income -  yearDataBase[currentYear].fish.amortization) - (yearDataBase[currentYear].fish.production * yearDataBase[currentYear].fish.VAR_COSTS));
        yearDataBase[currentYear].aquaCulture.profit = (int)((yearDataBase[currentYear].aquaCulture.income -  yearDataBase[currentYear].aquaCulture.amortization) - (yearDataBase[currentYear].aquaCulture.production * yearDataBase[currentYear].aquaCulture.VAR_COSTS));
        yearDataBase[currentYear].agroCulture.profit = (int)((yearDataBase[currentYear].agroCulture.income -  yearDataBase[currentYear].agroCulture.amortization) - (yearDataBase[currentYear].agroCulture.production * yearDataBase[currentYear].agroCulture.VAR_COSTS));
        yearDataBase[currentYear].tourism.profit =  (int)((yearDataBase[currentYear].tourism.income -  yearDataBase[currentYear].tourism.amortization) - (yearDataBase[currentYear].tourism.production * yearDataBase[currentYear].tourism.VAR_COSTS));
    }
    

    public void TaxCalc()
    {
        yearDataBase[currentYear].paperfactory.deductions = yearDataBase[currentYear].paperfactory.income > 0 ? yearDataBase[currentYear].paperfactory.income* yearDataBase[currentYear].PROFIT_TAX/100 : 0; 
        yearDataBase[currentYear].fish.deductions = yearDataBase[currentYear].fish.income > 0 ? yearDataBase[currentYear].fish.income* yearDataBase[currentYear].PROFIT_TAX/100 : 0;
        yearDataBase[currentYear].aquaCulture.deductions =  yearDataBase[currentYear].aquaCulture.income > 0 ? yearDataBase[currentYear].aquaCulture.income* yearDataBase[currentYear].PROFIT_TAX/100 : 0;
        yearDataBase[currentYear].agroCulture.deductions =  yearDataBase[currentYear].agroCulture.income > 0 ? yearDataBase[currentYear].agroCulture.income* yearDataBase[currentYear].PROFIT_TAX/100 : 0;
        yearDataBase[currentYear].tourism.deductions = yearDataBase[currentYear].tourism.income > 0 ? yearDataBase[currentYear].tourism.income* yearDataBase[currentYear].PROFIT_TAX/100 : 0;
         
    }

    public void HumDevIndCacl()
    {
        float  MinFin = 300.0f;
        float MaxFin = 2000.0f;
        float tER = yearDataBase[currentYear].jobsReqSum/(yearDataBase[currentYear].population*yearDataBase[currentYear].ABLE_TO_LABOR/100); //занятость с учетом других отраслей
        float NumRM = yearDataBase[currentYear].jobsAmountSum - yearDataBase[currentYear].paperfactory.numJobs - yearDataBase[currentYear].fish.numJobs;
        float Res = 0.3f*(0.3f*(tER)+0.7f*(NumRM)*0.3f/yearDataBase[currentYear].jobsAmountSum);
        Res = Res + 0.3f*(1.0f-((1.0f-tER/100.0f)*50f));
        Res = Res + 0.4f*((yearDataBase[currentYear].incomeSum-MinFin)/(MaxFin-MinFin));
        yearDataBase[currentYear].humDevInd = (int)(Res*100)/100;;
    }

    public void QualEnvCalc()
    {
      float Res = yearDataBase[0].swampArea/(3.0f*yearDataBase[currentYear].swampArea);
	        Res = Res + (2.0f*yearDataBase[currentYear].fishAmount)/(3.0f*yearDataBase[0].fishAmount);
        yearDataBase[currentYear].qualityOfEnv = (int)Res;
    }

    public void IncomSumPerHumanCalc()
    {
        yearDataBase[currentYear].incomeSumPerHum = (int)(yearDataBase[currentYear].incomeSum/yearDataBase[currentYear].population*1000)/1000;
    }

    public void IncomSumCalc()
    {
        yearDataBase[currentYear].incomeSum = yearDataBase[currentYear].jobsReqSum = yearDataBase[currentYear].paperfactory.income + 
                                                   yearDataBase[currentYear].fish.income +
                                                   yearDataBase[currentYear].aquaCulture.income +
                                                   yearDataBase[currentYear].agroCulture.income + 
                                                   yearDataBase[currentYear].tourism.income;
    }

    public void NewBudgetCalc()
    {
        yearDataBase[currentYear].BUDGET = yearDataBase[currentYear].moneyLeft + 
                                           yearDataBase[currentYear].paperfactory.deductions +
                                           yearDataBase[currentYear].fish.deductions  +
                                           yearDataBase[currentYear].aquaCulture.deductions +
                                           yearDataBase[currentYear].agroCulture.deductions +
                                           yearDataBase[currentYear].tourism.deductions; 
    }
}
