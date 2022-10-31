using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class MainMenuManager : Singleton<MainMenuManager>
{
    [SerializeField] GameObject mainPanel, settingsPanel;

    private void OnEnable() {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void VsPlayerGame() {
        GameData.Instance.vsAI = false;
        GameFlowManager.Instance.GamePlay();
    }

    public void VsAIGame() {
        GameData.Instance.vsAI = true;
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToMain() {
        GameData.Instance.vsAI = false;
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void EasyAIGame() {
        GameData.Instance.difficulty = Difficulty.EASY;
        GameFlowManager.Instance.GamePlay();
    }

    public void MediumAIGame() {
        GameData.Instance.difficulty = Difficulty.MEDIUM;
        GameFlowManager.Instance.GamePlay();
    }

    public void HardAIGame() {
        GameData.Instance.difficulty = Difficulty.HARD;
        GameFlowManager.Instance.GamePlay();
    }

}
