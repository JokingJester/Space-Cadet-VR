using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bulletSpark;
    [SerializeField] private GameObject _explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ship")
        {
            TieFighter fighter = other.gameObject.GetComponent<TieFighter>();
            if(fighter != null)
            {
                fighter.health--;
                if(fighter.health <= 0)
                {
                    fighter.destroyedXWingTimeline.SetActive(true);
                    Destroy(other.gameObject,0.4f);
                   GameObject explosion = Instantiate(_explosion, transform.position, transform.rotation);
                    Destroy(explosion, 5f);

                }
            }
        }
        GameObject spark = Instantiate(_bulletSpark, transform.position, transform.rotation);
        Destroy(spark, 1.1f);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 5f);

    }
}
