using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throttle : MonoBehaviour
{
    public HingeJoint joint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();
    }

    public void ChangeSpeed()
    {
        if (joint.angle > 0.1f && joint.angle <= 10)
            speed = 1;
        else if (joint.angle > 0.1f && joint.angle <= 15 && joint.angle < 20)
            speed = 2;
        else if (joint.angle > 0.1f && joint.angle <= 20 && joint.angle < 25)
            speed = 3;
        else if (joint.angle > 0.1f && joint.angle <= 25 && joint.angle <= 30)
            speed = 4;
        else if (joint.angle > 0.1f && joint.angle > 25)
            speed = 5;
        else if (joint.angle < -29)
            speed = 0;
    }
}
