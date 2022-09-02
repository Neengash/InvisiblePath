using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class GameData : Singleton<GameData>
{
    public bool vsAI = false;
    public Difficulty difficulty;

    public void Reset() {
        vsAI = false;
    }
}
