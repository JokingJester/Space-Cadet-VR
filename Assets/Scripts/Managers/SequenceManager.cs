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

    public int _index;
    public int _objectiveIndex;
    public Sequence[] _allSequences;

    private void Awake()
    {
        _instance = this;
    }


    public void ObjectiveComplete()
    {
        _objectiveIndex++;
        if (_allSequences[_index].objectives.Length == _objectiveIndex)
        {
            if(_allSequences.Length != _index + 1)
            {
                _objectiveIndex = 0;
                _index++;
                StartObjective();
            }
            else
            {
                Debug.Log("END");
            }
        }
        else
        {
            StartObjective();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartObjective();
    }

    private void StartObjective()
    {
        _allSequences[_index].objectives[_objectiveIndex].StartObjective();
    }
}
