using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieFighter : MonoBehaviour
{
    [SerializeField] private GameObject _greenLaser;
    [SerializeField] public GameObject destroyedXWingTimeline;
    public float health;
    public void SpawnLaser()
    {
        Instantiate(_greenLaser, transform.position, transform.rotation);
    }
}
