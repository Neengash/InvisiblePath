using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPath
{
    public static List<Action> Calculate(CellData[][] board, int x, int y, Direction direction) {
        List<Action> actions = new List<Action>();
        actions.Add(new Action(ActionType.SPAWN));
        // Advance 1 position in board
        // Check reaction in current position
        // If END --> Return
        // Else Loop

        // Save cells visited to prevent loops.

        // Path --> Array of actions
        // Starting position (scale up)
        // Translate to next position
        // ....
        // Ending position (scale down)
        //
        // Action = "ActionType" [ScaleUp/ScaleDown/Translate] + Vector3D
        return actions;
    }
}
