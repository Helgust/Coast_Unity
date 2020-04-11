using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Industry
{
    public int capital;
    public int investments;
    public int production;
    public int amortization;
    public int income;
    public int profit;
    public int toBudget; // deductions  into the budget
    public int numJobs; // number of jobs at factory
    public int reqJobs; // amount of jobs that industry needed
    
    
    
};

[System.Serializable]
public class PaperFact : Industry
{
    public int CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public int AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public int BASE_COST;
    
    public float VAR_COSTS; //variable costs

};

[System.Serializable]
public class Fish : Industry
{
     public int CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public int AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public int BASE_COST;
    
    public float VAR_COSTS; //variable costs

    public int E_COL_OTH; //Процент кишечных палочек от объема продукции во второй отрасли (Ловля рыбы)


};

[System.Serializable]
public class AquaCulture : Industry
{
    public int CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public int AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public int BASE_COST;
    
    public float VAR_COSTS; //variable costs

    public int ORG_OTH; //Процент органических отходов от объема продукции в третьей отрасли (Аквакультура)

};

[System.Serializable]
public class AgroCulture : Industry
{
     public int CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public int AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public int BASE_COST;
    
    public float VAR_COSTS; //variable costs

    public int ORG_OTH; //Процент органических отходов от объема продукции в третьей отрасли (Сельское)

};

[System.Serializable]
public class Tourism : Industry
{
     public int CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public int AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public int BASE_COST;
    
    public float VAR_COSTS; //variable costs
    public int E_COL_OTH; //Процент кишечных палочек от объема продукции в пятой отрасли (Туризм)
    public int PHS_OTH; //Процент фосфатных отходов от объема продукции в пятой отрасли (Туризм)

};

[System.Serializable]
public class ChemCleaning : Industry
{
    public int CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public int AVG_LABOR_PROD; //Средняя производительность труда 1 работника
   
    public int CHEM_CLEAN_FACT; //Чуствительность технологии к переработке (Химическая очистка)

};

[System.Serializable]
public class BioCleaning : Industry
{
     public int CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public int AVG_LABOR_PROD; //Средняя производительность труда 1 работника
   
    public int BIO_CLEAN_FACT; //Чуствительность технологии к переработке (Химическая очистка)

};