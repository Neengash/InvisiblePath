using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultAI : AIDifficulty
{
    public override void AITurn() {
        int scoringSpace = GamePlayManager.Instance.GetCurrentScoringSpace();

        List<int> validArrows = AIActions.GetValidArrowsFromKnowledge(scoringSpace);
        if (AIActions.TryClickArrow(validArrows)) { return; }

        List<int> RowColumnArrows = AIActions.GetValidArrowsFromRowColumnWithoutKnowledge(scoringSpace);
        if (AIActions.TryClickArrow(RowColumnArrows)) { return; }

        List<int> otherArrows = AIActions.GetNoKnowledgeArrows();
        AIActions.TryClickArrow(otherArrows);
    }

}
