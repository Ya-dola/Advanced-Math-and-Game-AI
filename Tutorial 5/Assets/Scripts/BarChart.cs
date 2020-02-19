using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarChart : MonoBehaviour
{
    public int XSpacing;
    public int YSpacing;
    public GameObject ChartBar;
    public TextMeshPro Text;
    public RandomNumberGenerator randomNumberGenerator;

    private Transform HorizontalTexts;
    private Transform VerticalTexts;
    private Transform Bars;
    // Start is called before the first frame update
    void Start()
    {
        HorizontalTexts = transform.GetChild(0);
        VerticalTexts = transform.GetChild(1);
        Bars = transform.GetChild(2);
        CreateChart();
    }

    public void RebuildChart()
    {
        DestroyChildrenObjects(HorizontalTexts);
        DestroyChildrenObjects(VerticalTexts);
        DestroyChildrenObjects(Bars);
        
        CreateChart();
    }

    public void CreateChart()
    {
        var values = randomNumberGenerator.Generate(randomNumberGenerator.NumberOfRolls, randomNumberGenerator.NumberOfFaces);
        var groupedValues = randomNumberGenerator.GroupAllValues(values);

        for (int i = 1; i <= randomNumberGenerator.NumberOfFaces; i++)
        {
            if (groupedValues.ContainsKey(i))
            {
                var yScale = groupedValues[i];
                var bar = Instantiate(ChartBar, new Vector3(i + (i * XSpacing), 0, 0), Quaternion.identity, Bars);
                bar.transform.localScale = new Vector3(1, yScale + (yScale * YSpacing), 1);
            }

            //horizontal text
            var xText = Instantiate(Text.gameObject, new Vector3(i + (i * XSpacing), -1, 0), Quaternion.identity, HorizontalTexts);
            xText.GetComponent<TextMeshPro>().text = i.ToString();

            //vertical text
            var yText = Instantiate(Text.gameObject, new Vector3(-1, i + (i * YSpacing), 0), Quaternion.identity, VerticalTexts);
            yText.GetComponent<TextMeshPro>().text = i.ToString();
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
