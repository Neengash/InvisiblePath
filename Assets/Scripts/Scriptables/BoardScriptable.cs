using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardScriptable", menuName = "ScriptableObjects/BoardScriptable")]
public class BoardScriptable : ScriptableObject
{
    public int boardSize;
    public float boardCellSize;
}
