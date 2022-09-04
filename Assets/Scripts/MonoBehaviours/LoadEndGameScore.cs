using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadEndGameScore : MonoBehaviour
{
    [SerializeField] Player player;
    TextMeshProUGUI scoreText;

    private void Start() {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void ReloadData() {
        scoreText.text = ScoreManager.Instance.GetScore(player).ToString();
    }
}
