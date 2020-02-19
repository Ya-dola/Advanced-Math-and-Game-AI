using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
    public int NumberOfRolls;
    public int NumberOfFaces;
    // Start is called before the first frame update
    void Start()
    {
        //var randomList = Generate(NumberOfRolls, NumberOfFaces);
        //PrintAllValues(randomList);
        //GroupAllValues(randomList);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<int> Generate(int numberOfRolls, int numberOfFaces)
    {
        var result = new List<int>();
        for (int i = 0; i < numberOfRolls; i++)
        {
            var randomNumber = Random.Range(1, numberOfFaces + 1);
            result.Add(randomNumber);
        }

        return result;
    }

    public List<int> GenerateMax(int numberOfRolls, int numberOfFaces)
    {
        var result = new List<int>();
        for (int j = 0; j < numberOfRolls; j++)
        {
            var currentRollValues = new List<int>();
            for (int i = 0; i < numberOfRolls; i++)
            {
                var randomNumber = Random.Range(1, numberOfFaces + 1);
                currentRollValues.Add(randomNumber);
            }
            var max = GetMax(currentRollValues);
            result.Add(max);
        }
        

        return result;
    }

    public void PrintAllValues(List<int> list)
    {
        var allValues = "";
        foreach (var item in list)
        {
            allValues += item + " ";
        }

        Debug.Log(allValues);
    }

    public Dictionary<int, int> GroupAllValues(List<int> list)
    {
        var result = new Dictionary<int,int>();
        result = list.GroupBy(v => v).ToDictionary(v => v.Key, v => v.Count());
        var resultString = "";

        foreach (var item in result)
        {
            resultString += "Key: " + item.Key + ", Value: " + item.Value + "\n";
        }

        Debug.Log(resultString);
        Debug.Log("*******************************");

        return result;
    }

    public float GetAverage(Dictionary<int, int> groupedValues)
    {
        var result = 0f;

        foreach (var item in groupedValues)
        {
            result += item.Key * item.Value;
        }

        return result / NumberOfFaces;
    }

    public int GetMax(List<int> list)
    {
        var max = 0;
        foreach (var item in list)
        {
            if(item > max)
            {
                max = item;
            }
        }
        return max;
    }

}
