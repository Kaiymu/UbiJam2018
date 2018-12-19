using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreP1;
    public Text ScoreP2;
    public Text ScoreP3;
    public Text ScoreP4;

    public static GameManager Instance;
    public static Dictionary<Players, Score> scores = new Dictionary<Players, Score>();

    public enum Players { NONE, PLAYER_ONE, PLAYER_TWO, PLAYER_THREE, PLAYER_FOUR }

    public enum GameState { NONE, START, PLAY, END }
    public GameState gameState;
    private GameState _previousGameState;

    public TimerManager timerManager;
    public Text timerTextGame;

    public RectTransform finalScore;
    public RectTransform backgroundBlack;

    public SpawningManager spawningManager;

    [Header("Audios")]
    public AudioClip rumbleSound;
    public AudioClip scoreRecapSound;
    public AudioClip cloche;

    private AudioSource _audioSource;

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


        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = rumbleSound;
        _audioSource.Play();
        _audioSource.loop = true;

        scores.Clear();

        scores.Add(Players.PLAYER_ONE, new Score());
        scores.Add(Players.PLAYER_TWO, new Score());
        scores.Add(Players.PLAYER_THREE, new Score());
        scores.Add(Players.PLAYER_FOUR, new Score());
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

    private void Update()
    {
        SetGameState();
        SetScores();
    }

    private void SetScores()
    {
        ScoreP1.text = scores.ContainsKey(Players.PLAYER_ONE) ? GetScore(Players.PLAYER_ONE).ToString() : "0";
        ScoreP2.text = scores.ContainsKey(Players.PLAYER_TWO) ? GetScore(Players.PLAYER_TWO).ToString() : "0";
        ScoreP3.text = scores.ContainsKey(Players.PLAYER_THREE) ? GetScore(Players.PLAYER_THREE).ToString() : "0";
        ScoreP4.text = scores.ContainsKey(Players.PLAYER_FOUR) ? GetScore(Players.PLAYER_FOUR).ToString() : "0";
    }

    public void SetGameState()
    {
        if (timerManager.timer < 0 && gameState == GameState.START)
        {
            timerManager.ChangeText(timerTextGame);
            timerManager.ResetTimer(120);
            gameState = GameState.PLAY;
            _audioSource.PlayOneShot(cloche);

        }
        else if (timerManager.timer < 0 && gameState == GameState.PLAY)
        {
            gameState = GameState.END;
            spawningManager.stopSpawning();

            _audioSource.clip = scoreRecapSound;
            _audioSource.Play();
            _audioSource.loop = true;
        }

        finalScore.gameObject.SetActive(gameState == GameState.END);
        backgroundBlack.gameObject.SetActive(gameState == GameState.END);
    }

    public bool ChangedState()
    {
        if (_previousGameState == gameState)
            return false;
        else
        {
            _previousGameState = gameState;
            return true;
        }
    }
}
