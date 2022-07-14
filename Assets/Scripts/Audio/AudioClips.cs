using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClips : MonoBehaviour
{
    public List<AudioClip> audioClips;

    public AudioSource audioSource;

    public void PlayRandom()
    {

        audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
        audioSource.Play();
    }
}
