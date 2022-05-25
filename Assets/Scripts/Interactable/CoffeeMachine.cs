using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    private bool _canPourCoffee = true;
    private WaitForSeconds _oneSecond;
    private WaitForSeconds _onePointFiveSecond;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _coffeePourSound;
    [SerializeField] private GameObject _coffeePrefab;
    [SerializeField] private GameObject _coffeeSpawnPos;
    [SerializeField] private Transform _cockpitTransform;
    [SerializeField] private Button _button;

    private void Start()
    {
        _oneSecond = new WaitForSeconds(1);
        _onePointFiveSecond = new WaitForSeconds(1.5f);
    }

    public void PourCoffee()
    {
        if(_canPourCoffee == true)
            StartCoroutine(PourCoffeeRoutine());
    }

    private IEnumerator PourCoffeeRoutine()
    {
        int coffeeSpawned = 0;
        _canPourCoffee = false;
        yield return _oneSecond;
        _audioSource.PlayOneShot(_coffeePourSound);

        while(coffeeSpawned != 5)
        {
            coffeeSpawned++;
           GameObject coffee = Instantiate(_coffeePrefab, _coffeeSpawnPos.transform.position, Quaternion.identity);
            coffee.transform.parent = _cockpitTransform;
            yield return _onePointFiveSecond;
        }
        yield return _oneSecond;
        _canPourCoffee = true;
        _button.PlayFlashAnimation();
    }
}
