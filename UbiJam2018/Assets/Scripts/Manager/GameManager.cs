using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public static Dictionary<Players, Score> scores = new Dictionary<Players, Score>();

    public enum Players { NONE, PLAYER_ONE, PLAYER_TWO, PLAYER_THREE, PLAYER_FOUR }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static void addPoints(Players player, Animal animal)
    {
        if (animal == null)
            return;

        if (!scores.ContainsKey(player))
            scores[player] = new Score();
        scores[player].add(animal);
    }

    public static Score GetScore(Players player)
    {
        return scores[player];
    }
}
