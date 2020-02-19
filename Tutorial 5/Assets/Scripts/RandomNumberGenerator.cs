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
            var randomNumber = Random.Range(1, numberOfFaces);
            result.Add(randomNumber);
        }

        return result;
    }

    private void PrintAllValues(List<int> list)
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

        foreach (var item in result)
        {
            Debug.Log(item.Key + ": " + item.Value);
        }

        return result;

    }

}
