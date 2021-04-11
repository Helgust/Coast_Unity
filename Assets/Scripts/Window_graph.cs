using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_graph : MonoBehaviour
{
    private static Window_graph instance;
    [SerializeField] private GameObject circleObject;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;
    private List<GameObject> _gameObjectList;
    private GameObject tooltipGameObject;
    private List<IGraphVisual> _lineGraphVisualsList;


    private void Awake()
    {
        Debug.Log("HUI");
        instance = this;
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        tooltipGameObject = graphContainer.Find("tooltipTemplate").gameObject;
        _gameObjectList = new List<GameObject>();


        //List<int> valueList = new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33, 50, 45, 10, 50, 10,34,21,4,6,2,43,1,23};
        //List<int> valueList = new List<int>() { 5, 98, 56, 45, 30, 22, 34, 21, 4, 6, 2, 43, 1, 23 };
        //IGraphVisual graphVisual = new LineGraphVisual(graphContainer, circleSprite, Color.green, new Color(1, 1, 1, .5f));
        //ShowGraph(valueList, graphVisual, -1, (int _i) => "Year " + (_i + 1), (float _f) => "$" + Mathf.RoundToInt(_f));
    }

    public void ShowGraph(Dictionary<string, Color> paramDict, IGraphVisual graphVisual = null,
        int maxVisibleAmontValues = -1, Func<int, string> getAxisLabelX = null,
        Func<float, string> getAxisLabelY = null)
    {
        if (graphVisual == null)
        {
            graphVisual = new LineGraphVisual(graphContainer, circleObject, new Color(1, 1, 1, .5f),
                new Color(1, 1, 1, .5f));
        }

        if (getAxisLabelX == null)
        {
            getAxisLabelX = delegate(int _i) { return _i.ToString(); };
        }

        if (getAxisLabelY == null)
        {
            getAxisLabelY = delegate(float _f) { return Math.Round(_f, 2).ToString(); };
        }

        if (maxVisibleAmontValues <= 0)
        {
            maxVisibleAmontValues = GameManager.instance.currentYear + 1;
        }


        foreach (GameObject gameObject in _gameObjectList)
        {
            Destroy(gameObject);
        }

        _gameObjectList.Clear();

        Debug.Log("FUCKING_GOL.COUNT=" + _gameObjectList.Count);
        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;
        //float yMaximum = valueList[0];
        float yMaximum = 0;
        //float yMinimum = valueList[0];
        float yMinimum = 0;


        foreach (var param in paramDict)
        {
            for (int i = Mathf.Max((GameManager.instance.currentYear - 1 - maxVisibleAmontValues), 0);
                i < GameManager.instance.currentYear - 1;
                i++)
            {
                float value = DB.instance.statDict[param.Key][i];
                if (value > yMaximum)
                {
                    yMaximum = value;
                }


                //  if(value<yMinimum) //decomment for dynamic bottom border
                // {
                //     yMinimum=value;
                // } 
            }
        }

        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0)
        {
            yDifference = 5f;
        }

        yMaximum = yMaximum + (yDifference * 0.2f);
        //yMinimum = yMinimum - ((yMaximum-yMinimum)*0.2f); //decomment for dynamic bottom border
        float xSize = graphWidth / (maxVisibleAmontValues + 1);
        int xIndex = 0;
        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float noramlizeValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-100f, noramlizeValue * graphHeight);
            labelY.GetComponent<Text>().text = getAxisLabelY(yMinimum + (noramlizeValue * (yMaximum - yMinimum)));
            _gameObjectList.Add(labelY.gameObject);

            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(-4f, noramlizeValue * graphHeight);
            _gameObjectList.Add(dashX.gameObject);
        }

        xIndex = 0;
        
        xIndex = 0;
        for (int i = 0; i < GameManager.instance.currentYear; i++)
        {
            float xPosition = xSize + xIndex * xSize;
            
            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.SetSiblingIndex(8);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -7f);
            labelX.GetComponent<Text>().text = getAxisLabelX(i);
            _gameObjectList.Add(labelX.gameObject);

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.SetSiblingIndex(8);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(xPosition, -3f);
            _gameObjectList.Add(dashY.gameObject);

            ++xIndex;
        }
        
        foreach (var param in paramDict)
        {
            List<float> valueList = DB.instance.statDict[param.Key];
            xIndex = 0;
            //GameObject lastCircleGameObject = null;
            //LineGraphVisual lineGraphVisual = new LineGraphVisual(graphContainer,circleSprite, Color.green, new Color(1, 1, 1, .5f));
            for (int i = Mathf.Max((valueList.Count - maxVisibleAmontValues), 0); i < valueList.Count; i++)
            {
                float xPosition = xSize + xIndex * xSize;
                float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;

                string toolTipText = getAxisLabelY(valueList[i]);
                _gameObjectList.AddRange(graphVisual.AddGraphVisual(new Vector2(xPosition, yPosition), xSize,
                    param.Key + ": " + toolTipText,
                    param.Value, param.Value));
                /* GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
                gameObjectList.Add(circleGameObject);
                if (lastCircleGameObject != null)
                {
                    GameObject dotConnectionGameObject = CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                    gameObjectList.Add(dotConnectionGameObject);
                }
                lastCircleGameObject = circleGameObject; */
                /*GameObject toolT = Instantiate(tooltipGameObject);
                toolT.SetActive(true);
                toolT.transform.SetParent(graphContainer, false);
                if (yPosition > yMinimum + 20)
                {
                    yPosition -= 20f;
                }
                toolT.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPosition, yPosition);
                float textPaddingSize = 4f;
                toolT.transform.Find("text").GetComponent<Text>().text = toolTipText;
                 Vector2 backgroundSize = new Vector2(
                        toolT.transform.Find("text").GetComponent<Text>().preferredWidth + textPaddingSize * 2f,
                        toolT.transform.Find("text").GetComponent<Text>().preferredHeight + textPaddingSize * 2f
                );
                GameObject bg = toolT.transform.Find("backgroung").gameObject;
                bg.GetComponent<RectTransform>().sizeDelta = backgroundSize;
                toolT.transform.SetAsLastSibling();
                gameObjectList.Add(toolT);*/

                xIndex++;
            }

            graphVisual.SetlastCircleGameObject(null);
        }
        // xIndex = 0;
            // for (int i = Mathf.Max((GameManager.instance.currentYear - 1 - maxVisibleAmontValues), 0); i < GameManager.instance.currentYear - 1; i++)
            // {
            //     float fristElemOnVis = valueList[Mathf.Max((valueList.Count - maxVisibleAmontValues), 0)];
            //     float xPosition = xSize + xIndex * xSize;
            //     float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;
            //
            //     string toolTipText = getAxisLabelY(valueList[i]);
            //
            //     // GameObject toolT = Instantiate(tooltipGameObject);
            //     // toolT.SetActive(true);
            //     // toolT.transform.SetParent(graphContainer, false);
            //     // yPosition -= 25f;
            //     // toolT.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPosition, yPosition);
            //     // float textPaddingSize = 4f;
            //     // toolT.transform.Find("text").GetComponent<Text>().text = toolTipText;
            //     //  Vector2 backgroundSize = new Vector2(
            //     //         toolT.transform.Find("text").GetComponent<Text>().preferredWidth + textPaddingSize * 2f,
            //     //         toolT.transform.Find("text").GetComponent<Text>().preferredHeight + textPaddingSize * 2f
            //     // );
            //     // GameObject bg = toolT.transform.Find("backgroung").gameObject;
            //     // bg.GetComponent<RectTransform>().sizeDelta = backgroundSize;
            //     // toolT.transform.SetAsLastSibling();
            //     // gameObjectList.Add(toolT);
            //
            //     xIndex++;
            // }

        
    }

    private class LineGraphVisual : IGraphVisual
    {
        private RectTransform graphContainer;
        private GameObject _circleObject;
        private GameObject lastCircleGameObject;
        private Color circleColor;
        private Color circleConnectionColor;


        public LineGraphVisual(RectTransform graphContainer, GameObject circleSpriteExt, Color circleColor,
            Color circleConnectionColor)
        {
            this.graphContainer = graphContainer;
            this._circleObject = circleSpriteExt;
            this.lastCircleGameObject = null;
            this.circleColor = circleColor;
            this.circleConnectionColor = circleConnectionColor;
        }

        public void SetlastCircleGameObject(GameObject new_game_object)
        {
            this.lastCircleGameObject = new_game_object;
        }

        public List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositonWidth, string tooltipText,
            Color new_color, Color new_connection_color)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            GameObject circleGameObject = CreateCircle(graphPosition, tooltipText, new_color);

            gameObjectList.Add(circleGameObject);
            if (lastCircleGameObject != null)
            {
                GameObject dotConnectionGameObject = CreateDotConnection(
                    lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition,
                    circleGameObject.GetComponent<RectTransform>().anchoredPosition, new_connection_color);
                gameObjectList.Add(dotConnectionGameObject);
            }

            lastCircleGameObject = circleGameObject;
            return gameObjectList;
        }

        private GameObject CreateCircle(Vector2 anchoredPosition, string tooltipText, Color new_color)
        {
            GameObject gameObject = Instantiate(_circleObject);
            gameObject.transform.SetParent(graphContainer, false);
            //gameObject.GetComponent<Image>().sprite = circleSprite;
            gameObject.GetComponent<Image>().color = new_color;
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = anchoredPosition;
            rectTransform.sizeDelta = new Vector2(11, 11);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);

            GameObject toolT = gameObject.transform.GetChild(0).gameObject;
            toolT.transform.position = toolT.transform.position + Vector3.up * 10f;
            float textPaddingSize = 4f;
            toolT.transform.Find("text").GetComponent<Text>().text = tooltipText;
            Vector2 backgroundSize = new Vector2(
                toolT.transform.Find("text").GetComponent<Text>().preferredWidth + textPaddingSize * 2f,
                toolT.transform.Find("text").GetComponent<Text>().preferredHeight + textPaddingSize * 2f
            );
            GameObject bg = toolT.transform.Find("backgroung").gameObject;
            bg.GetComponent<RectTransform>().sizeDelta = backgroundSize;
            return gameObject;
        }

        private GameObject CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB,
            Color new_circleConnectionColor)
        {
            GameObject gameObject = new GameObject("dotConnection", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().color = new_circleConnectionColor;
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            Vector2 dir = (dotPositionB - dotPositionA).normalized;
            float distance = Vector2.Distance(dotPositionA, dotPositionB);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.sizeDelta = new Vector2(distance, 3f);
            rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
            rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

            return gameObject;
        }
    }

    public interface IGraphVisual
    {
        List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositonWidth, string tooltipText,
            Color circleColor, Color circleConnectionColor);

        void SetlastCircleGameObject(GameObject new_game_object);
    }
}