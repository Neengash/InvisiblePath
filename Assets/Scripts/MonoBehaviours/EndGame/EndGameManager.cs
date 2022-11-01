using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] LoadEndGameScore[] scores;
    [SerializeField] EndGameWinnerTag[] winnerTags;

    void Start() {
        for (int i = 0; i < scores.Length; i++) {
            scores[i].ReloadData();
        }
        for (int i = 0; i < winnerTags.Length; i++) {
            winnerTags[i].ReloadData();
        }
    }

    public void PlayAgain() {
        GameFlowManager.Instance.GamePlay();
    }

    public void MainMenu() {
        GameFlowManager.Instance.MainMenu();
    }
}
