using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private AudioSource _audioSource;

    public bool buttonPressed;
    public bool underButtonCover;
    private bool _canPressButton;

    private void OnEnable()
    {
        PlayFlashAnimation();
    }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        this.enabled = false;
    }

    public void PlayFlashAnimation()
    {
        _canPressButton = true;
        _anim.ResetTrigger("Flip");
        _anim.SetTrigger("Flash");
    }

    public void FlipSwitch()
    {
        if (_canPressButton == true && underButtonCover == false)
        {
            _canPressButton = false;
            buttonPressed = true;
            _anim.ResetTrigger("Flash");
            _anim.SetTrigger("Flip");
            _audioSource.Play();
        }
        
        if(_canPressButton == true && underButtonCover == true)
        {
            _canPressButton = false;
            buttonPressed = true;
            _anim.ResetTrigger("Flash");
            _anim.SetTrigger("Flip Under Cover");
            _audioSource.Play();
        }
    }
}
