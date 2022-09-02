using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSounds : MonoBehaviour
{
    [SerializeField] AudioClip movementStart, movement, movementEnd;
    AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayStart() {
        audioSource.PlayOneShot(movementStart);
    }

    public void PlayMovement() {
        audioSource.PlayOneShot(movement);
    }

    public void PlayEnd() {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(movementEnd);
    }
}
