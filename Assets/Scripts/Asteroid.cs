using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private bool _canMove = true;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed = 6;
    // Start is called before the first frame update


    private void FixedUpdate()
    {
        if(_canMove == true && _rb != null)
        {
            _rb.AddForce(Vector3.forward * _speed * Time.deltaTime);
            transform.Rotate(1, 0, 0 * _rotateSpeed * Time.deltaTime);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            _canMove = false;
            Debug.Log("Add Camera Shake");
        }
        //if the tag is player
        //disable force and rotate
        //add camera shake to player
    }
}
