using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrinkCoffee : Objective
{
    private bool _checkIfPlayerDrankCoffee;
    [SerializeField] private Player _player;
    public override void StartObjective()
    {
        _checkIfPlayerDrankCoffee = true;
    }

    private void Update()
    {
        if(_checkIfPlayerDrankCoffee == true)
        {
            if(_player.drankCoffee == true)
            {
                _checkIfPlayerDrankCoffee = false;
                ObjectiveComplete();
            }
        }
    }
}
