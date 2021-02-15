using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveItemScript : MonoBehaviour,IDeselectHandler
{

    public void OnDeselect(BaseEventData eventData)
    {
        //Debug.Log("Deselected");
        UIManager.instance.isSaveDeSelected = true;
        //UIManager.instance.choosedSave = String.Empty;
    }
}
