using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int X, Y;
    public Direction direction;

    public void ArrowClicked() {
        // Play Animation for ball
        List<Action> path = BallPath.Calculate(GameLoader.Instance.gameBoard, X, Y, direction);

        Debug.Log($"Clicked on {X} - {Y} looking {direction}");
        foreach (Action action in path) {
            Debug.Log($"Perform {action.type} towards {action.direction}");
        }

        // Ball - perform actions
        BallController.Instance.PerformActions(path, X, Y, GameLoader.Instance.boardConfig);
    }
}
