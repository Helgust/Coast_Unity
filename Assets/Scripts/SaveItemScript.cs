using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveItemScript : MonoBehaviour,IDeselectHandler,ISelectHandler
{
    public void OnDeselect(BaseEventData eventData)
    {
        GameUIManager.instance.isSaveItemDeSelected = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
        GameUIManager.instance.saveName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
    }
}
