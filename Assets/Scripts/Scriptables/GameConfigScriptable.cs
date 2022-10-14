using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePlayConfigScriptable", menuName = "ScriptableObjects/GamePlayConfig")]
public class GameConfigScriptable : ScriptableObject
{
    public Color Player1Color;
    public Color Player2Color;
    public Color InactiveTurnColor;
}
