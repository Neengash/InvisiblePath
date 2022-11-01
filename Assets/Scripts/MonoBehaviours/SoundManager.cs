using UnityEngine;
using Feto;

public class SoundManager : SingletonPersistent<SoundManager>
{
    AudioSource audioSource;

    protected override void Awake() {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public void Play() {
        audioSource.Play(0);
    }
}
