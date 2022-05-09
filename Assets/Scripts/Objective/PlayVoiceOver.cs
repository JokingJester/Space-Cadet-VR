using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoiceOver : Objective
{
    [SerializeField] private AudioClip _audioClip;
    // Start is called before the first frame update

    public override void StartObjective()
    {
        ObjectiveComplete();
        AudioManager.Instance.PlayVoiceOver(_audioClip);
    }
}
