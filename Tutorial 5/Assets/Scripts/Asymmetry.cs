using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asymmetry : MonoBehaviour
{
    public BarChart CurrentRollChart;
    public BarChart AsymmetryChart;
    public RandomNumberGenerator RandomNumberGenerator;

    List<int> allMax;
    // Start is called before the first frame update
    void Start()
    {
        allMax = new List<int>();
    }

    public void Generate()
    {
        //Get values of the current roll
        var maxValues = RandomNumberGenerator.GenerateMax(RandomNumberGenerator.NumberOfRolls, RandomNumberGenerator.NumberOfFaces);
        var maxGroupedValues = RandomNumberGenerator.GroupAllValues(maxValues);
        var currentAverage = (int)Math.Round(RandomNumberGenerator.GetAverage(maxGroupedValues), MidpointRounding.AwayFromZero);
        allMax.Add(currentAverage);

        //Normalize average values for visualization
        //var normalizedValues = new List<int>();
        //var averageCount = allAverages.Count;
        //foreach (var item in allAverages)
        //{
        //    normalizedValues.Add(item / averageCount * RandomNumberGenerator.NumberOfFaces);
        //}

        var totalGroupedValues = RandomNumberGenerator.GroupAllValues(allMax);

        //Draw charts
        CurrentRollChart.DrawChart(maxGroupedValues);
        AsymmetryChart.DrawChart(totalGroupedValues);

    }
}
