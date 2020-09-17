using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Industry
{
    public float capital;
    public float investments;
    public float production;
    public float amortization;
    public float income;
    public float profit;
    public float toBudget; // deductions  floato the budget
    public float numJobs; // number of jobs at factory
    public float reqJobs; // amount of jobs that industry needed



};

[System.Serializable]
public class PaperFact : Industry
{
    public float CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public float AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public float BASE_COST;

    public float VAR_COSTS; //variable costs
    public float ORG_OTH;

};

[System.Serializable]
public class Fish : Industry
{
    public float CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public float AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public float BASE_COST;

    public float VAR_COSTS; //variable costs

    public float E_COL_OTH; //Процент кишечных палочек от объема продукции во второй отрасли (Ловля рыбы)
    public float ORG_OTH;
};

[System.Serializable]
public class AquaCulture : Industry
{
    public float CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public float AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public float BASE_COST;

    public float VAR_COSTS; //variable costs

    public float ORG_OTH; //Процент органических отходов от объема продукции в третьей отрасли (Аквакультура)
    public float PHS_OTH;

};

[System.Serializable]
public class AgroCulture : Industry
{
    public float CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public float AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public float BASE_COST;

    public float VAR_COSTS; //variable costs

    public float ORG_OTH; //Процент органических отходов от объема продукции в третьей отрасли (Сельское)
    public float PHS_OTH;
    public float E_COL_OTH;

};

[System.Serializable]
public class Tourism : Industry
{
    public float CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public float AVG_LABOR_PROD; //Средняя производительность труда 1 работника
    public float BASE_COST;

    public float VAR_COSTS; //variable costs
    public float E_COL_OTH; //Процент кишечных палочек от объема продукции в пятой отрасли (Туризм)
    public float ORG_OTH; //Процент фосфатных отходов от объема продукции в пятой отрасли (Туризм)

};

[System.Serializable]
public class ChemCleaning : Industry
{
    public float CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public float AVG_LABOR_PROD; //Средняя производительность труда 1 работника

    public float CHEM_CLEAN_FACT; //Чуствительность технологии к переработке (Химическая очистка)

};

[System.Serializable]
public class BioCleaning : Industry
{
    public float CAP_LIFE_TIME;
    public float NUM_JOB_PER_CAP; //Количество рабочих мест, обеспечиваемое единицей капиала в первой отрасли
    public float AVG_LABOR_PROD; //Средняя производительность труда 1 работника

    public float BIO_CLEAN_FACT; //Чуствительность технологии к переработке (Химическая очистка)

};