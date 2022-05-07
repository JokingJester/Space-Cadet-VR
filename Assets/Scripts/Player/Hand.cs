using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour
{
    [SerializeField] private ActionBasedController _controller;
    [SerializeField] private Animator _anim;

    private float _gripCurrent;
    private float _gripTarget;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _handVisual;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        _gripTarget = _controller.selectAction.action.ReadValue<float>();
        if(_gripCurrent != _gripTarget)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * _speed);
        }

        _anim.SetFloat("Flex", _gripCurrent);
    }

    public void ToggleHandVisual()
    {
        if (_handVisual.activeInHierarchy == true)
            _handVisual.SetActive(false);
        else
            _handVisual.SetActive(true);
    }
}
