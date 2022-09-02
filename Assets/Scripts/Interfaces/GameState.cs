using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState: MonoBehaviour
{
    public abstract void StartState();
    public abstract void EndState();
}
