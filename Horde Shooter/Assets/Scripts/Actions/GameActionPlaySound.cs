using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameActionPlaySound : GameAction
{
    public AudioClip audioclip;
    public float volume;
    public AudioSource audioSource;

    // Start is called before the first frame update
    public override void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // play audio clip
    public void Play()
    {
        //play the sound linked in editor
        audioSource.PlayOneShot(audioclip, volume);
    }
}
