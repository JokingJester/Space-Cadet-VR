using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButtonsArePressed : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private int objectiveID;
    [SerializeField] private int timeSkip;
    [SerializeField] private bool _startNextSequence;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PressedAllButtons() == true)
        {
            TimelineManager.Instance.ObjectiveComplete(objectiveID, timeSkip, _startNextSequence);
        }
    }

    public bool PressedAllButtons()
    {
        foreach (var button in _buttons)
        {
            if (button.buttonPressed == false)
            {
                return false;
            }
        }
        return true;
    }
}
