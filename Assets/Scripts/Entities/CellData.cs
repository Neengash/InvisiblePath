using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellData
{
    public CellTypeDetailed type;
    public Dictionary<Direction, bool> canEnter;

    public CellData() {
        this.type = CellTypeDetailed.EMPTY;
        canEnter = new Dictionary<Direction, bool>();

        canEnter.Add(Direction.TOP, true);
        canEnter.Add(Direction.RIGHT, true);
        canEnter.Add(Direction.BOT, true);
        canEnter.Add(Direction.LEFT, true);
    }

    public CellType GetCellType() {
        switch (type) {
            case CellTypeDetailed.EMPTY:
                return CellType.EMPTY;
            case CellTypeDetailed.ALWAYS_TOP:
            case CellTypeDetailed.ALWAYS_RIGHT:
            case CellTypeDetailed.ALWAYS_BOT:
            case CellTypeDetailed.ALWAYS_LEFT:
                return CellType.ALWAYS;
            case CellTypeDetailed.MIRROR_UP:
            case CellTypeDetailed.MIRROR_DOWN:
                return CellType.MIRROR;
            case CellTypeDetailed.HOLE:
                return CellType.HOLE;
            case CellTypeDetailed.ROTATION_CLOCK:
            case CellTypeDetailed.ROTATION_COUTNERCLOCK:
                return CellType.ROTATION;
            default:
                return CellType.EMPTY;
        }
    }
}
