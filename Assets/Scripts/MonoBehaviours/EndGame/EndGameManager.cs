using UnityEngine;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] LoadEndGameScore[] scores;
    [SerializeField] EndGameWinnerTag[] winnerTags;
    [SerializeField] TextMeshProUGUI player2Tag;

    const string PLAYER = "Player 2", AI = "AI";

    void Start() {
        player2Tag.text = GameData.Instance.vsAI ? AI : PLAYER;

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
