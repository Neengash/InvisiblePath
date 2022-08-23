using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    EMPTY,
    ALWAYS,
    MIRROR,
    HOLE,
    ROTATION,
}

public enum CellTypeDetailed
{
    EMPTY,
    ALWAYS_TOP,
    ALWAYS_RIGHT,
    ALWAYS_BOT,
    ALWAYS_LEFT,
    MIRROR_UP,
    MIRROR_DOWN,
    HOLE,
    ROTATION_CLOCK,
    ROTATION_COUTNERCLOCK,
}
public class CellData
{
    public const int
        TOP = 0,
        RIGHT = 1,
        BOT = 2,
        LEFT = 3;

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
