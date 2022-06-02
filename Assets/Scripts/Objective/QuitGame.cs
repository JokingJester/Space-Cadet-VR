using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : Objective
{
    public override void StartObjective()
    {
        Application.Quit();
    }
}
