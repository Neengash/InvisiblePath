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
    public float rotationSpeed;
    MeshRenderer meshRenderer;

    BallSounds ballSounds;

    private bool alreadyScored;

    private void Start() {
        ballSounds = GetComponent<BallSounds>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public void PerformActions(
        List<Action> path,
        int x,
        int y,
        BoardScriptable boardConfig
    ) {
        alreadyScored = false;
        actionIdx = 0;
        this.path = path;
        this.boardConfig = boardConfig;

        PlaceBall(x, y);
        BallScaleTo0();

        Debug.Log("START ACTIONS");
        PerformNextAction();
    }

    public void SetPlayer(Player player) {
        if (player == Player.FIRST) {
            meshRenderer.material = MaterialsManager.Instance.GetMaterial("Player1Material");
        } else {
            meshRenderer.material = MaterialsManager.Instance.GetMaterial("Player2Material");
        }
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

    public void BallScaleTo0() {
        transform.localScale = Vector3.zero;
    }

    private void PerformNextAction() {
        switch (path[actionIdx].type) {
            case ActionType.SPAWN:
                Debug.Log("START ACTION");
                StartCoroutine(PerformSpawn());
                ballSounds.PlayStart();
                break;
            case ActionType.TRANSLATE:
                Debug.Log($"TRANSLATE ACTION - {path[actionIdx].direction}");
                StartCoroutine(PerformTranslate());
                ballSounds.PlayMovement();
                CheckRotationEffect();
                break;
            case ActionType.END:
                Debug.Log("END ACTION");
                StartCoroutine(PerformEnd());
                ballSounds.PlayEnd();
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

        PerformNextAction();
    }

    private IEnumerator PerformTranslate() {
        GetSpeedDirections(out int xPosDir, out int zPosDir, out int xRotDir, out int zRotDir);
        Vector3 destination = transform.position + new Vector3(
            xPosDir * boardConfig.boardCellSize, 0, zPosDir * boardConfig.boardCellSize);

        while (Mathf.Abs(Vector3.Distance(transform.position, destination)) >= translateError) {
            transform.position = Vector3.MoveTowards(
                transform.position, destination, translateSpeed * Time.deltaTime);
            transform.Rotate(
                xRotDir * rotationSpeed * Time.deltaTime,
                0,
                zRotDir * rotationSpeed * Time.deltaTime,
                Space.World
            ); 
            yield return null;
        }

        if (path[actionIdx].score && !alreadyScored) {
            GamePlayManager.Instance.Score();
            alreadyScored = true;
        }

        PerformNextAction();
    }

    private void GetSpeedDirections(out int xPosDir, out int zPosDir, out int xRotDir, out int zRotDir) {
        Direction direction = path[actionIdx].direction;
        switch (direction) {
            case Direction.TOP:
                xPosDir = -1; zPosDir = 0;
                xRotDir = 0; zRotDir = 1;
                break;
            case Direction.RIGHT:
                xPosDir = 0; zPosDir = 1;
                xRotDir = 1; zRotDir = 0;
                break;
            case Direction.BOT:
                xPosDir = 1; zPosDir = 0;
                xRotDir = 0; zRotDir = -1;
                break;
            case Direction.LEFT:
                xPosDir = 0; zPosDir = -1;
                xRotDir = -1; zRotDir = 0;
                break;
            default:
                xPosDir = 0; zPosDir = 0;
                xRotDir = 0; zRotDir = 0;
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

        GamePlayManager.Instance.NextTurn();
    }

    private void CheckRotationEffect() {
        Direction currentDirection = path[actionIdx].direction;
        Direction previousDirection = GetPreviousDirection();

        if (previousDirection == currentDirection) { return; }
        if (previousDirection == Direction.NONE) { return; }

        if (IsClockWiseRotation(currentDirection, previousDirection)) {
            EffectsManager.Instance.PlayRotationEffect(transform.position);
        } else {
            EffectsManager.Instance.PlayCounterRotationEffect(transform.position);
        }
    }

    private Direction GetPreviousDirection() {
        int i = actionIdx -1 ;
        while (i >= 0) {
            if (path[i].type == ActionType.TRANSLATE) {
                return path[i].direction;
            }
            i--;
        }
        return Direction.NONE;
    }

    private bool IsClockWiseRotation(Direction current, Direction previous) {
        return
            (previous == Direction.TOP && current == Direction.RIGHT) ||
            (previous == Direction.RIGHT && current == Direction.BOT) ||
            (previous == Direction.BOT && current == Direction.LEFT) ||
            (previous == Direction.LEFT && current == Direction.TOP);
    }
}
