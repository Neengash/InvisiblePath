using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellData
{
    public CellTypeDetailed type;
    public bool[] canEnter;

    public CellData() {
        this.type = CellTypeDetailed.EMPTY;
        canEnter = new bool[4];
        for (int i = 0; i < canEnter.Length; i++) {
            canEnter[i] = true;
        }
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
