using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenuManager;
    [SerializeField] GameObject GamePlayManager;
    [SerializeField] GameObject EndGameManager;

    private void Start() {
        MainMenuManager.SetActive(true);
        GamePlayManager.SetActive(false);
        EndGameManager.SetActive(false);
    }
}
