using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Feto;

public class ScoreManager : Singleton<ScoreManager>
{
    int p1Score, p2Score;
    [SerializeField] TextMeshProUGUI p1ScoreGamePlay, p2ScoreGamePlay;
    [SerializeField] AudioSource audioSource;

    const string PLAYER1_SCORE = "P1", PLAYER2_SCORE = "P2";

    protected override void Awake() {
        base.Awake();
        LoadScores();
    }

    private void LoadScores() {
        p1Score = PlayerPrefs.GetInt(PLAYER1_SCORE, 0);
        p2Score = PlayerPrefs.GetInt(PLAYER2_SCORE, 0);
    }

    private void SaveScores() {
        PlayerPrefs.SetInt(PLAYER1_SCORE, p1Score);
        PlayerPrefs.SetInt(PLAYER2_SCORE, p2Score);
    }

    public void ResetScores() {
        p1Score = 0;
        p2Score = 0;
        SaveScores();
        p1ScoreGamePlay.text = p1Score.ToString();
        p2ScoreGamePlay.text = p2Score.ToString();
    }

    public void Score(Player player) {
        if (player == Player.FIRST) {
            p1Score++;
            p1ScoreGamePlay.text = p1Score.ToString();
        } else {
            p2Score++;
            p2ScoreGamePlay.text = p2Score.ToString();
        }
        SaveScores();
        audioSource.Play();
        ScoreStarController.Instance.HideStar();
    }

    public int GetScore(Player player) {
        return player == Player.FIRST
            ? p1Score
            : p2Score;
    }

    public bool IsWinner(Player player) {
        return player == Player.FIRST
            ? p1Score > p2Score
            : p2Score > p1Score;
    }

    public bool EndGame() {
        return p1Score >= 3 || p2Score >= 3;
    }
}
