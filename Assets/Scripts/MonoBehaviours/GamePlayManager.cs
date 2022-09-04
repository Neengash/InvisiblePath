using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Feto;

public class GamePlayManager : Singleton<GamePlayManager>
{
    [SerializeField] public BoardScriptable boardConfig;
    [SerializeField] InputManager playerInput;
    [SerializeField] TextMeshProUGUI p1Turn, p2Turn;
    public GameCell[][] gameBoard;
    List<int> scoringSpaces;

    Player currentTurn;

    public void StartGame() {
        ScoreManager.Instance.ResetScores();

        CellData[][] boardData = BoardData.Generate(boardConfig.boardSize);
        gameBoard = GameBoard.Generate(boardData);

        scoringSpaces = new List<int>();
        int x = Random.Range(1, 4);
        int y = Random.Range(1, 4);
        gameBoard[x][y].isScore = true;
        ScoreStarController.Instance.PlaceStar(x, y);
        scoringSpaces.Add(x * 10 + y);
        Debug.Log($"New Scoring Space ( {x} , {y} )");

        SetTurn(Player.FIRST);

        playerInput.enabled = true;
    }

    private void SetTurn(Player newTurn) {
        currentTurn = newTurn;
        p1Turn.text = (currentTurn == Player.FIRST) ? "TURN" : " ";
        p2Turn.text = (currentTurn == Player.FIRST) ? " " : "TURN";
    }

    public void NextTurn() {
        if (ScoreManager.Instance.EndGame()) {
            GameFlowManager.Instance.EndGame();
            return;
        }

        // TODO: Generate New Scoring Space
        int key = scoringSpaces[scoringSpaces.Count - 1];
        int x = key / 10;
        int y = key % 10;
        if (!gameBoard[x][y].isScore) {
            x = Random.Range(1, 4);
            y = Random.Range(1, 4);
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
