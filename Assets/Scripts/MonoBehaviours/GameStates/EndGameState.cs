using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : GameState
{
    [SerializeField] GameObject endGameCanvas;

    [SerializeField] LoadEndGameScore[] scores;
    [SerializeField] EndGameWinnerTag[] winnerTags;

    public override void EndState() {
        endGameCanvas.SetActive(false);
    }

    public override void StartState() {
        endGameCanvas.SetActive(true);
        for (int i = 0; i < scores.Length; i++) {
            scores[i].ReloadData();
        }
        for (int i = 0; i < winnerTags.Length; i++) {
            winnerTags[i].ReloadData();
        }
    }
}
