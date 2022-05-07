using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Audio Manager is null");
            return _instance;
        }
    }

    public AudioSource voAudioSource;
    public AudioSource sfxAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip audioClip)
    {
        voAudioSource.PlayOneShot(audioClip);
    }

    public void PlaySFX(AudioClip audioClip)
    {
        sfxAudioSource.PlayOneShot(audioClip);
    }
}
