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
        UIManager.instance.isSaveItemDeSelected = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
        UIManager.instance.saveName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
    }
}
