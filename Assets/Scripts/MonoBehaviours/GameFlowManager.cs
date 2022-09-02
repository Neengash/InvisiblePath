using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class GameFlowManager : Singleton<GameFlowManager>
{
    [SerializeField] GameState MainMenuManager;
    [SerializeField] GameState GamePlayManager;
    [SerializeField] GameState EndGameManager;

    private void Start() {
        MainMenuManager.StartState();
        GamePlayManager.EndState();
        EndGameManager.EndState();
    }
}
