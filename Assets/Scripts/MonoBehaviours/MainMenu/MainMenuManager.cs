using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class MainMenuManager : Singleton<MainMenuManager>
{
    [SerializeField] GameObject mainPanel, settingsPanel;

    private void Start() {
        GameData.Instance.Reset();
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void VsPlayerGame() {
        GameData.Instance.vsAI = false;
        GameFlowManager.Instance.GamePlay();
        SoundManager.Instance.Play();
    }

    public void VsAIGame() {
        GameData.Instance.vsAI = true;
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        SoundManager.Instance.Play();
    }

    public void BackToMain() {
        GameData.Instance.vsAI = false;
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        SoundManager.Instance.Play();
    }

    public void EasyAIGame() {
        GameData.Instance.difficulty = Difficulty.EASY;
        GameFlowManager.Instance.GamePlay();
        SoundManager.Instance.Play();
    }

    public void MediumAIGame() {
        GameData.Instance.difficulty = Difficulty.MEDIUM;
        GameFlowManager.Instance.GamePlay();
        SoundManager.Instance.Play();
    }

    public void HardAIGame() {
        GameData.Instance.difficulty = Difficulty.HARD;
        GameFlowManager.Instance.GamePlay();
        SoundManager.Instance.Play();
    }

}
