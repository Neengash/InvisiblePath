using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameCell
{
    public bool isIsolated;
    public bool isScore;

    public abstract Action EnterTop(); 
    public abstract Action EnterRight(); 
    public abstract Action EnterBot(); 
    public abstract Action EnterLeft(); 

    protected Action EndAction() {
        Action action = new Action();
        action.score = isScore;
        action.type = ActionType.END;
        return action;
    }

    protected Action TranslateAction(Direction direction) {
        Action action = new Action();
        if (isScore) { action.score = true; }
        action.type = ActionType.TRANSLATE;
        action.direction = Direction.TOP;
        return action;
    }
}
