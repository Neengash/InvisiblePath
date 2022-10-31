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
        Application.targetFrameRate = 60;
        MainMenu();
    }

    public void MainMenu() {
        MainMenuManager.StartState();
        GamePlayManager.EndState();
        EndGameManager.EndState();
    }

    public void GamePlay() {
        MainMenuManager.EndState();
        GamePlayManager.StartState();
        EndGameManager.EndState();
    }

    public void GamePlayVsAI() {
        GameData.Instance.vsAI = true;
        AIController.Instance.LoadAI();
        MainMenuManager.EndState();
        GamePlayManager.StartState();
        EndGameManager.EndState();
    }

    public void EndGame() {
        MainMenuManager.EndState();
        GamePlayManager.EndState();
        EndGameManager.StartState();
    }
}