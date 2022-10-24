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
    public GameCell[][] gameBoard;
    List<int> scoringSpaces;

    Player currentTurn;

    private const int
        MIN_SCORING_POSITION = 0,
        MAX_SCORING_POSITION = 5;

    public void StartGame() {
        ScoreManager.Instance.ResetScores();

        CellData[][] boardData = BoardData.Generate(boardConfig.boardSize);
        gameBoard = GameBoard.Generate(boardData);

        scoringSpaces = new List<int>();
        int x = Random.Range(MIN_SCORING_POSITION, MAX_SCORING_POSITION);
        int y = Random.Range(MIN_SCORING_POSITION, MAX_SCORING_POSITION);
        gameBoard[x][y].isScore = true;
        ScoreStarController.Instance.PlaceStar(x, y);
        scoringSpaces.Add(x * 10 + y);
        Debug.Log($"New Scoring Space ( {x} , {y} )");

        SetTurn(Player.FIRST);

        playerInput.enabled = true;
    }

    private void SetTurn(Player newTurn) {
        currentTurn = newTurn;
        p1Turn.SetBackgroundColor((currentTurn == Player.FIRST) ? gameConfig.Player1Color: gameConfig.InactiveTurnColor);
        p2Turn.SetBackgroundColor((currentTurn == Player.FIRST) ? gameConfig.InactiveTurnColor : gameConfig.Player2Color);
        BallController.Instance.SetPlayer(currentTurn);
        ArrowsManager.Instance.UpdatePlayer(currentTurn);
        int key = scoringSpaces[scoringSpaces.Count - 1];
        int x = key / 10; int y = key % 10;
        ArrowsManager.Instance.UpdateAvaiableArrows(x, y);
    }

    public void NextTurn() {
        if (ScoreManager.Instance.EndGame()) {
            GameFlowManager.Instance.EndGame();
            return;
        }

        int key = scoringSpaces[scoringSpaces.Count - 1];
        int x = key / 10;
        int y = key % 10;
        if (!gameBoard[x][y].isScore) {
            x = Random.Range(MIN_SCORING_POSITION, MAX_SCORING_POSITION + 1);
            y = Random.Range(MIN_SCORING_POSITION, MAX_SCORING_POSITION + 1);
            gameBoard[x][y].isScore = true;
            ScoreStarController.Instance.PlaceStar(x, y);
            scoringSpaces.Add(x * 10 + y);
            Debug.Log($"New Scoring Space ( {x} , {y} )");
        }

        Player nextTurn = currentTurn == Player.FIRST
            ? Player.SECOND
            : Player.FIRST;
        SetTurn(nextTurn);
        playerInput.enabled = true;
    }

    public void Score() {
        int key = scoringSpaces[scoringSpaces.Count - 1];
        int x = key / 10;
        int y = key % 10;
        gameBoard[x][y].isScore = false;

        ScoreManager.Instance.Score(currentTurn);
    }
}
