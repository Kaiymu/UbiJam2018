using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{

    private int points;
    private Dictionary<Type, int> caught;

    public Score()
    {
        points = 0;
        caught = new Dictionary<Type, int>();
    }
    
    public void add(Animal animal)
    {
        Type type = animal.GetType();
        if (!caught.ContainsKey(type))
        {
            caught[type] = 0;
        }
        caught[type]++;

        points += animal.points;
    }

    public override string ToString()
    {
        String result = "Points: " + points.ToString() + "\n";

        foreach (Type type in caught.Keys)
        {
            result += type.ToString() + ": " + caught[type] + "\n";
        }

        return result;
    }
}
