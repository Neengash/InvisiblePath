using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : GameState
{
    [SerializeField] GameObject endGameCanvas;

    public override void EndState() {
        endGameCanvas.SetActive(false);
    }

    public override void StartState() {
        endGameCanvas.SetActive(true);
    }
}
