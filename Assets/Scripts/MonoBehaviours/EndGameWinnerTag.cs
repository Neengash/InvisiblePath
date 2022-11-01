using UnityEngine;
using TMPro;

public class EndGameWinnerTag : MonoBehaviour
{
    [SerializeField] Player player;

    TextMeshProUGUI winnerTag;

    const string Winner = "¡¡ WINNER !!";
    const string Loser = " ";

    void Awake() {
        winnerTag = GetComponent<TextMeshProUGUI>();
    }

    public void ReloadData() {
        winnerTag.text = ScoreManager.Instance.IsWinner(player)
            ? Winner
            : Loser;
    }
}
