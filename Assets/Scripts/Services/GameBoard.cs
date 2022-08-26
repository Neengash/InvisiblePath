using System.Collections;
using System.Collections.Generic;

public class GameBoard 
{
    public static GameCell[][] Generate(CellData[][] boardData) {
        GameCell[][] gameBoard = new GameCell[boardData.Length][];
        for (int i = 0; i < boardData.Length; i++) {
            gameBoard[i] = new GameCell[boardData[i].Length];
            for (int j = 0; j < boardData.Length; j++) {
                gameBoard[i][j] = GenerateGameCell(boardData[i][j]);
            }
        }
        return gameBoard;
    }

    private static GameCell GenerateGameCell(CellData cellData) {
        GameCell cell;
        switch (cellData.type) {
            case CellTypeDetailed.EMPTY:
                cell = new EmptyCell();
                break;
            case CellTypeDetailed.HOLE:
                cell = new HoleCell();
                break;
            case CellTypeDetailed.ALWAYS_TOP:
                cell = new AlwaysTopCell();
                break;
            case CellTypeDetailed.ALWAYS_RIGHT:
                cell = new AlwaysRightCell();
                break;
            case CellTypeDetailed.ALWAYS_BOT:
                cell = new AlwaysBotCell();
                break;
            case CellTypeDetailed.ALWAYS_LEFT:
                cell = new AlwaysLeftCell();
                break;
            case CellTypeDetailed.MIRROR_UP:
                cell = new MirrorUpCell();
                break;
            case CellTypeDetailed.MIRROR_DOWN:
                cell = new MirrorDownCell();
                break;
            case CellTypeDetailed.ROTATION_CLOCK:
                cell = new RotateClockCell();
                break;
            case CellTypeDetailed.ROTATION_COUTNERCLOCK:
                cell = new RotateCounterClockCell();
                break;
            default:
                cell = new EmptyCell();
                break;
        }

        if (
            !cellData.canEnter[Direction.TOP] &&
            !cellData.canEnter[Direction.RIGHT] &&
            !cellData.canEnter[Direction.BOT] &&
            !cellData.canEnter[Direction.LEFT]
        ) {
            cell.isIsolated = true;
        }

        return cell;
    }
}
