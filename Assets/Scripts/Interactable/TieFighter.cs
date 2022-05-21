using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TieFighter : MonoBehaviour
{
    [SerializeField] private GameObject _greenLaser;
    [SerializeField] public GameObject destroyedXWingTimeline;
    [SerializeField] private GameObject _explosion;
    public float health;
    public void SpawnLaser()
    {
        Instantiate(_greenLaser, transform.position, transform.rotation);
    }

    public void DestroyFighter()
    {
        var grab = GetComponent<XRGrabInteractable>();
        if (grab != null)
            grab.enabled = false;
        GameObject explosion = Instantiate(_explosion, transform.position, transform.rotation);
        Destroy(explosion, 4.5f);

        StartCoroutine(DestroyRoutine());
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        destroyedXWingTimeline.SetActive(true);

        yield return new WaitForSeconds(0.43f);
        Destroy(this.gameObject);
    }
}
