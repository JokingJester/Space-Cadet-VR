using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour
{
    [SerializeField] private ActionBasedController _controller;
    [SerializeField] private Animator _anim;

   [SerializeField] private bool _canPointFinger;

    private float _gripCurrent;
    private float _triggerCurrent;
    private float _gripTarget;
    private float _triggerTarget;
    [SerializeField] private float _speed;

    [SerializeField] private SphereCollider _regularCollider;

    [SerializeField] private Vector2 _fingerColliderCenter;
    [SerializeField] private XRDirectInteractor _directInteractor;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        _gripTarget = _controller.selectAction.action.ReadValue<float>();
        _triggerTarget = _controller.activateAction.action.ReadValue<float>();
        if(_gripCurrent != _gripTarget)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * _speed);
        }

        if (_triggerCurrent != _triggerTarget)
        {
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * _speed);
        }

        _anim.SetFloat("Flex", _gripCurrent);
        _anim.SetFloat("Pinch", _triggerCurrent);
    }

    public void CanPointFinger()
    {
        if (_canPointFinger == true)
            return;
        _canPointFinger = true;
        _anim.SetBool("Near Button", _canPointFinger);

        var center = _regularCollider.center;
        center.x = _fingerColliderCenter.x;
        center.z = _fingerColliderCenter.y;
        _regularCollider.center = center;
        _regularCollider.radius = 0.01f;
    }

    public void StopPoitingFinger()
    {
        if (_canPointFinger == false)
            return;
        _canPointFinger = false;
        _anim.SetBool("Near Button", _canPointFinger);

        var center = _regularCollider.center;
        center.x = 0f;
        center.z = 0f;
        _regularCollider.center = center;
        _regularCollider.radius = 0.05f;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button")
        {
            _directInteractor.SendHapticImpulse(0.1f, 0.2f);
        }
    }
}
