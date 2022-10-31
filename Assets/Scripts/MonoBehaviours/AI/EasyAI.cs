using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyAI : AIDifficulty
{
    public override void AITurn() {

        List<int> allArrows = AIActions.GenerateAllArrows();
        AIActions.Randomize(ref allArrows);
        AIActions.TryClickArrow(allArrows);
    }
}
