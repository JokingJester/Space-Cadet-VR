using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private BoxCollider _collider;
    public bool buttonPressed;
    public bool underButtonCover;
    public bool isGreen;
    private bool _canPressButton;
    [SerializeField] private MeshRenderer _renderer;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayFlashAnimation();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    public void PlayFlashAnimation()
    {
        _canPressButton = true;
        _anim.ResetTrigger("Flip");
        if (isGreen == true)
        {
            _anim.SetTrigger("Flash Green");
        }
        else
        {
            _anim.SetTrigger("Flash");
        }
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

    public void UndoButton()
    {
        _canPressButton = true;
        buttonPressed = false;
        _anim.ResetTrigger("Flip Under Cover");
        _anim.ResetTrigger("Flip");
        _anim.ResetTrigger("Flash");
        _anim.ResetTrigger("Flash Green");
        PlayFlashAnimation();
    }
}
