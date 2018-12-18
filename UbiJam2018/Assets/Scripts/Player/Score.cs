using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int points;
    private Dictionary<Type, int> caught;

	// Use this for initialization
	void Start () {
        points = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void add(Animal animal)
    {
        Type type = animal.GetType();
        if (!caught.ContainsKey(type))
        {
            caught[type] = 0;
        }
        caught[type]++;

        points += animal.points;
    }
}
