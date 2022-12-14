using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIActions
{
    public static List<int> GetValidArrowsFromKnowledge(int scoringSpace) {
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

    public static List<int> GetValidArrowsFromRowColumnWithoutKnowledge(int scoringSpace) {
        SpaceKeyHelper.GetSpaceFromKey(scoringSpace, out int scoreX, out int scoreY);
        Dictionary<int, List<int>> knowledge = AIController.Instance.knowledge;
        int[] sameRowColumn = {
            SpaceKeyHelper.GetKeyFromSpace(-1, scoreY),
            SpaceKeyHelper.GetKeyFromSpace(6, scoreY),
            SpaceKeyHelper.GetKeyFromSpace(scoreX, -1),
            SpaceKeyHelper.GetKeyFromSpace(scoreX, 6)
        };
        List<int> cleanList = new List<int>();

        for (int i = 0; i < sameRowColumn.Length; i++) {
            if (!knowledge.ContainsKey(sameRowColumn[i])) { 
                cleanList.Add(sameRowColumn[i]);
            }
        }

        return cleanList;
    }

    public static List<int> GetNoKnowledgeArrows() {
        Dictionary<int, List<int>> knowledge = AIController.Instance.knowledge;
        List<int> allArrows = GenerateAllArrows();

        foreach (KeyValuePair<int, List<int>> entry in knowledge) {
            allArrows.Remove(entry.Key);
        }
        Randomize(ref allArrows);

        return allArrows;
    }

    public static List<int> GenerateAllArrows() {
        List<int> allArrows = new List<int>();

        for (int i = 0; i < 6; i++) {
            allArrows.Add(SpaceKeyHelper.GetKeyFromSpace(-1, i));
            allArrows.Add(SpaceKeyHelper.GetKeyFromSpace(6, i));
            allArrows.Add(SpaceKeyHelper.GetKeyFromSpace(i, -1));
            allArrows.Add(SpaceKeyHelper.GetKeyFromSpace(i, 6));
        }

        return allArrows;
    }

    public static void Randomize(ref List<int> allArrows) {
        for (int i = 0; i < allArrows.Count-2; i++) {
            int randomIdx = Random.Range(i, allArrows.Count);
            int aux = allArrows[i];
            allArrows[i] = allArrows[randomIdx];
            allArrows[randomIdx] = aux;
        }
    }

    public static bool TryClickArrow(List<int> arrowKeys) {
        for (int i = 0; i < arrowKeys.Count; i++) {
            SpaceKeyHelper.GetSpaceFromKey(arrowKeys[i], out int x, out int y);
            if (ArrowsManager.Instance.IsActiveArrow(x, y)) {
                ArrowsManager.Instance.ClickArrow(x, y);
                return true;
            }
        }
        return false;
    }
}
