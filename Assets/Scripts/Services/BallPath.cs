using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPath
{
    public static void Calculate(CellData[][] board, int x, int y, Direction direction) {
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
    }
}
