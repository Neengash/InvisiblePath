using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject confirmationPopUp;
    [SerializeField] TextMeshProUGUI Player2Tag;

    const string PLAYER = "P2", AI = "AI";

    private void Start() {
        confirmationPopUp.SetActive(false);
        Player2Tag.text = GameData.Instance.vsAI ? AI : PLAYER;
    }

    public void HomeButton() {
        confirmationPopUp.SetActive(true);
        Time.timeScale = 0;
        GamePlayManager.Instance.PlayerInputSetEnabled(false);
    }

    public void CancelOption() {
        confirmationPopUp.SetActive(false);
        Time.timeScale = 1;
        GamePlayManager.Instance.PlayerInputSetEnabled(true);
    }

    public void ExitOption() {
        Time.timeScale = 1;
        GamePlayManager.Instance.PlayerInputSetEnabled(true);
        GameFlowManager.Instance.MainMenu();
    }
}
