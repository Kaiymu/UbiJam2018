using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour {

    [Header("Spawning")]
    public GameObject spawningZone;
    public Animal[] animals;
    public int initialNumberOfAnimals;
    public float startSpawningTimeInSec;
    public int minSpawningTimeInSec;
    public int maxSpawningTimeInSec;

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
        float X = spawningZone.transform.position.x;
        float Y = spawningZone.transform.position.y;
        if (Random.value > 0.5f)
        {
            X = X + Random.value * (spawningZone.GetComponent<Collider2D>().bounds.size.x / 2.0f);
        } else
        {
            X = X - Random.value * (spawningZone.GetComponent<Collider2D>().bounds.size.x / 2.0f);
        }
        if (Random.value > 0.5f)
        {
            Y = Y + Random.value * (spawningZone.GetComponent<Collider2D>().bounds.size.y / 2.0f);
        }
        else
        {
            Y = Y - Random.value * (spawningZone.GetComponent<Collider2D>().bounds.size.y / 2.0f);
        }
        return new Vector2(X, Y);
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

    void InvokeSpawn()
    {
        int lenght = maxSpawningTimeInSec + 1 - minSpawningTimeInSec;
        int[] prob;
        for (int i = 0; i <= lenght; i++)
        {
        }
        float randomInterval = Random.Range(minSpawningTimeInSec, maxSpawningTimeInSec);
        Spawn();
        Invoke("InvokeSpawn", randomInterval);
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < initialNumberOfAnimals - 1; i++)
        {
            Spawn();
        }
        Invoke("InvokeSpawn", startSpawningTimeInSec);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
