using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Feto;

public class GamePlayManager : Singleton<GamePlayManager>
{
    [SerializeField] public BoardScriptable boardConfig;
    [SerializeField] InputManager playerInput;
    [SerializeField] PlayerTurnController p1Turn, p2Turn;
    [SerializeField] GameConfigScriptable gameConfig;
    [SerializeField] BallController ball;
    public GameCell[][] gameBoard;
    List<int> scoringSpaces;

    Player currentTurn;

    private const int
        MIN_SCORING_POSITION = 0,
        MAX_SCORING_POSITION = 5;

    private void Start() {
        BallController.Instance.BallScaleTo0();
        if (GameData.Instance.vsAI) { AIController.Instance.LoadAI(); }
        ScoreManager.Instance.ResetScores();
        CellData[][] boardData = BoardData.Generate(boardConfig.boardSize);
        gameBoard = GameBoard.Generate(boardData);
        StartGame();
    }

    public int GetCurrentScoringSpace() {
        return scoringSpaces[scoringSpaces.Count - 1];
    }

    public void PlayerInputSetEnabled(bool enable) {
        playerInput.enabled = enable;
    }

    public void StartGame() {
        scoringSpaces = new List<int>();
        int x = Random.Range(MIN_SCORING_POSITION, MAX_SCORING_POSITION);
        int y = Random.Range(MIN_SCORING_POSITION, MAX_SCORING_POSITION);
        gameBoard[x][y].isScore = true;
        ScoreStarController.Instance.PlaceStar(x, y);
        scoringSpaces.Add(SpaceKeyHelper.GetKeyFromSpace(x, y));
        SetTurn(Player.FIRST);
        playerInput.enabled = true;
    }

    private void SetTurn(Player newTurn) {
        Debug.Log("Inside SetTurn");
        currentTurn = newTurn;
        p1Turn.SetBackgroundColor((currentTurn == Player.FIRST) ? gameConfig.Player1Color: gameConfig.InactiveTurnColor);
        p2Turn.SetBackgroundColor((currentTurn == Player.FIRST) ? gameConfig.InactiveTurnColor : gameConfig.Player2Color);
        Debug.Log("Set player backgrounds");
        BallController.Instance.SetPlayer(currentTurn);
        Debug.Log("Set ball color");
        ArrowsManager.Instance.UpdatePlayer(currentTurn);
        Debug.Log("Set arrows materials");
        int key = scoringSpaces[scoringSpaces.Count - 1];
        SpaceKeyHelper.GetSpaceFromKey(key, out int x, out int y);
        Debug.Log("Called spacekeyhelper");
        ArrowsManager.Instance.UpdateAvaiableArrows(x, y);
        Debug.Log("Updated Available Arrows");
    }

    public void NextTurn() {
        if (ScoreManager.Instance.EndGame()) {
            GameFlowManager.Instance.EndGame();
            return;
        }

        int key = scoringSpaces[scoringSpaces.Count - 1];
        SpaceKeyHelper.GetSpaceFromKey(key, out int x, out int y);
        if (!gameBoard[x][y].isScore) {
            x = Random.Range(MIN_SCORING_POSITION, MAX_SCORING_POSITION + 1);
            y = Random.Range(MIN_SCORING_POSITION, MAX_SCORING_POSITION + 1);
            gameBoard[x][y].isScore = true;
            ScoreStarController.Instance.PlaceStar(x, y);
            scoringSpaces.Add(SpaceKeyHelper.GetKeyFromSpace(x, y));
        }

        Player nextTurn = currentTurn == Player.FIRST
            ? Player.SECOND
            : Player.FIRST;
        SetTurn(nextTurn);

        if (
            currentTurn == Player.FIRST ||
            !GameData.Instance.vsAI
        ) {
            playerInput.enabled = true;
        } else {
            AIController.Instance.PerformTurn();
        }
    }

    public void Score() {
        int key = scoringSpaces[scoringSpaces.Count - 1];
        SpaceKeyHelper.GetSpaceFromKey(key, out int x, out int y);
        gameBoard[x][y].isScore = false;

        ScoreManager.Instance.Score(currentTurn);
    }
}
