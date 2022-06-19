using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class XWing : MonoBehaviour
{
    private bool _displayText = true;
    public float health;
    public TMP_Text _livesText;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject destroyedXWingTimeline;
    [SerializeField] private TieFighter _fighter;
    private WaitForSeconds _zeroPointTwo;
    private WaitForSeconds _zeroPointFourThree;

    // Start is called before the first frame update
    void Start()
    {
        _zeroPointTwo = new WaitForSeconds(0.2f);
        _zeroPointFourThree = new WaitForSeconds(0.43f);
    }

    // Update is called once per frame
    void Update()
    {
        if(_fighter.holdingTieFighter == false)
        {
            _livesText.text = "Grab TIE Fighter";
        }
        else
        {
            _livesText.text = "Health : " + health.ToString();
        }
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

    private IEnumerator DestroyRoutine()
    {
        yield return _zeroPointTwo;
        destroyedXWingTimeline.SetActive(true);

        yield return _zeroPointFourThree;
        Destroy(this.gameObject);
    }

    public void ToggleTextDisplay()
    {
        _displayText = !_displayText;
        _livesText.enabled = _displayText;
    }

    public void EnableText()
    {
        if (_displayText == true)
            _livesText.enabled = true;
    }
}
