using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Text scoreLabel;
    private int score;

    private void Start()
    {
        AddScore(0);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "SCORE: " + score.ToString(); 
    }
}
