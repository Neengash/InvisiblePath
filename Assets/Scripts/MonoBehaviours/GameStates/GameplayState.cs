using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : GameState
{
    [SerializeField] GameObject gameplayUICanvas;
    [SerializeField] MonoBehaviour[] dependencies;

    public override void EndState() {
        gameplayUICanvas.SetActive(false);

        for (int i = 0; i < dependencies.Length; i++) {
            dependencies[i].enabled = false;
        }
    }

    public override void StartState() {
        gameplayUICanvas.SetActive(true);

        for (int i = 0; i < dependencies.Length; i++) {
            dependencies[i].enabled = true;
        }
    }
}
