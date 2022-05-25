using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    private bool _inRegularPos = true;
    private WaitForSeconds _twoPointSix;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private GameObject _blackOverlay;
    [SerializeField] private GameObject _xrOrigin;
    [SerializeField] private GameObject _chair;
    [SerializeField] private GameObject _selectHand;

    [SerializeField] private SkinnedMeshRenderer _handVisual;
   
    public bool drankCoffee;
    public bool canTeleport;

    private void Start()
    {
        _twoPointSix = new WaitForSeconds(2.6f);
    }

    public void DrinkCoffee()
    {
        drankCoffee = true;
        _audioSource.Play();
    }

    public void ToggleTeleport()
    {
        if(canTeleport == true)
        {
            _blackOverlay.SetActive(true);
            StartCoroutine(TeleportRoutine());
        }
    }

    private IEnumerator TeleportRoutine()
    {
        canTeleport = false;
        yield return _twoPointSix;
        _inRegularPos = !_inRegularPos;
        if(_inRegularPos == false)
        {
            _xrOrigin.transform.localEulerAngles = new Vector3(0, 185.51f, 0);
            _xrOrigin.transform.localPosition = new Vector3(0, 0f, -0.37f);
            _chair.transform.localEulerAngles = new Vector3(0, -180, 0);
            _chair.transform.localPosition = new Vector3(0, 0, 0.13f);
        }
        else
        {
            _xrOrigin.transform.localEulerAngles = Vector3.zero;
            _xrOrigin.transform.localPosition = new Vector3(0,0f, 0.259f);
            _chair.transform.localEulerAngles = Vector3.zero;
            _chair.transform.localPosition = Vector3.zero;
        }
        yield return _twoPointSix;
        _blackOverlay.SetActive(false);
    }

    public void CanTeleport()
    {
        canTeleport = true;
    }

    public void VibrateController(XRDirectInteractor directInteractor)
    {
        directInteractor.SendHapticImpulse(0.5f, 0.3f);
    }

    public void SetChildHand(GameObject hand)
    {
        _selectHand = hand;
        _handVisual = _selectHand.GetComponentInChildren<SkinnedMeshRenderer>();

    }

    public void ChildGrabInteractable(GameObject interactable)
    {
        interactable.transform.parent = _selectHand.transform;
        _handVisual.enabled = false;
    }

    public void EnableHand()
    {
        _handVisual.enabled = true;
    }
}
