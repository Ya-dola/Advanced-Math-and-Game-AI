using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTimeData : MonoBehaviour
{
    public BarChart CurrentRollChart;
    public BarChart OverTimeChart;
    public RandomNumberGenerator RandomNumberGenerator;

    List<int> allAverages;
    // Start is called before the first frame update
    void Start()
    {
        allAverages = new List<int>();
    }

    public void Generate()
    {
        //Get values of the current roll
        var currentValues = RandomNumberGenerator.Generate(RandomNumberGenerator.NumberOfRolls, RandomNumberGenerator.NumberOfFaces);
        var currentGroupedValues = RandomNumberGenerator.GroupAllValues(currentValues);
        var currentAverage = (int)Math.Round(RandomNumberGenerator.GetAverage(currentGroupedValues), MidpointRounding.AwayFromZero);
        Debug.Log("currentAverage: " + currentAverage);

        //Keep track of all averages
        allAverages.Add(currentAverage);

        //Normalize average values for visualization
        //var normalizedValues = new List<int>();
        //var averageCount = allAverages.Count;
        //foreach (var item in allAverages)
        //{
        //    normalizedValues.Add(item / averageCount * RandomNumberGenerator.NumberOfFaces);
        //}

        var totalGroupedValues = RandomNumberGenerator.GroupAllValues(allAverages);

        //Draw charts
        CurrentRollChart.DrawChart(currentGroupedValues);
        OverTimeChart.DrawChart(totalGroupedValues);

    }
}
