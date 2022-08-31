using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class BallController : Singleton<BallController>
{
    int actionIdx;
    List<Action> path;
    BoardScriptable boardConfig;
    public float scaleSpeed;
    public float translateSpeed, translateError;

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

        Debug.Log("START ACTIONS");
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
        switch (path[actionIdx].type) {
            case ActionType.SPAWN:
                Debug.Log("START ACTION");
                StartCoroutine(PerformSpawn());
                break;
            case ActionType.TRANSLATE:
                Debug.Log($"TRANSLATE ACTION - {path[actionIdx].direction}");
                StartCoroutine(PerformTranslate());
                break;
            case ActionType.END:
                Debug.Log("END ACTION");
                StartCoroutine(PerformEnd());
                break;
        }
        actionIdx++;
    }

    private IEnumerator PerformSpawn() {
        Vector3 scale = transform.localScale;

        while (scale.x < 1) {
            scale = new Vector3(
                scale.x += scaleSpeed * Time.deltaTime,
                scale.y += scaleSpeed * Time.deltaTime,
                scale.z += scaleSpeed * Time.deltaTime
            );
            transform.localScale = scale;

            yield return null;
        }
        transform.localScale = Vector3.one;
        // TODO:: Check for score

        PerformNextAction();
    }

    private IEnumerator PerformTranslate() {
        GetSpeedDirections(out int xDir, out int zDir);
        Vector3 destination = transform.position + new Vector3(
            xDir * boardConfig.boardCellSize, 0, zDir * boardConfig.boardCellSize);

        while (Mathf.Abs(Vector3.Distance(transform.position, destination)) >= translateError) {
            transform.position = Vector3.MoveTowards(
                transform.position, destination, translateSpeed * Time.deltaTime);

            yield return null;
        }

        // Check for score
        PerformNextAction();
    }

    private void GetSpeedDirections(out int xDir, out int zDir) {
        Direction direction = path[actionIdx].direction;
        switch (direction) {
            case Direction.TOP:
                xDir = -1;
                zDir = 0;
                break;
            case Direction.RIGHT:
                xDir = 0;
                zDir = 1;
                break;
            case Direction.BOT:
                xDir = 1;
                zDir = 0;
                break;
            case Direction.LEFT:
                xDir = 0;
                zDir = -1;
                break;
            default:
                xDir = 0;
                zDir = 0;
                break;
        }

    }


    private IEnumerator PerformEnd() {
        Vector3 scale = transform.localScale;

        while (scale.x > 0) {
            scale = new Vector3(
                scale.x -= scaleSpeed * Time.deltaTime,
                scale.y -= scaleSpeed * Time.deltaTime,
                scale.z -= scaleSpeed * Time.deltaTime
            );
            transform.localScale = scale;

            yield return null;
        }
        transform.localScale = Vector3.zero;

        // Check for score
        // Notify Next Turn
    }
}
