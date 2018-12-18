using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public Dictionary<Players, Score> scores;

    public enum Players { NONE, PLAYER_ONE, PLAYER_TWO, PLAYER_THREE, PLAYER_FOUR}
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    public void addPoints(Players player, Animal animal)
    {
        scores[player].add(animal);
    }
}
