using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class GameFlowManager : Singleton<GameFlowManager>
{
    [SerializeField] GameState MainMenuManager;
    [SerializeField] GameState GamePlayManager;
    [SerializeField] GameState EndGameManager;

    [SerializeField] GameObject MainMenuPanel, SettingsPanel;

    private void Start() {
        Application.targetFrameRate = 60;
        MainMenu();
    }

    public void MainMenu() {
        MainMenuManager.StartState();
        GamePlayManager.EndState();
        EndGameManager.EndState();

        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void GamePlay() {
        GameData.Instance.vsAI = false;
        MainMenuManager.EndState();
        GamePlayManager.StartState();
        EndGameManager.EndState();
    }

    public void DifficultySelection() {
        GameData.Instance.vsAI = true;
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void EasyDifficulty() {
        GameData.Instance.difficulty = Difficulty.EASY;
        GamePlayVsAI();
    }

    public void MediumDifficulty() {
        GameData.Instance.difficulty = Difficulty.MEDIUM;
        GamePlayVsAI();
    }

    public void HardDifficulty() {
        GameData.Instance.difficulty = Difficulty.HARD;
        GamePlayVsAI();
    }

    public void BackToMain() {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    private void GamePlayVsAI() {
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

    public void PlayAgain() {
        AIController.Instance.LoadAI();
        MainMenuManager.EndState();
        GamePlayManager.StartState();
        EndGameManager.EndState();
    }
}
