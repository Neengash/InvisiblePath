using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultAI : AIDifficulty
{
    const int NO_KNOWLEDGE = -100;
    public override void AITurn() {
        // If has knowledge of scoring space && arrow isActive --> throw ball
        List<int> validArrows = GetValidArrowsFromKnowledge(GamePlayManager.Instance.GetCurrentScoringSpace());
        
        for (int i = 0; i < validArrows.Count; i++) {
            SpaceKeyHelper.GetSpaceFromKey(validArrows[i], out int x, out int y);
            if (ArrowsManager.Instance.IsActiveArrow(x, y)) {
                ArrowsManager.Instance.ClickArrow(x, y);
                return;
            }
        }

        // Else choose an arrow with hight probability
            // same row and column --> from closest to farthest if no knowledge from them.

        // Else --> Some random arrow of which it has no knowledge.

    }

    private List<int> GetValidArrowsFromKnowledge(int scoringSpace) {
        List<int> validArrows = new List<int>();
        Dictionary<int, List<int>> knowledge = AIController.Instance.knowledge;

        foreach (KeyValuePair<int, List<int>> entry in knowledge) {
            for (int i = 0; i < entry.Value.Count; i++) {
                if (entry.Value[i] == scoringSpace) {
                    validArrows.Add(entry.Key);
                }
            }
        }

        return validArrows;
    }

    private int HasKnowledge(int scoringSpace) {
        Dictionary<int, List<int>> knowledge = AIController.Instance.knowledge;
        foreach (KeyValuePair<int, List<int>> entry in knowledge) {
            for (int i = 0; i < entry.Value.Count; i++) {
                if (entry.Value[i] == scoringSpace) {
                    return entry.Key;
                }
            }
        }
        return NO_KNOWLEDGE;

    }
}
