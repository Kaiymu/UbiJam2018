using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour {

    [Header("Spawning")]
    public GameObject spawningZone;
    public GameObject animalZone;

    public Animal[] animals;
    public int initialNumberOfAnimals;
    public float startSpawningTimeInSec;
    public int minSpawningTimeInSec;
    public int maxSpawningTimeInSec;

    private bool shouldSpawn = true;

    public Vector2 customBoundValue;
    void Spawn()
    {
        GameObject randomAnimal = GetRandomAnimal();
        Vector2 position = GetRandomPosition();
        var animal = Instantiate(randomAnimal, position, Quaternion.identity);

        Collider2D animalZoneCollider = animalZone.GetComponent<Collider2D>();
        float animalZoneRightLimit = animalZone.transform.position.x + (customBoundValue.x / 2);
        float animalZoneLeftLimit = animalZone.transform.position.x - (customBoundValue.x / 2);
        float animalZoneTopLimit = animalZone.transform.position.y + (customBoundValue.y / 2);
        float animalZoneBottomLimit = animalZone.transform.position.y - (customBoundValue.y / 2);
        Vector2 zoneTopLeft = new Vector2(animalZoneLeftLimit, animalZoneTopLimit);
        Vector2 zoneBottomRight = new Vector2(animalZoneRightLimit, animalZoneBottomLimit);

        animal.GetComponent<Animal>().setBoundSize(zoneTopLeft, zoneBottomRight);
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
        if (shouldSpawn)
        {
            int lenght = maxSpawningTimeInSec - minSpawningTimeInSec;
            float randomInterval = minSpawningTimeInSec + Mathf.Sin((10 * Random.value) / Mathf.PI) * lenght;
            Spawn();
            Invoke("InvokeSpawn", randomInterval);
        }
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

    public void stopSpawning()
    {
        shouldSpawn = false;
    }
}
