using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyAI : AIDifficulty
{
    public override void AITurn() {
        int x = 0, y = 0;
        int iterations = 0;
        do {
            ChooseArrowCoordinates(ref x, ref y);
        } while ( !ArrowsManager.Instance.IsActiveArrow(x, y) && iterations++ < 10);

        ArrowsManager.Instance.ClickArrow(x, y);
    }

    private void ChooseArrowCoordinates(ref int x, ref int y) {
        Direction side = (Direction)Random.Range(1, 5); // 0/1/2/3 => TOP/RIGHT/BOT/LEFT
        int arrow = Random.Range(0, 6);

        if (side == Direction.TOP) {
            y = -1;
            x = arrow;
        } else if (side == Direction.RIGHT) {
            x = 6;
            y = arrow;
        } else if (side == Direction.BOT) {
            y = 6;
            x = arrow;
        } else { // Direction.Left
            x = -1;
            y = arrow;
        }
    }
}
