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

    public void FillScore()
    {
        GameManager.GetScore(players).getChicken();
    }
}
