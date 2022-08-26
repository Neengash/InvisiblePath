using UnityEngine;

public class Action
{
    public ActionType type;
    public Direction direction;
    public bool score;

    public Action(ActionType type, Direction direction = Direction.TOP, bool score = false) {
        this.type = type;
        this.direction = direction;
        this.score = score;
    }
}
