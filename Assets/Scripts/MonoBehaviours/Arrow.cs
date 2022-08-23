using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int X, Y;
    public Direction direction;

    public void ArrowClicked() {
        Debug.Log($"Clicked on {X} - {Y} looking {direction}");
    }
}
