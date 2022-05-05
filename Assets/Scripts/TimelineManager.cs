using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{

    private static TimelineManager _instance;
    public static TimelineManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Timeline Manager Is Null");
            return _instance;
        }
    }

    [SerializeField] private PlayableDirector director;
    [SerializeField] private PlayableAsset[] _sequences;
    [SerializeField] private int _index;
    [SerializeField] private int _objectiveIndex;
    [SerializeField] private float _skipTime;
    [SerializeField] private bool _completedObjective;
    [SerializeField] private bool _startNextSequence;

    private void Awake()
    {
        _instance = this;
    }


    public void LoopUntilObjectiveIsComplete()
    {
        if(_completedObjective == false)
            director.time = _skipTime;
        else
        {
            _completedObjective = false;
            if (_startNextSequence == true)
            {
                _index++;
                director.playableAsset = _sequences[_index];
                director.time = 0;
            }
            director.Play();
        }
    }

    public void ObjectiveComplete(int objectiveIndex, float skipTime, bool startNextSequence)
    {
        if(_objectiveIndex == objectiveIndex)
        {
            _objectiveIndex++;
            _startNextSequence = startNextSequence;
            _completedObjective = true;
            _skipTime = skipTime;
        }
    }

}
