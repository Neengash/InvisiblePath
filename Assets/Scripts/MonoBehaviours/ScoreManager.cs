using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Feto;

public class ScoreManager : Singleton<ScoreManager>
{
    int p1Score, p2Score;
    [SerializeField] TextMeshProUGUI p1ScoreText, p2ScoreText;

    public void ResetScores() {
        p1Score = 0;
        p2Score = 0;
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();
    }

    public void Score(Players player) {
        if (player == Players.FIRST) {
            p1Score++;
            p1ScoreText.text = p1Score.ToString();
        } else {
            p2Score++;
            p2ScoreText.text = p2Score.ToString();
        }
    }
}
