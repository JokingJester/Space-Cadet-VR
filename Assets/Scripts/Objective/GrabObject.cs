using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : Objective
{
    private bool _canGrab;
    public override void StartObjective()
    {
        _canGrab = true;
    }

    public void ObjectGrab()
    {
        if(_canGrab == true)
        {
            _canGrab = false;
            ObjectiveComplete();
        }
    }
}
