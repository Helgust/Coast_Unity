using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSettings
{
    public int currentResolutionIndex;
    public int currentQualityIndex;
    public bool fullScreenflag;
    public int currentLanguage;

    public GameSettings()
    {
        this.fullScreenflag = false;
        this.currentLanguage = 0;
        this.currentResolutionIndex = 0;
        this.currentQualityIndex = 1;
    }

    public bool FullScreenflag
    {
        get => fullScreenflag;
        set => fullScreenflag = value;
    }

    public int CurrentLanguage
    {
        get => currentLanguage;
        set => currentLanguage = value;
    }


    public int CurrentResolutionIndex
    {
        get => currentResolutionIndex;
        set => currentResolutionIndex = value;
    }
    
    public int CurrentQualityIndex
    {
        get => currentQualityIndex;
        set => currentQualityIndex = value;
    }
}