using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Score")]
    public Text ScoreP1;
    public Text ScoreP2;
    public Text ScoreP3;
    public Text ScoreP4;

    public List<Team> teamScoreAssociated = new List<Team>(4);

    public static GameManager Instance;
    public static Dictionary<Team, Score> scores = new Dictionary<Team, Score>();

    public enum Players { NONE, PLAYER_ONE, PLAYER_TWO, PLAYER_THREE, PLAYER_FOUR }
    public enum Team { NONE, TEAM_1, TEAM_2, TEAM_3, TEAM_4}

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

        scores.Add(Team.TEAM_1, new Score());
        scores.Add(Team.TEAM_2, new Score());
        scores.Add(Team.TEAM_3, new Score());
        scores.Add(Team.TEAM_4, new Score());
    }

    public void AddPoints(Team player, Animal animal)
    {
        if (animal == null)
            return;

        if (!scores.ContainsKey(player)) {
            scores[player] = new Score();
        }

        scores[player].Add(animal);
    }

    public static Score GetScore(Team player)
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
        ScoreP1.text = scores.ContainsKey(teamScoreAssociated[0]) ? GetScore(teamScoreAssociated[0]).ToString() : "0";
        ScoreP2.text = scores.ContainsKey(teamScoreAssociated[1]) ? GetScore(teamScoreAssociated[1]).ToString() : "0";
        ScoreP3.text = scores.ContainsKey(teamScoreAssociated[2]) ? GetScore(teamScoreAssociated[2]).ToString() : "0";
        ScoreP4.text = scores.ContainsKey(teamScoreAssociated[3]) ? GetScore(teamScoreAssociated[3]).ToString() : "0";
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
