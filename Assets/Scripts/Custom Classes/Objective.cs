using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective : MonoBehaviour
{
    public abstract void StartObjective();
    public void ObjectiveComplete()
    {
        SequenceManager.Instance.ObjectiveComplete();
    }
}
