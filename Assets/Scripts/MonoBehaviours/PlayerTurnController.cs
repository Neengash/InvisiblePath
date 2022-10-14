using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnController : MonoBehaviour
{
    Image turnBackground;

    private void Awake() {
        turnBackground = GetComponent<Image>();
    }

    public void SetBackgroundColor(Color color) {
        turnBackground.color = color;
    }
}
