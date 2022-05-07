using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool drankCoffee;
    [SerializeField] private AudioSource _audioSource;

    public void DrinkCoffee()
    {
        drankCoffee = true;
        _audioSource.Play();
    }
}
