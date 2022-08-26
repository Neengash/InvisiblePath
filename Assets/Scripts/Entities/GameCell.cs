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
}
