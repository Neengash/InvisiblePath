using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class ScoreStarController : Singleton<ScoreStarController>
{
    Animator animator;

    const string
        show = "Show",
        hide = "Hide";

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void PlaceStar(int x, int y) {
        // Coordinates look weird because in the game world
            // the X axis is positive towards the player
            // and the Z axis is positive towards the right side.
        // While in the array, positive X means right and
            // positive y means towards the player.
        BoardScriptable boardConfig = GamePlayManager.Instance.boardConfig;
        transform.position = new Vector3(
            boardConfig.offset + y * boardConfig.boardCellSize,
            transform.position.y,
            boardConfig.offset + x * boardConfig.boardCellSize
            );
        animator.SetTrigger(show);
    }

    public void HideStar() {
        animator.SetTrigger(hide);
    }

}
