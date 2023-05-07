using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [HideInInspector] public int Score;
    [HideInInspector] public int BestScore;
    public Text ScoreText;
    private void Start()
    {
        BestScore = PlayerPrefs.GetInt("Best");
    }

    public void UpdateScore(int value)
    {
        Score += value;
        ScoreText.text = $"{Score}";

        if(Score > BestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetInt("Best", BestScore);
        }
    }
}
