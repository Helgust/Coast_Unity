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

    public int fishAmount;
    public int ejectEColi; // ejection of E. Coli
    public int ejectOrg; // ejection of Organic matter
    public int ejectPhs; // ejection of Phosphates
    public int residueEColi; // residue of E. Coli
    public int residueOrg; // residue of Organic 
    public int residuePhs; // residue  of Phosphates
    public int degr;
    public int degrLand;
    public int degrSea;
    
    public int budget;
    public int moneySpend;//Распределение суммы денег в периоде 
    public int moneyLeft;//Не распределенный остаток денег в бюджете
    public int incomeSum;//Суммарный доход всех отраслей (без очистных)
    public int capitalSum;//Сумма всех капиталов
    public int incomeSumPerHum;//Суммарный доход всех отраслей (без очистных сооружений) на душу населения
    public int population;//Численность населения 
    public int employmentRate;//Уровень Занятости %
    public int unemploymentRate;//Уровень Безработицы %
    public int jobsAmSum;//Число рабочих мест общее
    public int jobsReqSum;//Суммарное число требуемых рабочих мест
    public int ablePopSum;//Суммарное число трудоспособного населения 

    public int lifespan; //Продолжительность жизни
    public int humDevInd; //Индекс развития общества
    public int qualityOfEnv;//Качество окружающей среды


    // параметры модели
    public int POP_INC; // show how fast population is growing %
    public int ABLE_TO_LABOR; // prosent of population how can work
    public int BASE_COST_INC; //Base cost increase per year, %
    public int PROFIT_TAX; // налог на прибыль %
    public int FISH_INC; //

    public int BANK_PROCENT; 

    public int E_COL_OTH_POP;// остатки кишечной палочки от населения
    public int ORG_OTH_POP; // остатки орагники от населения
};
