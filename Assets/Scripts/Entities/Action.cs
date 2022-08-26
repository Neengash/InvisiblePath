using UnityEngine;

public class Action
{
    public ActionType type;
    public Direction direction;
    public bool score;

    public Action(ActionType type, Direction direction = Direction.NONE, bool score = false) {
        this.type = type;
        this.direction = direction;
        this.score = score;
    }
}
