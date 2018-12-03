using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandle : MonoBehaviour
{
    // singleton
    private static AudioHandle instance;
    public static AudioHandle Instance {
        get { return instance; }
    }

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(this.gameObject);
        }
    }
    // variables
    public AudioClip[] audio;
    public AudioSource source;
    public AudioSource sourceClip;

    public void AudioPlay(int number, bool loop = true) {
        if(loop) {
            source.loop = loop;
            source.clip = audio[number];
            source.Play();
        } else {
            sourceClip.clip = audio[number];
            sourceClip.Play();
        }
    }
    public void AudioStop(int number) {
        source.PlayOneShot(audio[number]);
    }
}
