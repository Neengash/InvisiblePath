using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class PoolableRotationEffect : PoolableObject
{
    Animator animator;

    public void StartAnimation() {
        if (animator == null) { animator = GetComponent<Animator>(); }
        animator.SetTrigger("Flash");
    }

    public void EndEffect() {
        this.gameObject.SetActive(false);
    }
}
