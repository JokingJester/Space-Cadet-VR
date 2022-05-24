using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class TieFighter : MonoBehaviour
{
    [SerializeField] private GameObject _greenLaser;
    [SerializeField] public GameObject destroyedXWingTimeline;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private Transform _cockpitTransform;
    public float health;
    public void SpawnLaser()
    {
        GameObject laser = Instantiate(_greenLaser, transform.position, transform.rotation);
        laser.transform.parent = _cockpitTransform;
    }

    public void DestroyFighter()
    {
        var grab = GetComponent<XRGrabInteractable>();
        if (grab != null)
            grab.enabled = false;
        GameObject explosion = Instantiate(_explosion, transform.position, transform.rotation);
        explosion.transform.parent = GameObject.Find("Cockpit").transform;
        Destroy(explosion, 4.5f);

        StartCoroutine(DestroyRoutine());
    }

    public void Damage()
    {
        health--;
        _livesText.text = health.ToString();
        if (health <= 0)
        {
            DestroyFighter();
        }
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        destroyedXWingTimeline.SetActive(true);

        yield return new WaitForSeconds(0.43f);
        Destroy(this.gameObject);
    }
}
