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
            totalPoints += 3;
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

    public int getChicken()
    {
        var chickenType = typeof(Chicken);
        if (caught.ContainsKey(chickenType))
        {
            return caught[chickenType];
        } else
        {
            return 0;
        }
    }
    public int getCow()
    {
        var cowType = typeof(Cow);
        if (caught.ContainsKey(cowType))
        {
            return caught[cowType];
        }
        else
        {
            return 0;
        }
    }

    public int getSheep()
    {
        var sheepType = typeof(Sheep);
        if (caught.ContainsKey(sheepType))
        {
            return caught[sheepType];
        }
        else
        {
            return 0;
        }
    }

}
