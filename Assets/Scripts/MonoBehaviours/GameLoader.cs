using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    void Start()
    {
        CellData[][] board = Board.Generate();
        PrintBoard(board);
        // Create Board
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
            }
        }

        for (int i = 0; i < board.Length; i++) {
            Debug.Log(rows[i]);
        }
    }
}
