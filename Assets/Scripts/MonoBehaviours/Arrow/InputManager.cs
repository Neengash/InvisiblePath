using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Arrow arrow = hit.collider.gameObject.GetComponent<Arrow>();
                if (arrow != null && arrow.IsActive()) {
                    arrow.ArrowClicked();
                    this.enabled = false;
                    ArrowsManager.Instance.DisableArrows();
                }
            }
        }
    }
}
