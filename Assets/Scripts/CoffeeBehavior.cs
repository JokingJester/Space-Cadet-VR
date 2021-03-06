using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBehavior : MonoBehaviour
{
    private bool _applyForce = true;
    [SerializeField] private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopApplyingForceRoutine());
        Destroy(this.gameObject, 30f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_applyForce == true)
        {
            _rb.AddForce(0, -1, 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioSource source = other.GetComponent<AudioSource>();
            if (source != null)
            {
                source.Play();
                TimelineManager.Instance.ObjectiveComplete(0, 14.35f, true);
                Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator StopApplyingForceRoutine()
    {
        yield return new WaitForSeconds(10f);
        _applyForce = false;
    }
}
