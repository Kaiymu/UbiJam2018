using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingZone : MonoBehaviour {

    public GameManager.Team playersFarm;

    private List<Animal> _animalsInFarms = new List<Animal>();

    public void AddAnimalsInFarm(Animal animalInFarm)
    {
        animalInFarm.isInFarm = true;
        _animalsInFarms.Add(animalInFarm);
    }
}
