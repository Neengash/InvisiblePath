using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : GameState
{
    [SerializeField] GameObject MainMenuCanvas;

    public override void EndState() {
        MainMenuCanvas.SetActive(false);
    }

    public override void StartState() {
        MainMenuCanvas.SetActive(true);
        GameData.Instance.Reset();
    }
}
