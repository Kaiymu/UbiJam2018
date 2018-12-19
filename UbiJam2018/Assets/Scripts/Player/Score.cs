using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private int totalPoints = 0;
    private Dictionary<Type, int> caught = new Dictionary<Type, int>();

    public Score()
    {
    }

    public void add(Animal animal)
    {
        Type type = animal.GetType();
        if (!caught.ContainsKey(type))
        {
            caught[type] = 0;
        }
        caught[type]++;
        if (animal.GetType() == typeof(Chicken))
        {
            totalPoints += 1;
        }
        if (animal.GetType() == typeof(Sheep))
        {
            totalPoints += 2;
        }
        if (animal.GetType() == typeof(Cow))
        {
            totalPoints += 5;
        }
    }

    public override string ToString()
    {
        return totalPoints.ToString();
    }
}
