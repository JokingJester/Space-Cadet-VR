using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapObjectToPosition : Objective
{
    private bool _canSnap;
    public override void StartObjective()
    {
        _canSnap = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Power Core" && _canSnap == true)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            XRGrabInteractable interact = other.gameObject.GetComponent<XRGrabInteractable>();
            if (interact != null)
                interact.enabled = false;
            

            if (rb != null)
            {
                rb.isKinematic = true;
            }
            other.gameObject.transform.localPosition = new Vector3(0.127845f, 0.1646969f, 0.2172507f);
            other.gameObject.transform.localEulerAngles = new Vector3(0, -90, 0);
            ObjectiveComplete();
        }
    }
}
