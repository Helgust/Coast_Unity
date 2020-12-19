using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StatWindows : MonoBehaviour
{
    private Window_graph windowGraph;
    // Start is called before the first frame update
    private void Awake() 
    {
        Setup();   
    }
    // Update is called once per frame
    public void Setup()
    {
        windowGraph = transform.Find("pfWindow_Graph").GetComponent<Window_graph>();
        if (windowGraph) {
            Debug.Log(windowGraph.name);
        } else {
            Debug.Log("No game object called wibble found");
        }
        
    }

    public void ShowData()
    {
        Setup();
        List<float> valueList = new List<float>() {1,2,10,20,40,25};
        windowGraph.ShowGraph(valueList);
    }
}
