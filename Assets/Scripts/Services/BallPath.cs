using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPath
{
    public static List<Action> Calculate(GameCell[][] board, int x, int y, Direction direction) {
        List<Action> path = new List<Action>();
        Dictionary<int, Direction[]> visited = new Dictionary<int, Direction[]>();

        path.Add(new Action(ActionType.SPAWN));
        path.Add(new Action(ActionType.TRANSLATE, direction));
        UpdatePosition(ref x, ref y, direction);

        CellAction(board, x, y, direction, ref path, ref visited);
        // Save cells visited to prevent loops.

        // Path --> Array of actions
        // Starting position (scale up)
        // Translate to next position
        // ....
        // Ending position (scale down)
        //
        // Action = "ActionType" [ScaleUp/ScaleDown/Translate] + Vector3D
        return path;
    }

    private static void UpdatePosition(ref int x, ref int y, Direction direction) {
        switch (direction) {
            case Direction.TOP:
                y--;
                break;
            case Direction.RIGHT:
                x++;
                break;
            case Direction.BOT:
                y++;
                break;
            case Direction.LEFT:
                x--;
                break;
        }
    }

    private static void CellAction(
        GameCell[][] board,
        int x, int y,
        Direction direction,
        ref List<Action> path,
        ref Dictionary<int, Direction[]> visited
    ) {
        Action action = board[x][y].Enter(Reverse(direction));
        path.Add(action);
        UpdatePosition(ref x, ref y, action.direction);

        if (action.type == ActionType.END) {
            return;
        }

        if (action.type == ActionType.TRANSLATE && (x < 0 || x >= board.Length || y < 0 || y >= board.Length)) {
            path.Add(new Action(ActionType.END));
            return;
        }

        // Check & Update visited
        int key = x * 10 + y;
        if (visited.ContainsKey(key)) {
            Direction[] directions = visited[key];
            int i = 0;
            while (i < directions.Length && directions[i] != Direction.NONE) {
                if (directions[i] == direction) {
                    path.Add(new Action(ActionType.END));
                }
                i++;
            }
            directions[i] = direction;
            visited[key] = directions;
        } else {
            Direction[] directions = new Direction[4];
            directions[0] = direction;
            visited.Add(key, directions);
        }

        // Continue
        CellAction(board, x, y, action.direction, ref path, ref visited);
    }

    private static Direction Reverse(Direction direction) {
        switch (direction) {
            case Direction.TOP: return Direction.BOT;
            case Direction.RIGHT: return Direction.LEFT;
            case Direction.BOT: return Direction.TOP;
            case Direction.LEFT: return Direction.RIGHT;
            default:  return Direction.TOP;
        }
    }
}
