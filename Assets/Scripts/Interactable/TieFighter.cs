using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class TieFighter : MonoBehaviour
{
    private bool _playerHasPressedTrigger;
    [SerializeField] private GameObject _greenLaser;
    [SerializeField] private TMP_Text _shootText;
    [SerializeField] private Transform _cockpitTransform;

    [HideInInspector] public bool holdingTieFighter;
    public float health;
    public void SpawnLaser()
    {
        _playerHasPressedTrigger = true;
        _shootText.enabled = false;
        GameObject laser = Instantiate(_greenLaser, transform.position, transform.rotation);
        laser.transform.parent = _cockpitTransform;
    } 

    public void ToggleHoldingObject()
    {
        holdingTieFighter = !holdingTieFighter;
        if(holdingTieFighter == true && _playerHasPressedTrigger == false)
        {
            _shootText.enabled = true;
        }
    }
}
