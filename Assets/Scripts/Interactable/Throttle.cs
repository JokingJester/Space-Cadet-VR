
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Throttle : MonoBehaviour
{
    private bool _grabbedThrottle;

    [SerializeField] private float _disableJoystickDistance = 0.25f;
    [SerializeField] private HingeJoint joint;
    [SerializeField] private XRGrabInteractable _interact;

    [HideInInspector] public float _speed;
    [HideInInspector] public GameObject handGrabbingJoystick;

    void Update()
    {
        ChangeSpeed();
        StopJitter();
    }

    public void ChangeSpeed()
    {
        if (joint.angle > 0.1f && joint.angle <= 10)
            _speed = 3;
        else if (joint.angle > 0.1f && joint.angle <= 15 && joint.angle < 20)
            _speed = 5;
        else if (joint.angle > 0.1f && joint.angle <= 20 && joint.angle < 25)
            _speed = 8;
        else if (joint.angle > 0.1f && joint.angle <= 25 && joint.angle <= 30)
            _speed = 10;
        else if (joint.angle > 0.1f && joint.angle > 25)
            _speed = 13;
        else if (joint.angle < -29)
            _speed = 0;
    }

    private void StopJitter()
    {
        if (handGrabbingJoystick != null)
        {
            float distance = Vector3.Distance(handGrabbingJoystick.transform.position, transform.position);
            if (distance >= _disableJoystickDistance && _grabbedThrottle == true)
            {
                _interact.enabled = false;
                _interact.enabled = true;
            }
        }
    }

    public void SelectHandGrabbingJoystick(GameObject hand)
    {
        if (_grabbedThrottle == false)
            handGrabbingJoystick = hand;
    }

    public void ToggleGrab()
    {
        _grabbedThrottle = !_grabbedThrottle;
    }
}
