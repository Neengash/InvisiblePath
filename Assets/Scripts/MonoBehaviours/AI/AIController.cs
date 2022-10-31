using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class AIController : Singleton<AIController>
{
    [SerializeField] AIDifficulty easy, medium, hard;
    AIDifficulty currentAI;

    // Learned Path Information Variable

    public void LoadAI() {
        switch (GameData.Instance.difficulty) {
            case Difficulty.EASY:
                currentAI = easy;
                break;
            case Difficulty.MEDIUM:
                currentAI = medium;
                break;
            case Difficulty.HARD:
                currentAI = hard;
                break;
            default:
                currentAI = easy;
                break;
        }
    }

    public void PerformTurn() {
        currentAI.AITurn();
    }
}
