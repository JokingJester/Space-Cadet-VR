using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    private bool _fingerIsPointing;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _fingerIsPointing == false)
        {
            Hand hand = other.GetComponent<Hand>();
            if(hand != null)
            {
                //NEw Issue: Can't point two fingers at same time
                _fingerIsPointing = true;
                hand.CanPointFinger();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && _fingerIsPointing == true)
        {
            Hand hand = other.GetComponent<Hand>();
            if (hand != null)
            {
                _fingerIsPointing = false;
                _boxCollider.enabled = false;
                hand.StopPoitingFinger();
                _boxCollider.enabled = true;
            }
        }
    }
}
