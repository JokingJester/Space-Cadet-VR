using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    [SerializeField] private MeshRenderer _mesh;
    // Start is called before the first frame update
    void Start()
    {
        _mesh.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
