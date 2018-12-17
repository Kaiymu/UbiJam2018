using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour {

    public GameObject spawningZone;
    public GameObject[] animals;
    public int initialNumberOfAnimals;
    public int spawningIntervalInSec;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < initialNumberOfAnimals; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
