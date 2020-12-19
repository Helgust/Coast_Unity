using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_graph : MonoBehaviour
{
    private static Window_graph instance;
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;
    private List<GameObject> gameObjectList;
    private GameObject tooltipGameObject;


    private void Awake()
    {
        instance = this;
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        tooltipGameObject = graphContainer.Find("tooltipTemplate").gameObject;
        gameObjectList = new List<GameObject>();


        //List<int> valueList = new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33, 50, 45, 10, 50, 10,34,21,4,6,2,43,1,23};
        //List<int> valueList = new List<int>() { 5, 98, 56, 45, 30, 22, 34, 21, 4, 6, 2, 43, 1, 23 };
        //IGraphVisual graphVisual = new LineGraphVisual(graphContainer, circleSprite, Color.green, new Color(1, 1, 1, .5f));
        //ShowGraph(valueList, graphVisual, -1, (int _i) => "Year " + (_i + 1), (float _f) => "$" + Mathf.RoundToInt(_f));
    }


    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    public void ShowGraph(List<float> valueList, IGraphVisual graphVisual = null, int maxVisibleAmontValues = -1, Func<int, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null)
    {
        if (graphVisual == null)
        {
            graphVisual = new LineGraphVisual(graphContainer, circleSprite, Color.green, new Color(1, 1, 1, .5f));
        }
        if (getAxisLabelX == null)
        {
            getAxisLabelX = delegate (int _i) { return _i.ToString(); };
        }

        if (getAxisLabelY == null)
        {
            getAxisLabelY = delegate (float _f) { return Math.Round(_f,2).ToString(); };
        }

        if (maxVisibleAmontValues <= 0)
        {
            maxVisibleAmontValues = valueList.Count;
        }

        foreach (GameObject gameObject in gameObjectList)
        {
            Destroy(gameObject);
        }
        gameObjectList.Clear();

        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = valueList[0];
        float yMinimum = valueList[0];
        //float yMinimum = 0;


        for (int i = Mathf.Max((valueList.Count - maxVisibleAmontValues), 0); i < valueList.Count; i++)
        {
            float value = valueList[i];
            if (value > yMaximum)
            {
                yMaximum = value;
            }

              if(value<yMinimum) //decomment for dynamic bottom border
             {
                 yMinimum=value;
             } 
        }
        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0)
        {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - ((yMaximum-yMinimum)*0.2f); //decomment for dynamic bottom border
        float xSize = graphWidth / (maxVisibleAmontValues + 1);
        int xIndex = 0;
        //GameObject lastCircleGameObject = null;
        //LineGraphVisual lineGraphVisual = new LineGraphVisual(graphContainer,circleSprite, Color.green, new Color(1, 1, 1, .5f));
        for (int i = Mathf.Max((valueList.Count - maxVisibleAmontValues), 0); i < valueList.Count; i++)
        {
            float xPosition = xSize + xIndex * xSize;
            float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;

            string toolTipText = getAxisLabelY(valueList[i]);
            gameObjectList.AddRange(graphVisual.AddGraphVisual(new Vector2(xPosition, yPosition), xSize));
            /* GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            gameObjectList.Add(circleGameObject);
            if (lastCircleGameObject != null)
            {
                GameObject dotConnectionGameObject = CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectList.Add(dotConnectionGameObject);
            }
            lastCircleGameObject = circleGameObject; */

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -7f);
            labelX.GetComponent<Text>().text = getAxisLabelX(i);
            gameObjectList.Add(labelX.gameObject);

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(xPosition, -3f);
            gameObjectList.Add(dashY.gameObject);

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

        xIndex = 0;
        for (int i = Mathf.Max((valueList.Count - maxVisibleAmontValues), 0); i < valueList.Count; i++)
        {
            float fristElemOnVis = valueList[Mathf.Max((valueList.Count - maxVisibleAmontValues), 0)];
            float xPosition = xSize + xIndex * xSize;
            float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;

            string toolTipText = getAxisLabelY(valueList[i]);

            GameObject toolT = Instantiate(tooltipGameObject);
            toolT.SetActive(true);
            toolT.transform.SetParent(graphContainer, false);
            yPosition -= 25f;
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
            gameObjectList.Add(toolT);

            xIndex++;
        }

        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float noramlizeValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-30f, noramlizeValue * graphHeight);
            labelY.GetComponent<Text>().text = getAxisLabelY(yMinimum + (noramlizeValue * (yMaximum - yMinimum)));
            gameObjectList.Add(labelY.gameObject);

            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(-4f, noramlizeValue * graphHeight);
            gameObjectList.Add(dashX.gameObject);
        }
    }

    private GameObject CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
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

    private class LineGraphVisual : IGraphVisual
    {
        private RectTransform graphContainer;
        private Sprite circleSprite;
        private GameObject lastCircleGameObject;
        private Color circleColor;
        private Color circleConnectionColor;


        public LineGraphVisual(RectTransform graphContainer, Sprite circleSpriteExt, Color circleColor, Color circleConnectionColor)
        {
            this.graphContainer = graphContainer;
            this.circleSprite = circleSpriteExt;
            this.lastCircleGameObject = null;
            this.circleColor = circleColor;
            this.circleConnectionColor = circleConnectionColor;
        }

        public List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositonWidth)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            GameObject circleGameObject = CreateCircle(graphPosition);
 
            gameObjectList.Add(circleGameObject);
            if (lastCircleGameObject != null)
            {
                GameObject dotConnectionGameObject = CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectList.Add(dotConnectionGameObject);
            }
            lastCircleGameObject = circleGameObject;
            return gameObjectList;
        }

        private GameObject CreateCircle(Vector2 anchoredPosition)
        {
            GameObject gameObject = new GameObject("circle", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().sprite = circleSprite;
            gameObject.GetComponent<Image>().color = circleColor;
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = anchoredPosition;
            rectTransform.sizeDelta = new Vector2(11, 11);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            return gameObject;
        }
        private GameObject CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
        {
            GameObject gameObject = new GameObject("dotConnection", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().color = circleConnectionColor;
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
        List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositonWidth);
    }
}
