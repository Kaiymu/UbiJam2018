﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour {

    [Header("Spawning")]
    public GameObject spawningZone;
    public Animal[] animals;
    public int initialNumberOfAnimals;
    public float spawningIntervalInSec;
    public float startSpawningTimeInSec;

    void Spawn()
    {
        GameObject randomAnimal = GetRandomAnimal();
        //Debug.Log(randomAnimal.name);
        Vector2 position = GetRandomPosition();
        //Debug.Log(position);
        Instantiate(randomAnimal, position, Quaternion.identity);
    }

    Vector2 GetRandomPosition()
    {
        float originX = spawningZone.transform.position.x + (spawningZone.GetComponent<Collider2D>().bounds.size.x / 2.0f);
        float originY = spawningZone.transform.position.y + spawningZone.GetComponent<Collider2D>().bounds.size.y;

        return new Vector2(Random.value * originX, Random.value * originY);
    }

    GameObject GetRandomAnimal()
    {
        float total = 0;

        foreach(Animal a in animals)
        {
            total += a.probability;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < animals.Length; i++)
        {
            if (randomPoint < animals[i].probability)
            {
                return animals[i].gameObject;
            }
            else {
                randomPoint -= animals[i].probability;
            }
        }
        return animals[animals.Length - 1].gameObject;
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < initialNumberOfAnimals - 1; i++)
        {
            Spawn();
        }
        InvokeRepeating("Spawn", startSpawningTimeInSec, spawningIntervalInSec);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
