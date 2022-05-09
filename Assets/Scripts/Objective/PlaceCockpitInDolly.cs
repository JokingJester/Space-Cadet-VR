using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCockpitInDolly : Objective
{
    [SerializeField] private GameObject _cockpit;
    [SerializeField] private GameObject _dollyCart;

    public override void StartObjective()
    {
        this.gameObject.SetActive(true);
        _cockpit.transform.parent = _dollyCart.transform;
        _cockpit.transform.localPosition = Vector3.zero;
        ObjectiveComplete();
    }
}
