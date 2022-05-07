using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButtonsArePressed : Objective
{
    [SerializeField] private List<Button> _buttons;
    private bool _canCheckIFButtonsArePressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PressedAllButtons() == true && _canCheckIFButtonsArePressed == true)
        {
            _canCheckIFButtonsArePressed = false;
            ObjectiveComplete();
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

    public override void StartObjective()
    {
        _canCheckIFButtonsArePressed = true;
    }
}
