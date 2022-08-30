using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class BallController : Singleton<BallController>
{
    int actionIdx;
    List<Action> path;
    BoardScriptable boardConfig;

    public void PerformActions(
        List<Action> path,
        int x,
        int y,
        BoardScriptable boardConfig
    ) {
        actionIdx = 0;
        this.path = path;
        this.boardConfig = boardConfig;

        PlaceBall(x, y);
        BallScaleTo0();

        PerformNextAction();
    }

    private void PlaceBall(int x, int y) {
        // Coordinates look weird because in the game world
            // the X axis is positive towards the player
            // and the Z axis is positive towards the right side.
        // While in the array, positive X means right and
            // positive y means towards the player.
        transform.position = new Vector3(
            boardConfig.offset + y * boardConfig.boardCellSize,
            transform.position.y,
            boardConfig.offset + x * boardConfig.boardCellSize
            );
    }

    private void BallScaleTo0() {
        transform.localScale = Vector3.zero;
    }

    private void PerformNextAction() {
        switch (path[actionIdx++].type) {
            case ActionType.SPAWN:
                break;
            case ActionType.TRANSLATE:
                break;
            case ActionType.END:
                break;
        }
    }

    private IEnumerator PerformSpawn() {
        // TODO: PENDING
        // Check for score
        // Perform Next action
        yield return null;
    }

    private IEnumerator PerformTranslate() {
        // TODO: PENDING
        // Check for score
        // Perform Next action
        yield return null;
    }

    private IEnumerator PerformEnd() {
        // TODO: PENDING
        // Check for score
        // Notify Next Turn
        yield return null;
    }
}
