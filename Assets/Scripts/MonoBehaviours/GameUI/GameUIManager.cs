using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject confirmationPopUp;

    private void OnEnable() {
        confirmationPopUp.SetActive(false);
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
