using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private AudioSource _audioSource;
    public bool buttonPressed;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFlashAnimation()
    {
        _canPressButton = true;
        _anim.SetTrigger("Flash");
    }

    public void FlipSwitch()
    {
        if(_canPressButton == true)
        {
            buttonPressed = true;
            _anim.SetTrigger("Flip");
            _audioSource.Play();
            _canPressButton = false;
        }
    }
}
