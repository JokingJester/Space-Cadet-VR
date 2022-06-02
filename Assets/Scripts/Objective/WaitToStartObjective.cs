using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitToStartObjective : Objective
{
    private WaitForSeconds _waitTime;
    [SerializeField] private float _seconds;
    [SerializeField] private UnityEvent _event;
    // Start is called before the first frame update

    public override void StartObjective()
    {
        if(_seconds != 0)
        {
            StartCoroutine(WaitRoutine());
        }
        else
        {
            CallUnityEvent();
        }
    }

    private void Start()
    {
        _waitTime = new WaitForSeconds(_seconds);
    }
    private IEnumerator WaitRoutine()
    {
        yield return _waitTime;
        CallUnityEvent();
    }

    private void CallUnityEvent()
    {
        if (_event != null)
        {
            _event.Invoke();
            ObjectiveComplete();
        }
    }
}
