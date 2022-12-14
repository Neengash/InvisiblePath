using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayState : GameState
{
    [SerializeField] GameObject gameplayUICanvas;
    [SerializeField] GamePlayManager gameplayManager;
    [SerializeField] InputManager inputManager;


    public override void EndState() {
        gameplayUICanvas.SetActive(false);
    }

    public override void StartState() {
        gameplayUICanvas.SetActive(true);
        gameplayManager.StartGame();
    }
}
