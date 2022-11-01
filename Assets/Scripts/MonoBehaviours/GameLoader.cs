using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Feto;

public class GameLoader : MonoBehaviour
{
    public GameCell[][] gameBoard;
    public BoardScriptable boardConfig;

    public GameCell[][] GenerateGameBoard(BoardScriptable boardConfig) 
    {
        CellData[][] boardData = BoardData.Generate(boardConfig.boardSize);
        gameBoard = GameBoard.Generate(boardData);

        return gameBoard;
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
