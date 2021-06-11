using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapItemScript : MonoBehaviour,IDeselectHandler,ISelectHandler
{
    public void OnDeselect(BaseEventData eventData)
    {
        //MenuManager.instance.isSaveItemDeSelected = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
        MenuManager.instance.Description.GetComponent<LocalizedText>().LocalizationKey = 
            "NewGame."+EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Map>().descriptionName;
        MenuManager.instance.Description.GetComponent<LocalizedText>().Start();
        Basket.instance.mapData = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Map>();
    }
}
