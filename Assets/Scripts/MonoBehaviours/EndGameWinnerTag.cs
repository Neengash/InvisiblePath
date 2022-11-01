using UnityEngine;
using TMPro;

public class EndGameWinnerTag : MonoBehaviour
{
    [SerializeField] Player player;

    TextMeshProUGUI winnerTag;

    const string Winner = "¡¡ WINNER !!";
    const string Loser = " ";

    void Start() {
        winnerTag = GetComponent<TextMeshProUGUI>();
    }

    public void ReloadData() {
        if (winnerTag == null) {
            winnerTag = GetComponent<TextMeshProUGUI>();
        }
        winnerTag.text = ScoreManager.Instance.IsWinner(player)
            ? Winner
            : Loser;
    }
}
