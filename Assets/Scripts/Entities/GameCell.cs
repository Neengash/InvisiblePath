using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameCell
{
    public bool isIsolated;
    public bool isScore;

    public Action Enter(Direction direction) {
        switch (direction) {
            case Direction.TOP:
                return EnterTop();
            case Direction.RIGHT:
                return EnterRight();
            case Direction.BOT:
                return EnterBot();
            case Direction.LEFT:
                return EnterLeft();
            default:
                return null;
        }
    }

    public abstract Action EnterTop(); 
    public abstract Action EnterRight(); 
    public abstract Action EnterBot(); 
    public abstract Action EnterLeft(); 
}
