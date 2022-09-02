using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : GameState
{
    [SerializeField] GameObject gameplayUICanvas;

    public override void EndState() {
        gameplayUICanvas.SetActive(false);
    }

    public override void StartState() {
        gameplayUICanvas.SetActive(true);
    }
}
