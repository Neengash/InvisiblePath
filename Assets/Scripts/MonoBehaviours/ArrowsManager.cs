using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class ArrowsManager : Singleton<ArrowsManager>
{
    Arrow[] arrows;

    private const int MAX_DISTANCE = 12;
    private List<Arrow> closest;

    private void Start() {
        arrows = GetComponentsInChildren<Arrow>();
        closest = new List<Arrow>();
    }

    public void UpdatePlayer(Player player) {
        for (int i = 0; i < arrows.Length; i++) {
            arrows[i].UpdatePlayerMaterial(player);
        }
    }

    public void UpdateAvaiableArrows(int x, int y) {
        closest.Clear();
        int distance = MAX_DISTANCE;
        int newDistance;

        for (int i = 0; i < arrows.Length; i++) {
            newDistance = GetDistance(arrows[i].X, arrows[i].Y, x, y);

            if (newDistance == distance) {
                AddArrowToClosest(arrows[i]);
            } else if (newDistance < distance) {
                for (int j = 0; j < closest.Count; j++) {
                    closest[j].SetActiveArrow(true);
                }
                closest.Clear();
                AddArrowToClosest(arrows[i]);
                distance = newDistance;
            } else {
                arrows[i].SetActiveArrow(true);
            }
        }
    }

    private int GetDistance(int originX, int originY, int destinyX, int destinyY) {
        return Mathf.Abs(originX - destinyX) + Mathf.Abs(originY - destinyY);
    }

    private void AddArrowToClosest(Arrow arrow) {
        closest.Add(arrow);
        arrow.SetActiveArrow(false);
    }
}
