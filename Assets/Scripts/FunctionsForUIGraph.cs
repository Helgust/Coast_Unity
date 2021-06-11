using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionsForUIGraph : MonoBehaviour
{
    private string stat_parametr = "f_";
    private Color _dropdownColorAdjustmnet = new Color(1, 1, 1, 1);
    private string dropdown_param = "toBudget";

    [SerializeField] private Dropdown dropdownmenu;
    [SerializeField] private Toggle RESFishRes;
    [SerializeField] private Toggle RESPopRes;
    [SerializeField] private Toggle RESAllocateBudgetRes;
    [SerializeField] private Toggle RESRestBudgetRes;
    [SerializeField] private Toggle RESBudgetRes;
    [SerializeField] private Toggle RESIncPerCapitaRes;
    [SerializeField] private Toggle RESQualityOfEnvRes;
    [SerializeField] private Toggle RESHumDevIndRes;
    [SerializeField] private Toggle SOCPop;
    [SerializeField] private Toggle SOCPopGrowRate;
    [SerializeField] private Toggle SOCPopLifeSpan;
    [SerializeField] private Toggle SOCAblePop;
    [SerializeField] private Toggle SOCTotalNumJobs;
    [SerializeField] private Toggle SOCEmplTotal;
    [SerializeField] private Toggle SOCEmplPaper;
    [SerializeField] private Toggle SOCEmplFish;
    [SerializeField] private Toggle SOCEmplAqua;
    [SerializeField] private Toggle SOCEmplAgri;
    [SerializeField] private Toggle SOCEmplTour;
    [SerializeField] private Toggle SOCEmplBio;
    [SerializeField] private Toggle SOCEmplChem;
    [SerializeField] private Toggle SOCHumDevInd;
    [SerializeField] private Toggle ECOLFishNum;
    [SerializeField] private Toggle ECOLFishCath;
    [SerializeField] private Toggle ECOLEcolWaste;
    [SerializeField] private Toggle ECOLPhoWaste;
    [SerializeField] private Toggle ECOLOtherWaste;
    [SerializeField] private Toggle ECOLEcolRemain;
    [SerializeField] private Toggle ECOLPhoRemain;
    [SerializeField] private Toggle ECOLOtherRemain;
    [SerializeField] private Toggle ECOLDegrLand;
    [SerializeField] private Toggle ECOLDegrSea;
    [SerializeField] private Toggle ECOLVolBio;
    [SerializeField] private Toggle ECOLVolChem;
    [SerializeField] private Toggle ECOLQualityOfEnv;
    [SerializeField] private Toggle FINpaperFact;
    [SerializeField] private Toggle FINFish;
    [SerializeField] private Toggle FINAqua;
    [SerializeField] private Toggle FINAgri;
    [SerializeField] private Toggle FINTour;
    [SerializeField] private Toggle FINChem;
    [SerializeField] private Toggle FINBio;


    public void ClearAllToggles()
    {
        RESFishRes.SetIsOnWithoutNotify(false);
        RESPopRes.SetIsOnWithoutNotify(false);
        RESAllocateBudgetRes.SetIsOnWithoutNotify(false);
        RESRestBudgetRes.SetIsOnWithoutNotify(false);
        RESBudgetRes.SetIsOnWithoutNotify(false);
        RESIncPerCapitaRes.SetIsOnWithoutNotify(false);
        RESQualityOfEnvRes.SetIsOnWithoutNotify(false);
        RESHumDevIndRes.SetIsOnWithoutNotify(false);
        SOCPop.SetIsOnWithoutNotify(false);
        SOCPopGrowRate.SetIsOnWithoutNotify(false);
        SOCPopLifeSpan.SetIsOnWithoutNotify(false);
        SOCAblePop.SetIsOnWithoutNotify(false);
        SOCTotalNumJobs.SetIsOnWithoutNotify(false);
        SOCEmplTotal.SetIsOnWithoutNotify(false);
        SOCEmplPaper.SetIsOnWithoutNotify(false);
        SOCEmplFish.SetIsOnWithoutNotify(false);
        SOCEmplAqua.SetIsOnWithoutNotify(false);
        SOCEmplAgri.SetIsOnWithoutNotify(false);
        SOCEmplTour.SetIsOnWithoutNotify(false);
        SOCEmplBio.SetIsOnWithoutNotify(false);
        SOCEmplChem.SetIsOnWithoutNotify(false);
        SOCHumDevInd.SetIsOnWithoutNotify(false);
        ECOLFishNum.SetIsOnWithoutNotify(false);
        ECOLFishCath.SetIsOnWithoutNotify(false);
        ECOLEcolWaste.SetIsOnWithoutNotify(false);
        ECOLPhoWaste.SetIsOnWithoutNotify(false);
        ECOLOtherWaste.SetIsOnWithoutNotify(false);
        ECOLEcolRemain.SetIsOnWithoutNotify(false);
        ECOLPhoRemain.SetIsOnWithoutNotify(false);
        ECOLOtherRemain.SetIsOnWithoutNotify(false);
        ECOLDegrLand.SetIsOnWithoutNotify(false);
        ECOLDegrSea.SetIsOnWithoutNotify(false);
        ECOLVolBio.SetIsOnWithoutNotify(false);
        ECOLVolChem.SetIsOnWithoutNotify(false);
        ECOLQualityOfEnv.SetIsOnWithoutNotify(false);
        FINpaperFact.SetIsOnWithoutNotify(false);
        FINFish.SetIsOnWithoutNotify(false);
        FINAqua.SetIsOnWithoutNotify(false);
        FINAgri.SetIsOnWithoutNotify(false);
        FINTour.SetIsOnWithoutNotify(false);
        FINChem.SetIsOnWithoutNotify(false);
        FINBio.SetIsOnWithoutNotify(false);
        GameUIManager.instance.finDict.Clear();
        GameUIManager.instance.FillFinDict();
        GameUIManager.instance.paramDict.Clear();
        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    //Resourses Group 
    public void RESFishResFUNC()
    {
        stat_parametr = "fishAmount";
        if (RESFishRes.isOn || ECOLFishNum.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                RESFishRes.SetIsOnWithoutNotify(false);
                ECOLFishNum.SetIsOnWithoutNotify(false);
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                RESFishRes.SetIsOnWithoutNotify(true);
                ECOLFishNum.SetIsOnWithoutNotify(true);
                GameUIManager.instance.paramDict.Add(stat_parametr, Color.green);
            }
        }
        else
        {
            RESFishRes.SetIsOnWithoutNotify(false);
            ECOLFishNum.SetIsOnWithoutNotify(false);
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void RESPopResFUNC()
    {
        stat_parametr = "population";
        if (RESPopRes.isOn || SOCPop.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                RESPopRes.SetIsOnWithoutNotify(false);
                SOCPop.SetIsOnWithoutNotify(false);
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                RESPopRes.SetIsOnWithoutNotify(true);
                SOCPop.SetIsOnWithoutNotify(true);
                GameUIManager.instance.paramDict.Add(stat_parametr, Color.blue);
            }
        }
        else
        {
            SOCPop.SetIsOnWithoutNotify(false);
            RESPopRes.SetIsOnWithoutNotify(false);
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void RESAllocateBudgetResFUNC()
    {
        stat_parametr = "moneySpend";
        if (RESAllocateBudgetRes.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, Color.red);
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void RESRestBudgetResFUNC()
    {
        stat_parametr = "moneyLeft";
        if (RESRestBudgetRes.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, Color.yellow);
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void RESBudgetResFUNC()
    {
        stat_parametr = "budget";
        if (RESBudgetRes.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, Color.cyan);
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void RESIncPerCapitaResFUNC()
    {
        stat_parametr = "incomeSumPerHum";
        if (RESIncPerCapitaRes.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(16, 180, 50, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void RESQualityOfEnvResFUNC()
    {
        stat_parametr = "qualityOfEnv";
        if (RESQualityOfEnvRes.isOn || ECOLQualityOfEnv.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                RESQualityOfEnvRes.SetIsOnWithoutNotify(false);
                ECOLQualityOfEnv.SetIsOnWithoutNotify(false);
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                RESQualityOfEnvRes.SetIsOnWithoutNotify(true);
                ECOLQualityOfEnv.SetIsOnWithoutNotify(true);
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(255, 224, 130, 255));
            }
        }
        else
        {
            RESQualityOfEnvRes.SetIsOnWithoutNotify(false);
            ECOLQualityOfEnv.SetIsOnWithoutNotify(false);
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void RESHumDevIndResFUNC()
    {
        stat_parametr = "humDevInd";
        if (RESHumDevIndRes.isOn || SOCHumDevInd.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                SOCHumDevInd.SetIsOnWithoutNotify(false);
                RESHumDevIndRes.SetIsOnWithoutNotify(false);
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                SOCHumDevInd.SetIsOnWithoutNotify(true);
                RESHumDevIndRes.SetIsOnWithoutNotify(true);
                GameUIManager.instance.paramDict.Add(stat_parametr, Color.magenta);
            }
        }
        else
        {
            SOCHumDevInd.SetIsOnWithoutNotify(false);
            RESHumDevIndRes.SetIsOnWithoutNotify(false);
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }
    //SocParams Group

    public void SOCPopGrowRateFUNC()
    {
        stat_parametr = "pop_inc";
        if (SOCPopGrowRate.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(38, 166, 154, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCPopLifeSpanFUNC()
    {
        stat_parametr = "lifespan";
        if (SOCPopLifeSpan.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(255, 167, 38, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCAblePopFUNC()
    {
        stat_parametr = "ablePopSum";

        if (SOCAblePop.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(156, 39, 176, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCTotalNumJobsFUNC()
    {
        stat_parametr = "jobsReqSum"; //FIX
        if (SOCTotalNumJobs.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(255, 23, 68, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCEmplTotalFUNC()
    {
        stat_parametr = "jobsAmSum"; //FIX
        if (SOCEmplTotal.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(179, 229, 252, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCEmplPaperFUNC()
    {
        stat_parametr = "pf_numJobs";
        if (SOCEmplPaper.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(56, 142, 60, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCEmplFishFUNC()
    {
        stat_parametr = "f_numJobs";
        if (SOCEmplFish.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(255, 235, 59, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCEmplAquaFUNC()
    {
        stat_parametr = "aq_numJobs";
        if (SOCEmplAqua.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(244, 81, 30, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCEmplAgriFUNC()
    {
        stat_parametr = "ag_numJobs";
        if (SOCEmplAgri.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(144, 164, 174, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCEmplTourFUNC()
    {
        stat_parametr = "t_numJobs";
        if (SOCEmplTour.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(240, 98, 146, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCEmplBioFUNC()
    {
        stat_parametr = "bio_numJobs";
        if (SOCEmplBio.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(63, 81, 181, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void SOCEmplChemFUNC()
    {
        stat_parametr = "chem_numJobs";
        if (SOCEmplChem.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(77, 208, 225, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    //ECOL params
    public void ECOLFishCathFUNC()
    {
        stat_parametr = "f_production";
        if (ECOLFishCath.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(3, 169, 244, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLEcolWasteFUNC()
    {
        stat_parametr = "ejectEColi";
        if (ECOLEcolWaste.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(139, 195, 74, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLPhoWasteFUNC()
    {
        stat_parametr = "ejectPhs";
        if (ECOLPhoWaste.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(255, 202, 40, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLOtherWasteFUNC()
    {
        stat_parametr = "ejectOrg";
        if (ECOLOtherWaste.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(161, 136, 127, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLEcolRemainFUNC()
    {
        stat_parametr = "residueEColi";
        if (ECOLEcolRemain.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(74, 20, 140, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLPhoRemainFUNC()
    {
        stat_parametr = "residuePhs";
        if (ECOLPhoRemain.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(13, 71, 161, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLOtherRemainFUNC()
    {
        stat_parametr = "residueOrg";
        if (ECOLOtherRemain.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(245, 0, 87, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLDegrLandFUNC()
    {
        stat_parametr = "degrLand";
        if (ECOLDegrLand.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(158, 157, 36, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLDegrSeaFUNC()
    {
        stat_parametr = "degrSea";
        if (ECOLDegrSea.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(230, 81, 0, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLVolBioFUNC()
    {
        stat_parametr = "bio_production";
        if (ECOLVolBio.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(158, 158, 158, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void ECOLVolChemFUNC()
    {
        stat_parametr = "chem_production";
        if (ECOLVolChem.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.paramDict.Remove(stat_parametr);
            }
            else
            {
                GameUIManager.instance.paramDict.Add(stat_parametr, new Color32(244, 67, 54, 255));
            }
        }
        else
        {
            GameUIManager.instance.paramDict.Remove(stat_parametr);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void FINpaperFactFUNC()
    {
        stat_parametr = "pf_";
        if (FINpaperFact.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.finDict[dropdown_param][0] = false;
                GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
            }
            else
            {
                GameUIManager.instance.finDict[dropdown_param][0] = true;
                Color temp = new Color32(244, 67, 54, 255);
                //Color32 res = temp - _dropdownColorAdjustmnet;
                GameUIManager.instance.paramDict.Add(stat_parametr + dropdown_param, temp);
            }
        }
        else
        {
            GameUIManager.instance.finDict[dropdown_param][0] = false;
            GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
        }

        Debug.Log("FIN_PF" + stat_parametr + dropdown_param);
        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void FINFishFUNC()
    {
        stat_parametr = "f_";
        if (FINFish.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.finDict[dropdown_param][1] = false;
                GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
            }
            else
            {
                GameUIManager.instance.finDict[dropdown_param][1] = true;
                Color temp = new Color32(110, 80, 200, 255);
                //Color32 res = temp - _dropdownColorAdjustmnet;
                GameUIManager.instance.paramDict.Add(stat_parametr + dropdown_param, temp);
            }
        }
        else
        {
            GameUIManager.instance.finDict[dropdown_param][1] = false;
            GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void FINAquaFUNC()
    {
        stat_parametr = "aq_";
        if (FINAqua.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.finDict[dropdown_param][2] = false;
                GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
            }
            else
            {
                GameUIManager.instance.finDict[dropdown_param][2] = true;
                Color temp = new Color32(180, 67, 250, 255);
                //Color32 res = temp - _dropdownColorAdjustmnet;
                GameUIManager.instance.paramDict.Add(stat_parametr + dropdown_param, temp);
            }
        }
        else
        {
            GameUIManager.instance.finDict[dropdown_param][2] = false;
            GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void FINAgriFUNC()
    {
        stat_parametr = "ag_";
        if (FINAgri.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.finDict[dropdown_param][3] = false;
                GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
            }
            else
            {
                GameUIManager.instance.finDict[dropdown_param][3] = true;
                Color temp = new Color32(100, 200, 54, 255);
                //Color32 res = temp - _dropdownColorAdjustmnet;
                GameUIManager.instance.paramDict.Add(stat_parametr + dropdown_param, temp);
            }
        }
        else
        {
            GameUIManager.instance.finDict[dropdown_param][3] = false;
            GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void FINTourFUNC()
    {
        stat_parametr = "t_";
        if (FINTour.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.finDict[dropdown_param][4] = false;
                GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
            }
            else
            {
                GameUIManager.instance.finDict[dropdown_param][4] = true;
                Color temp = new Color32(244, 67, 240, 255);
                //Color32 res = temp - _dropdownColorAdjustmnet;
                GameUIManager.instance.paramDict.Add(stat_parametr + dropdown_param, temp);
            }
        }
        else
        {
            GameUIManager.instance.finDict[dropdown_param][4] = false;
            GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void FINChemFUNC()
    {
        stat_parametr = "chem_";
        if (FINChem.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.finDict[dropdown_param][5] = false;
                GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
            }
            else
            {
                GameUIManager.instance.finDict[dropdown_param][5] = true;
                Color temp = new Color32(200, 100, 54, 255);
                //Color32 res = temp - _dropdownColorAdjustmnet;
                GameUIManager.instance.paramDict.Add(stat_parametr + dropdown_param, temp);
            }
        }
        else
        {
            GameUIManager.instance.finDict[dropdown_param][5] = false;
            GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void FINBioFUNC()
    {
        stat_parametr = "bio_";
        if (FINBio.isOn)
        {
            if (GameUIManager.instance.paramDict.ContainsKey(stat_parametr))
            {
                GameUIManager.instance.finDict[dropdown_param][6] = false;
                GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
            }
            else
            {
                GameUIManager.instance.finDict[dropdown_param][6] = true;
                Color temp = new Color32(80, 90, 255, 255);
                //Color32 res = temp - _dropdownColorAdjustmnet;
                GameUIManager.instance.paramDict.Add(stat_parametr + dropdown_param, temp);
            }
        }
        else
        {
            GameUIManager.instance.finDict[dropdown_param][6] = false;
            GameUIManager.instance.paramDict.Remove(stat_parametr + dropdown_param);
        }

        GameUIManager.instance.ShowGraph(GameUIManager.instance.paramDict);
    }

    public void FINDropDownhandlerFUNC()
    {
        Debug.Log("Drophandl" + dropdownmenu.value);
        switch (dropdownmenu.value)
        {
            case 0:
                dropdown_param = "toBudget";
                _dropdownColorAdjustmnet = new Color32(255, 0, 0, 0);
                break;
            case 1:
                dropdown_param = "numJobs";
                _dropdownColorAdjustmnet = new Color32(25, 118, 210, 0);
                break;
            case 2:
                dropdown_param = "income";
                _dropdownColorAdjustmnet = new Color32(0, 77, 64, 0);
                break;
            case 3:
                dropdown_param = "profit";
                _dropdownColorAdjustmnet = new Color32(238, 255, 65, 0);
                break;
            case 4:
                dropdown_param = "production";
                _dropdownColorAdjustmnet = new Color32(40, 53, 200, 0);
                break;
            case 5:
                dropdown_param = "amortization";
                _dropdownColorAdjustmnet = new Color32(84, 110, 122, 0);
                break;
            case 6:
                dropdown_param = "invest";
                _dropdownColorAdjustmnet = new Color32(198, 40, 40, 0);
                break;
            case 7:
                dropdown_param = "capital";
                _dropdownColorAdjustmnet = new Color32(102, 187, 106, 0);
                break;
            default:
                dropdown_param = "toBudget";
                _dropdownColorAdjustmnet = new Color32(251, 192, 45, 0);
                break;
        }

        SetCorrectToggle(dropdown_param);
    }

    private void SetCorrectToggle(string param)
    {
        FINpaperFact.SetIsOnWithoutNotify(GameUIManager.instance.finDict[param][0]);
        FINFish.SetIsOnWithoutNotify(GameUIManager.instance.finDict[param][1]);
        FINAqua.SetIsOnWithoutNotify(GameUIManager.instance.finDict[param][2]);
        FINAgri.SetIsOnWithoutNotify(GameUIManager.instance.finDict[param][3]);
        FINTour.SetIsOnWithoutNotify(GameUIManager.instance.finDict[param][4]);
        FINChem.SetIsOnWithoutNotify(GameUIManager.instance.finDict[param][5]);
        FINBio.SetIsOnWithoutNotify(GameUIManager.instance.finDict[param][6]);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}