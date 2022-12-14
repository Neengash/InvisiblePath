using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class ArrowsManager : Singleton<ArrowsManager>
{
    Arrow[] arrows;

    private const int MAX_DISTANCE = 12;
    private List<Arrow> closest;

    protected override void Awake() {
        base.Awake();
        arrows = GetComponentsInChildren<Arrow>();
        closest = new List<Arrow>();
    }

    public bool IsActiveArrow(int x, int y) {
        for (int i = 0; i < arrows.Length; i++) {
            if (arrows[i].X == x && arrows[i].Y == y) {
                return arrows[i].IsActive();
            }
        }
        return false;
    }

    public void ClickArrow(int x, int y) {
        for (int i = 0; i < arrows.Length; i++) {
            if (arrows[i].X == x && arrows[i].Y == y) {
                arrows[i].ArrowClicked();
                return ;
            }
        }
        Debug.LogError($"ArrowsManagers: ClickArrow - No arrow was found with coordinates {x}-{y}");
    }

    public void UpdatePlayer(Player player) {
        for (int i = 0; i < arrows.Length; i++) {
            arrows[i].UpdatePlayerMaterial(player);
        }
    }

    public void DisableArrows() {
        for (int i = 0; i < arrows.Length; i++) {
            arrows[i].SetActiveArrow(false);
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
