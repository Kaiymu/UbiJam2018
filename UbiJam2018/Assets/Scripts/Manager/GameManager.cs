using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public static Dictionary<Players, Score> scores = new Dictionary<Players, Score>();

    public enum Players { NONE, PLAYER_ONE, PLAYER_TWO, PLAYER_THREE, PLAYER_FOUR }

    public enum GameState { NONE, START, PLAY, END }
    public GameState gameState;
    private GameState _previousGameState;

    public TimerManager timerManager;

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

    private void Update() {
        SetGameState();
    }

    public void SetGameState() {

        if (timerManager.timer < 0 && gameState == GameState.START) {
            timerManager.ResetTimer(60);
            gameState = GameState.PLAY;
        } else if (timerManager.timer < 0 && gameState == GameState.PLAY) {
            gameState = GameState.END;
        }
    }

    public bool ChangedState () {
        if (_previousGameState == gameState)
            return false;
        else {
            _previousGameState = gameState;
            return true;
        }
    }
}
