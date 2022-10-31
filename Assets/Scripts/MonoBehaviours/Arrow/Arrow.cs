using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int X, Y;
    public Direction direction;

    bool isActive = false;
    bool isOver = false;
    Player currentPlayer;

    MeshRenderer meshRenderer;

    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
        UpdateMateiral();
    }

    private void OnMouseOver() {
        isOver = true;
        UpdateMateiral();
    }

    private void OnMouseExit() {
        isOver = false;
        UpdateMateiral();
    }

    private void UpdateMateiral() {
        if (isActive) {
            if (isOver) {
                meshRenderer.material = currentPlayer == Player.FIRST
                    ? MaterialsManager.Instance.GetMaterial("Player1Material")
                    : MaterialsManager.Instance.GetMaterial("Player2Material");
            } else {
                meshRenderer.material = 
                    MaterialsManager.Instance.GetMaterial("NeutralMaterial");
            }
        } else {
            meshRenderer.material = 
                MaterialsManager.Instance.GetMaterial("NeutralInactiveMaterial");
        }
    }

    public void SetActiveArrow(bool isActive) {
        this.isActive = isActive;
        UpdateMateiral();
    }

    public void UpdatePlayerMaterial(Player player) {
        currentPlayer = player;
        UpdateMateiral();
    }

    public bool IsActive() {
        return isActive;
    }

    public void ArrowClicked() {
        List<Action> path = BallPath.Calculate(GamePlayManager.Instance.gameBoard, X, Y, direction, out List<int> visitedKeys);

        if (GameData.Instance.vsAI) {
            int currentArrow = X * 10 + Y;
            AIController.Instance.AddKnowledge(currentArrow, visitedKeys);
        }

        /*
        Debug.Log($"Clicked on {X} - {Y} looking {direction}");
        foreach (Action action in path) {
            Debug.Log($"Perform {action.type} towards {action.direction}");
        }
        */

        BallController.Instance.PerformActions(path, X, Y, GamePlayManager.Instance.boardConfig);
    }
}
