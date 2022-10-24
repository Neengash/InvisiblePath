using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int X, Y;
    public Direction direction;

    bool isActive = true;
    Player currentPlayer;

    MeshRenderer meshRenderer;

    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnMouseOver() {
        if (isActive) {
            meshRenderer.material = currentPlayer == Player.FIRST
                ? Resources.Load<Material>("Player1Material")
                : Resources.Load<Material>("Player2Material");
        }
    }

    private void OnMouseExit() {
        if (isActive) {
            meshRenderer.material = Resources.Load<Material>("NeutralMaterial");
        }
    }

    private void UpdatePlayerMaterial(Player player) {
        currentPlayer = player;
    }

    public void ArrowClicked() {
        // Play Animation for ball
        List<Action> path = BallPath.Calculate(GamePlayManager.Instance.gameBoard, X, Y, direction);

        Debug.Log($"Clicked on {X} - {Y} looking {direction}");
        foreach (Action action in path) {
            Debug.Log($"Perform {action.type} towards {action.direction}");
        }

        // Ball - perform actions
        BallController.Instance.PerformActions(path, X, Y, GamePlayManager.Instance.boardConfig);
    }
}
