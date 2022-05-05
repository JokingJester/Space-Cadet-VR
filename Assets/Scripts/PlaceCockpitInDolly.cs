using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCockpitInDolly : MonoBehaviour
{
    [SerializeField] private GameObject _cockpit;
    private void OnEnable()
    {
        _cockpit.transform.parent = this.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
