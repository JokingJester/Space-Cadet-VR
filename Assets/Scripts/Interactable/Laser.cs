using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bulletSpark;
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
                    fighter.DestroyFighter();
                }
            }
        }
        GameObject spark = Instantiate(_bulletSpark, transform.position, transform.rotation);
        Destroy(spark, 1.1f);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 5f);
    }
}
