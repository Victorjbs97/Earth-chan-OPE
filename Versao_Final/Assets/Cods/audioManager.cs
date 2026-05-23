using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayAudio(AudioClip clip, float volu) 
    {
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.volume = volu;
        
    }

    public void PlayAudioAtPoint(Vector2 audioPosition, AudioClip clip) 
    {
        Vector2 newAudioPos = new Vector2(audioPosition.x, audioPosition.y);
        AudioSource.PlayClipAtPoint(clip,newAudioPos);
    }
}
