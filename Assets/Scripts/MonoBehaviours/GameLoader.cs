using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Feto;

public class GameLoader : Singleton<GameLoader>
{
    public GameCell[][] gameBoard;
    public BoardScriptable boardConfig;

    void Start()
    {
        CellData[][] boardData = BoardData.Generate(boardConfig.boardSize);
        PrintBoard(boardData); // TMP

        gameBoard = GameBoard.Generate(boardData);
        //PrintGameBoard(gameBoard);

        ScoreManager.Instance.ResetScores();
        // Reset Score Counters
        // Assign turn to player 1
        // Load IA or Player 2 (depending on game config) - GAME PLAY MANAGER?
        // Start Game
    }

    private void PrintBoard(CellData[][] board) {
        string[] rows = new string[board.Length];
        for (int i = 0; i < board.Length; i++) {
            rows[i] = "";
        }

        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board.Length; j++) {
                rows[j] += board[i][j].type.ToString();
                rows[j] += " - ";
            }
        }

        Debug.Log("BoardData");
        for (int i = 0; i < board.Length; i++) {
            Debug.Log(rows[i]);
        }
    }
    private void PrintGameBoard(GameCell[][] board) {
        string[] rows = new string[board.Length];
        for (int i = 0; i < board.Length; i++) {
            rows[i] = "";
        }

        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board.Length; j++) {
                rows[j] += board[i][j].GetType().ToString();
                rows[j] += " - ";
            }
        }

        Debug.Log("GameBoard");
        for (int i = 0; i < board.Length; i++) {
            Debug.Log(rows[i]);
        }
    }
}
