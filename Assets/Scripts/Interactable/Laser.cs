using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bulletSpark;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private CapsuleCollider _collider;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<CapsuleCollider>();
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
                fighter.Damage();
            }
        }
        _collider.enabled = false;
        _speed = 0;
        GameObject spark = Instantiate(_bulletSpark, transform.position, transform.rotation);
        spark.transform.parent = this.transform;
        _renderer.enabled = false;
        Destroy(spark, 1.1f);
        Destroy(this.gameObject, 5f);
    }
}
