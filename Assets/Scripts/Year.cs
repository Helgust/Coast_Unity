using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Year
{
    public PaperFact paperfactory;
    public Fish fish;
    public AquaCulture aquaCulture;
    public AgroCulture agroCulture;
    public Tourism tourism;
    public ChemCleaning chemCleaning;
    public BioCleaning bioCleaning;

    public float fishAmount;
    public float ejectEColi; // ejection of E. Coli
    public float ejectOrg; // ejection of Organic matter
    public float ejectPhs; // ejection of Phosphates
    public float residueEColi; // residue of E. Coli
    public float residueOrg; // residue of Organic 
    public float residuePhs; // residue  of Phosphates
    public float degr;
    public float degrLand;
    public float degrSea;
    public float budget;
    public float moneySpend;//Распределение суммы денег в периоде 
    public float moneyLeft;//Не распределенный остаток денег в бюджете
    public float incomeSum;//Суммарный доход всех отраслей (без очистных)
    public float capitalSum;//Сумма всех капиталов
    public float incomeSumPerHum;//Суммарный доход всех отраслей (без очистных сооружений) на душу населения
    public float population;//Численность населения 
    public float employmentRate;//Уровень Занятости %
    public float unemploymentRate;//Уровень Безработицы %
    public float jobsAmSum;//Число рабочих мест общее
    public float jobsReqSum;//Суммарное число требуемых рабочих мест
    public float ablePopSum;//Суммарное число трудоспособного населения 
    public float lifespan; //Продолжительность жизни
    public float humDevInd; //Индекс развития общества
    public float qualityOfEnv;//Качество окружающей среды
    public float pop_incM; // реальный прирост
    // параметры модели
    public float POP_INC; // show how fast population is growing %
    public float ABLE_TO_LABOR; // prosent of population how can work
    public float BASE_COST_INC; //Base cost increase per year, %
    public float PROFIT_TAX; // налог на прибыль %
    public float FISH_INC; //
    public float BANK_PROCENT;
    public float E_COL_OTH_POP;// остатки кишечной палочки от населения
    public float ORG_OTH_POP; // остатки орагники от населения
    public float shipUCap;
    public float agroUCap;
    public float turUCap;


};


