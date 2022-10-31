using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class AIController : Singleton<AIController>
{
    [SerializeField] AIDifficulty easy, medium, hard;
    AIDifficulty currentAI;

    public Dictionary<int, List<int>> knowledge { get; private set; }

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

    public void AddKnowledge(int key, List<int> visited) {
        if (knowledge == null) { knowledge = new Dictionary<int, List<int>>(); }

        if (!knowledge.ContainsKey(key)) {
            knowledge.Add(key, visited);
        }

    }
}
