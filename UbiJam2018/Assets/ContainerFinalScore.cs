using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerFinalScore : MonoBehaviour {

    public Text score;
    public Text chicken;
    public Text sheep;
    public Text cow;

    public GameManager.Players players;

    private void Start()
    {
        FillScore();
    }

    public void FillScore()
    {
        score.text = "Score : " + GameManager.GetScore(players).ToString();
        chicken.text = "Chicken : " + GameManager.GetScore(players).getChicken().ToString();
        sheep.text = "Sheep : " + GameManager.GetScore(players).getSheep().ToString();
        cow.text = "Cow : " + GameManager.GetScore(players).getCow().ToString();
    }
}
