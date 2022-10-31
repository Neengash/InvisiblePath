using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayState : GameState
{
    [SerializeField] GameObject gameplayUICanvas;
    [SerializeField] GamePlayManager gameplayManager;
    [SerializeField] InputManager inputManager;
    [SerializeField] GameObject ball;
    [SerializeField] TextMeshProUGUI Player2Tag;

    const string PLAYER = "P2", AI = "AI";

    public override void EndState() {
        gameplayUICanvas.SetActive(false);
        inputManager.enabled = false;
        ball.transform.localScale = Vector3.zero;
    }

    public override void StartState() {
        gameplayUICanvas.SetActive(true);
        gameplayManager.StartGame();
        Player2Tag.text = GameData.Instance.vsAI ? AI : PLAYER;
    }
}
