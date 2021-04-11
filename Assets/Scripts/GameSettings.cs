using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSettings : MonoBehaviour
{
    public int currentResolutionIndex;
    public int currentQualityIndex;
    public bool fullScreenflag;
    public int currentLanguage;

    public GameSettings()
    {
        this.fullScreenflag = false;
        currentLanguage = 0;
        currentResolutionIndex = 0;
        currentQualityIndex = 1;
    }
    
}
