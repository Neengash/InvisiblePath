using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardData
{
    public const int BOARD_SIZE = 6;
    public static CellData[][] Generate() {
        CellData[][] board = GenerateEmptyBoard();
        PopulateBoard(ref board);
        return board;
    }

    private static CellData[][] GenerateEmptyBoard() {
        CellData[][] board = new CellData[BOARD_SIZE][];
        for (int i = 0; i < board.Length; i++) {
            board[i] = new CellData[BOARD_SIZE];
            for (int j = 0; j < board[i].Length; j++) {
                board[i][j] = new CellData();
            }
        }
        return board;
    }

    private static void PopulateBoard(ref CellData[][] board) {
        PopulateRows(ref board);
        PopulateColumns(ref board);
    }

    private static void PopulateRows(ref CellData[][] board) {
        for (int j = 0; j < board.Length; j++) {
            int column = Random.Range(0, BOARD_SIZE);
            PopulateCell(ref board, column, j);
        }
    }

    private static void PopulateColumns(ref CellData[][] board) {
        for (int i = 0; i < board.Length; i++) {
            int row = Random.Range(0, BOARD_SIZE);
            PopulateCell(ref board, i, row);
        }
    }

    private static void PopulateCell(ref CellData[][] board, int i, int j) {
            if (board[i][j].GetCellType() == CellType.EMPTY) {
                CellType type = RandomCellType();
                CellTypeDetailed typedetailed = RandomDetailedType(type);
                board[i][j].type = typedetailed;
                UpdateNearCells(ref board, i, j, typedetailed);
            }
    }

    private static CellType RandomCellType() {
        return (CellType)Random.Range(1, 5);
    }

    private static CellTypeDetailed RandomDetailedType(CellType type) {
        switch (type) {
            case CellType.ALWAYS:
                return (CellTypeDetailed)Random.Range(1, 5);
            case CellType.MIRROR:
                return (Random.Range(0, 2) == 0)
                    ? CellTypeDetailed.MIRROR_UP
                    : CellTypeDetailed.MIRROR_DOWN;
            case CellType.HOLE:
                return CellTypeDetailed.HOLE;
            case CellType.ROTATION:
                return (Random.Range(0, 2) == 0)
                    ? CellTypeDetailed.ROTATION_CLOCK
                    : CellTypeDetailed.ROTATION_COUTNERCLOCK;
            default:
                return CellTypeDetailed.EMPTY;
        }

    }

    private static void UpdateNearCells(ref CellData[][] board, int i, int j, CellTypeDetailed type) {
        switch (type) {
            case CellTypeDetailed.ALWAYS_TOP:
                SetRightToFalse(ref board, i, j);
                SetBotToFalse(ref board, i, j);
                SetLeftToFalse(ref board, i, j);
                break;
                // right bot and left to false
            case CellTypeDetailed.ALWAYS_RIGHT:
                SetTopToFalse(ref board, i, j);
                SetBotToFalse(ref board, i, j);
                SetLeftToFalse(ref board, i, j);
                break;
                // top, bot, left to false
            case CellTypeDetailed.ALWAYS_BOT:
                SetTopToFalse(ref board, i, j);
                SetRightToFalse(ref board, i, j);
                SetLeftToFalse(ref board, i, j);
                break;
                // top, right, left to false
            case CellTypeDetailed.ALWAYS_LEFT:
                SetTopToFalse(ref board, i, j);
                SetRightToFalse(ref board, i, j);
                SetBotToFalse(ref board, i, j);
                break;
                // top, right, bot to false
            case CellTypeDetailed.MIRROR_UP:
                if (!board[i][j].canEnter[Direction.LEFT]) { SetTopToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.TOP]) { SetLeftToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.BOT]) { SetRightToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.RIGHT]) { SetBotToFalse(ref board, i, j); }
                break;
                // top to false if current left is false
                // left to false if current top is false
                // right to false if current bot is false
                // bot to false if current right is false
            case CellTypeDetailed.MIRROR_DOWN:
                if (!board[i][j].canEnter[Direction.RIGHT]) { SetTopToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.TOP]) { SetRightToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.BOT]) { SetLeftToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.LEFT]) { SetBotToFalse(ref board, i, j); }
                break;
                // top to false if current right is false
                // right to false if current top if false
                // bot to false if current left is false
                // left to false if current bot is false
            case CellTypeDetailed.HOLE:
                SetTopToFalse(ref board, i, j);
                SetRightToFalse(ref board, i, j);
                SetBotToFalse(ref board, i, j);
                SetLeftToFalse(ref board, i, j);
                break;
                // All to false
            case CellTypeDetailed.ROTATION_CLOCK:
                if (!board[i][j].canEnter[Direction.TOP]) { SetLeftToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.RIGHT]) { SetTopToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.BOT]) { SetRightToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.LEFT]) { SetBotToFalse(ref board, i, j); }
                break;
                // X to false if previous (clock) is false
            case CellTypeDetailed.ROTATION_COUTNERCLOCK:
                // X to false if next (clock) is false
                if (!board[i][j].canEnter[Direction.BOT]) { SetLeftToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.LEFT]) { SetTopToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.TOP]) { SetRightToFalse(ref board, i, j); }
                if (!board[i][j].canEnter[Direction.RIGHT]) { SetBotToFalse(ref board, i, j); }
                break;
        }
    }

    private static void SetTopToFalse(ref CellData[][] board, int i, int j) {
        SetToFalse(ref board, i, j - 1, Direction.BOT);
    }

    private static void SetRightToFalse(ref CellData[][] board, int i, int j) {
        SetToFalse(ref board, i + 1, j, Direction.LEFT);
    }

    private static void SetBotToFalse(ref CellData[][] board, int i, int j) {
        SetToFalse(ref board, i, j + 1, Direction.TOP);
    }

    private static void SetLeftToFalse(ref CellData[][] board, int i, int j) {
        SetToFalse(ref board, i - 1, j, Direction.RIGHT);
    }

    private static void SetToFalse(ref CellData[][] board, int i, int j, Direction direction) {
        if (i < 0 || i >= BOARD_SIZE || j < 0 || j >= BOARD_SIZE) {
            return;
        }
        board[i][j].canEnter[direction] = false;
    }   
}
