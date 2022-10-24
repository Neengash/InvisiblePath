using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsManager : MonoBehaviour
{
    Arrow[] arrows;

    private void Start() {
        arrows = GetComponentsInChildren<Arrow>();
    }

    public void UpdatePlayer(Player player) {
        for (int i = 0; i < arrows.Length; i++) {
        }
    }
}
