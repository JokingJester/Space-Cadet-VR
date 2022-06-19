
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Throttle throttle;
    public FlightStick flightStick;
    private float _currentSpeed;
    private float _currentRotateSpeed;
    private float _currentVerticalRotateSpeed;
    public float _speed;
    public float _rotateSpeed;
    public float _verticalRotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentSpeed != throttle._speed)
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, throttle._speed, Time.deltaTime * _speed);
        Vector3 direction = Vector3.zero;
        direction.z = 1;

        if (_currentRotateSpeed != flightStick.rotateSpeed)
            _currentRotateSpeed = Mathf.MoveTowards(_currentRotateSpeed, flightStick.rotateSpeed, Time.deltaTime * _rotateSpeed);

        if (_currentVerticalRotateSpeed != flightStick.verticalRotateSpeed)
            _currentVerticalRotateSpeed = Mathf.MoveTowards(_currentVerticalRotateSpeed, flightStick.verticalRotateSpeed, Time.deltaTime * _verticalRotateSpeed);
        transform.Translate(direction * _currentSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(_currentVerticalRotateSpeed, _currentRotateSpeed, 0) * Time.deltaTime);
    }
}
