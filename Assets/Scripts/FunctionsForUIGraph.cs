using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionsForUIGraph : MonoBehaviour
{
    private string stat_parametr = "f_";
    private string dropdown_param = "toBudget";
    public Dropdown dropdownmenu;
    
   //Resourses Group 
    public void RESFishRes()
    {
       
        stat_parametr = "fishAmount";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void RESPopRes()
    {
        stat_parametr = "population";
        UIManager.instance.ShowGraph(stat_parametr);
        
    }
    
    public void RESAllocateBudgetRes()
    {

        stat_parametr = "moneySpend";
        UIManager.instance.ShowGraph(stat_parametr);
        
    }
    public void RESRestBudgetRes()
    {

        stat_parametr = "moneyLeft";
        UIManager.instance.ShowGraph(stat_parametr);
        
    }
    public void RESBudgetRes()
    {

        stat_parametr = "budget";
        UIManager.instance.ShowGraph(stat_parametr);
        
    }
    public void RESIncPerCapitaRes()
    {

        stat_parametr = "incomeSumPerHum";
        UIManager.instance.ShowGraph(stat_parametr);
        
    }
    public void RESQualityOfEnvRes()
    {

        stat_parametr = "qualityOfEnv";
        UIManager.instance.ShowGraph(stat_parametr);
        
    }
    public void RESHumDevIndRes()
    {

        stat_parametr = "humDevInd";
        UIManager.instance.ShowGraph(stat_parametr);
        
    }
    //SocParams Group
    
    public void SOCPopGrowRate()
    {
        stat_parametr = "pop_inc";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCPopLifeSpan()
    {
        stat_parametr = "lifespan";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCAblePop()
    {
        stat_parametr = "ablePopSum";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCTotalNumJobs()
    {
        stat_parametr = "jobsReqSum";//FIX
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCEmplTotal()
    {
        stat_parametr = "jobsAmSum";//FIX
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCEmplPaper()
    {
        stat_parametr = "pf_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCEmplFish()
    {
        stat_parametr = "f_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCEmplAqua()
    {
        stat_parametr = "aq_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCEmplAgri()
    {
        stat_parametr = "ag_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCEmplTour()
    {
        stat_parametr = "t_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCEmplBio()
    {
        stat_parametr = "bio_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void SOCEmplChem()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    //ECOL params
    public void ECOLFishCath()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLEcolWaste()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLPhoWaste()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLOtherWaste()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLEcolRemain()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLPhoRemain()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLOtherRemain()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLDegrLand()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLDegrSea()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLVolBio()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    public void ECOLVolChem()
    {
        stat_parametr = "chem_numJobs";
        UIManager.instance.ShowGraph(stat_parametr);
    }
    
    public void FINpaperFact()
    {
        stat_parametr = "pf_";
        Debug.Log("FIN_PF"+stat_parametr+dropdown_param);
        UIManager.instance.ShowGraph(stat_parametr+dropdown_param);
    }
    public void FINFish()
    {
        stat_parametr = "f_";
        UIManager.instance.ShowGraph(stat_parametr+dropdown_param);
    }
    public void FINAqua()
    {
        stat_parametr = "aq_";
        UIManager.instance.ShowGraph(stat_parametr+dropdown_param);
    }
    public void FINAgri()
    {
        stat_parametr = "ag_";
        UIManager.instance.ShowGraph(stat_parametr+dropdown_param);
    }
    public void FINTour()
    {
        stat_parametr = "t_";
        UIManager.instance.ShowGraph(stat_parametr+dropdown_param);
    }
    public void FINChem()
    {
        stat_parametr = "chem_";
        UIManager.instance.ShowGraph(stat_parametr+dropdown_param);
    }
    public void FINBio()
    {
        stat_parametr = "bio_";
        UIManager.instance.ShowGraph(stat_parametr+dropdown_param);
    }

    public void FINDropDownhandler()
    {
        Debug.Log("Drophandl"+dropdownmenu.value);
        switch (dropdownmenu.value)
        {
            case 0:
                dropdown_param = "toBudget";
                break;
            case 1:
                dropdown_param = "numJobs";
                break;
            case 2:
                dropdown_param = "income";
                break;
            case 3:
                dropdown_param = "profit";
                break;
            case 4:
                dropdown_param = "production";
                break;
            case 5:
                dropdown_param = "amortization";
                break;
            case 6:
                dropdown_param = "invest";
                break;
            case 7:
                dropdown_param = "capital";
                break;
            default:
                dropdown_param = "toBudget";
                break;
        }
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
