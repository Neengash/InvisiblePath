using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAI : AIDifficulty
{
    public override void AITurn() {
        if (Random.Range(0, 10) < 6) { // 60%
            if (UseKnowledge()) { return; }
        }
        RandomArrow();
    }

    private bool UseKnowledge() {
        int scoringSpace = GamePlayManager.Instance.GetCurrentScoringSpace();
        List<int> validArrows = AIActions.GetValidArrowsFromKnowledge(scoringSpace);
        return AIActions.TryClickArrow(validArrows);
    }

    private void RandomArrow() {
        List<int> allArrows = AIActions.GenerateAllArrows();
        AIActions.Randomize(ref allArrows);
        AIActions.TryClickArrow(allArrows);
    }
}
