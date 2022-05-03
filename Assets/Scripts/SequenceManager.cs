using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    private static SequenceManager _instance;
    public static SequenceManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Sequence Manager Is Null");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
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
