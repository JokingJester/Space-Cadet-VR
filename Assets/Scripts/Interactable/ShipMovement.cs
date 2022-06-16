using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Throttle throttle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.z = throttle.speed;
        //transform.Translate(direction * Time.deltaTime);
    }
}
