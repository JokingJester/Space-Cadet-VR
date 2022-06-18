
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlightStick : MonoBehaviour
{
    private bool _grabbedJoystick;

    [SerializeField] private ConfigurableJoint _joint;

    [SerializeField] private float _leftRotateSpeed;
    [SerializeField] private float _rightRotateSpeed;
    [SerializeField] private float _upRotateSpeed;
    [SerializeField] private float _downRotateSpeed;
    [SerializeField] private float _disableJoystickDistance;

    [SerializeField] private GameObject _rightArrow;
    [SerializeField] private GameObject _leftArrow;
    [SerializeField] private GameObject _regularScreen;

    [SerializeField] private XRGrabInteractable _interact;

    [HideInInspector] public float rotateSpeed;
    [HideInInspector] public float verticalRotateSpeed;
    public GameObject handGrabbingJoystick;
    // Update is called once per frame
    void Update()
    {
        JoystickMovement();
        StopJitter();
    }

    private void JoystickMovement()
    {
        var eulerAngles = transform.localEulerAngles;

        #region Horizontal Movement
        if (eulerAngles.z > 340 && eulerAngles.z < 359 && eulerAngles.x < 359)
        {
            rotateSpeed = _leftRotateSpeed;
            _regularScreen.SetActive(false);
            _leftArrow.SetActive(false);
            _rightArrow.SetActive(true);
        }
        else if (eulerAngles.z < 21 && eulerAngles.x > 343 && eulerAngles.y > 3)
        {
            rotateSpeed = _rightRotateSpeed;
            _regularScreen.SetActive(false);
            _leftArrow.SetActive(true);
            _rightArrow.SetActive(false);
        }
        else if (eulerAngles.z == 0)
        {
            rotateSpeed = 0;
            _regularScreen.SetActive(true);
            _leftArrow.SetActive(false);
            _rightArrow.SetActive(false);
        }
        else
        {
            rotateSpeed = 0;
            _regularScreen.SetActive(true);
            _leftArrow.SetActive(false);
            _rightArrow.SetActive(false);
        }
        #endregion

        #region Vertical Movement
        if (eulerAngles.x > 9 && eulerAngles.z > 1 && eulerAngles.z > 350)
        {
            verticalRotateSpeed = _downRotateSpeed;
        }
        else if (eulerAngles.x > 14 && eulerAngles.x < 358 && eulerAngles.z < 6.4)
        {
            verticalRotateSpeed = _upRotateSpeed;
        }
        else if (eulerAngles.x == 0)
            verticalRotateSpeed = 0;
        else
            verticalRotateSpeed = 0;
        #endregion
    }

    private void StopJitter()
    {
        if(handGrabbingJoystick != null)
        {
            float distance = Vector3.Distance(handGrabbingJoystick.transform.position, transform.position);
            if (distance >= _disableJoystickDistance && _grabbedJoystick == true)
            {
                _interact.enabled = false;
                _interact.enabled = true;
            }
        }
    }

    public void SelectHandGrabbingJoystick(GameObject hand)
    {
        if (_grabbedJoystick == false)
            handGrabbingJoystick = hand;
    }

    public void ToggleGrab()
    {
        _grabbedJoystick = !_grabbedJoystick;
    }
}
