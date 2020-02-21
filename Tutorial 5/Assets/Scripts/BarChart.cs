using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarChart : MonoBehaviour
{
    public Vector3 StartingPosition;
    public int XSpacing;
    public int YSpacing;
    public GameObject ChartBar;
    public TextMeshPro Text;
    public RandomNumberGenerator RandomNumberGenerator;
    public bool UpdateCameraPosition;

    private Transform HorizontalTexts;
    private Transform VerticalTexts;
    private Transform Bars;
    // Start is called before the first frame update
    void Start()
    {
        HorizontalTexts = transform.GetChild(0);
        VerticalTexts = transform.GetChild(1);
        Bars = transform.GetChild(2);
    }

    public void ClearChart()
    {
        DestroyChildrenObjects(HorizontalTexts);
        DestroyChildrenObjects(VerticalTexts);
        DestroyChildrenObjects(Bars);
    }

    public void CreateChart()
    {
        var values = RandomNumberGenerator.Generate(RandomNumberGenerator.NumberOfRolls, RandomNumberGenerator.NumberOfFaces);
        var groupedValues = RandomNumberGenerator.GroupAllValues(values);
        DrawChart(groupedValues);
    }

    public void DrawChart(Dictionary<int,int> groupedValues)
    {
        ClearChart();
        //X Axis
        for (int i = 1; i <= RandomNumberGenerator.NumberOfFaces; i++)
        {
            if (groupedValues.ContainsKey(i))
            {
                var barPosition = new Vector3(i + (i * XSpacing), 0, 0);
                var yScale = groupedValues[i];
                var bar = Instantiate(ChartBar, StartingPosition + barPosition, Quaternion.identity, Bars);
                bar.transform.localScale = new Vector3(1, yScale + (yScale * YSpacing), 1);
            }

            //horizontal text
            var textPosition = new Vector3(i + (i * XSpacing), -1, 0);
            var xText = Instantiate(Text.gameObject, StartingPosition + textPosition, Quaternion.identity, HorizontalTexts);
            xText.GetComponent<TextMeshPro>().text = i.ToString();
        }

        //Y Axis
        for (int i = 1; i <= RandomNumberGenerator.NumberOfRolls; i++)
        {
            //vertical text
            var textPosition = new Vector3(-1, i + (i * YSpacing), 0);
            var yText = Instantiate(Text.gameObject, StartingPosition + textPosition, Quaternion.identity, VerticalTexts);
            yText.GetComponent<TextMeshPro>().text = i.ToString();
        }

        //Update Camera position
        if (UpdateCameraPosition)
        {
            var halfXSize = RandomNumberGenerator.NumberOfFaces / 2;
            var xPos = halfXSize * XSpacing + halfXSize;
            var YPos = RandomNumberGenerator.NumberOfRolls / 2 * YSpacing + 1;
            var startZoom = -14;
            Camera.main.transform.localPosition = new Vector3(xPos, YPos, startZoom - (XSpacing - 1) * halfXSize);
        }
    }

    private void DestroyChildrenObjects(Transform parent)
    {
        foreach (Transform item in parent)
        {
            Destroy(item.gameObject);
        }
    }
}
